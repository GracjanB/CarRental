package pl.bucior.carrental.service.event;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.context.ApplicationListener;
import org.springframework.context.MessageSource;
import org.springframework.mail.SimpleMailMessage;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.stereotype.Component;
import org.springframework.transaction.event.TransactionPhase;
import org.springframework.transaction.event.TransactionalEventListener;
import pl.bucior.carrental.model.jpa.User;
import pl.bucior.carrental.service.AccountVerificationTokenService;

import java.util.UUID;

@Log4j2
@Component
@RequiredArgsConstructor
public class RegistrationListener implements ApplicationListener<OnRegistrationCompleteEvent> {

    private final AccountVerificationTokenService accountVerificationTokenService;

    private final JavaMailSender javaMailSender;

    private final MessageSource messages;

    @Override
    @TransactionalEventListener(phase = TransactionPhase.AFTER_COMMIT)
    public void onApplicationEvent(OnRegistrationCompleteEvent onRegistrationCompleteEvent) {
        this.confirmRegistration(onRegistrationCompleteEvent);
    }

    public void confirmRegistration(OnRegistrationCompleteEvent event) {
        User user = (User) event.getSource();
        String token = UUID.randomUUID().toString();
        accountVerificationTokenService.createVerificationToken(user, token);

        String recipientAddress = user.getEmail();
        String subject = "Registration Confirmation";
        String confirmationUrl = "/user/registrationConfirm?token=" + token;
        String message = messages.getMessage("register", null, event.getLocale());

        SimpleMailMessage email = new SimpleMailMessage();
        email.setTo(recipientAddress);
        email.setSubject(subject);
        email.setText(message + "\r\n" + "URL +" + confirmationUrl);
        try {
            javaMailSender.send(email);
            accountVerificationTokenService.changeStatus(token);
        } catch (Exception e) {
            log.error("Error while send mail for user with id=" + user.getId());
        }
    }
}
