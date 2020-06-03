package pl.bucior.carrental.service.event;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.context.ApplicationListener;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.stereotype.Component;
import org.springframework.transaction.event.TransactionPhase;
import org.springframework.transaction.event.TransactionalEventListener;
import pl.bucior.carrental.model.message.TechnicalSupportMessage;
import pl.bucior.carrental.model.message.UserRegistrationMessage;
import pl.bucior.carrental.service.AccountVerificationTokenService;

import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import java.util.UUID;

@Log4j2
@Component
@RequiredArgsConstructor
public class EmailEventListener implements ApplicationListener<EmailEvent> {

    private final AccountVerificationTokenService accountVerificationTokenService;

    private final JavaMailSender javaMailSender;

    @Override
    @TransactionalEventListener(phase = TransactionPhase.AFTER_COMMIT)
    public void onApplicationEvent(EmailEvent emailEvent) {
        if (emailEvent.getSource() instanceof UserRegistrationMessage) {
            confirmRegistration((UserRegistrationMessage) emailEvent.getSource());
        } else if (emailEvent.getSource() instanceof TechnicalSupportMessage) {
            sendOrdersToTechnicalEmployee((TechnicalSupportMessage) emailEvent.getSource());
        }
    }

    public void confirmRegistration(UserRegistrationMessage registrationMessage) {
        String token = UUID.randomUUID().toString();
        accountVerificationTokenService.createVerificationToken(registrationMessage.getId(), token);

        try {
            MimeMessage mimeMessage = javaMailSender.createMimeMessage();
            mimeMessage.addRecipient(MimeMessage.RecipientType.TO, new InternetAddress(registrationMessage.getEmail()));
            mimeMessage.addFrom(new InternetAddress[]{new InternetAddress("carrental.wsiz@wp.pl")});
            mimeMessage.setSubject("Potwierdź swój email w CarRentalWsiz", "UTF-8");
            mimeMessage.setText("Witaj! Twój link aktywacyjny znajduje się poniżej.\r\n" +
                    "https://carrental-dev.herokuapp.com/user/registrationConfirm?token=" + token +
                    "\nTwoje wygenerowane hasło to: " + registrationMessage.getPassword(), "UTF-8");
            javaMailSender.send(mimeMessage);
            accountVerificationTokenService.changeStatus(token);
        } catch (Exception e) {
            log.error("Error while send mail for user with id=" + registrationMessage.getId() + ", exception= " + e);
        }
    }

    public void sendOrdersToTechnicalEmployee(TechnicalSupportMessage technicalSupportMessage) {
        try {
            MimeMessage mimeMessage = javaMailSender.createMimeMessage();
            for (String email : technicalSupportMessage.getEmails()) {
                mimeMessage.addRecipient(MimeMessage.RecipientType.TO, new InternetAddress(email));
            }
            mimeMessage.addFrom(new InternetAddress[]{new InternetAddress("carrental.wsiz@wp.pl")});
            mimeMessage.setSubject("Nowe zlecenie dla Ciebie!", "UTF-8");
            mimeMessage.setText(String.format("Cześć, w systemie znajduje się nowe zlecenie do odbioru już teraz!\nZlecenie zostało utworzone dla pojazdu z nr rej. %s", technicalSupportMessage.getRegisterPlate()));
            javaMailSender.send(mimeMessage);
        } catch (Exception e) {
            log.error("Error while send technical support mail for car with registrationPlate=" + technicalSupportMessage.getRegisterPlate()
                    + ", exception= " + e);
        }
    }
}
