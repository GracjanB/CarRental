package pl.bucior.carrental.service.event;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.context.ApplicationListener;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.stereotype.Component;
import org.springframework.transaction.event.TransactionPhase;
import org.springframework.transaction.event.TransactionalEventListener;
import pl.bucior.carrental.model.message.UserRegistrationMessage;
import pl.bucior.carrental.service.AccountVerificationTokenService;

import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import java.util.UUID;

@Log4j2
@Component
@RequiredArgsConstructor
public class RegistrationListener implements ApplicationListener<OnRegistrationCompleteEvent> {

    private final AccountVerificationTokenService accountVerificationTokenService;

    private final JavaMailSender javaMailSender;

    @Override
    @TransactionalEventListener(phase = TransactionPhase.AFTER_COMMIT)
    public void onApplicationEvent(OnRegistrationCompleteEvent onRegistrationCompleteEvent) {
        this.confirmRegistration(onRegistrationCompleteEvent);
    }

    public void confirmRegistration(OnRegistrationCompleteEvent event) {
        UserRegistrationMessage registrationMessage = (UserRegistrationMessage) event.getSource();
        String token = UUID.randomUUID().toString();
        accountVerificationTokenService.createVerificationToken(registrationMessage.getId(), token);

        String recipientAddress = registrationMessage.getEmail();
        String subject = "Potwierdź swój email w CarRentalWsiz";
        String confirmationUrl = "/user/registrationConfirm?token=" + token;

        MimeMessage mimeMessage = javaMailSender.createMimeMessage();
        try {
            mimeMessage.addRecipient(MimeMessage.RecipientType.TO, new InternetAddress(recipientAddress));
            mimeMessage.addFrom(new InternetAddress[]{new InternetAddress("carrental.wsiz@gmail.com")});
            mimeMessage.setSubject(subject, "UTF-8");
            mimeMessage.setText("Witaj! Twój link aktywacyjny znajduje się poniżej.\r\n" + "https://carrental-dev.herokuapp.com" + confirmationUrl +
                    "\nTwoje wygenerowane hasło to: " + registrationMessage.getPassword(), "UTF-8");
            javaMailSender.send(mimeMessage);
            accountVerificationTokenService.changeStatus(token);
        } catch (Exception e) {
            log.error("Error while send mail for user with id=" + registrationMessage.getId() + ", exception= " + e);
        }
    }
}
