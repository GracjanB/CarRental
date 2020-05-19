package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.model.jpa.AccountVerificationToken;
import pl.bucior.carrental.repository.AccountVerificationTokenRepository;

import javax.transaction.Transactional;

@Service
@Transactional
@RequiredArgsConstructor
public class AccountVerificationTokenService {

    private final AccountVerificationTokenRepository accountVerificationTokenRepository;

    public void createVerificationToken(Long userId, String token) {
        accountVerificationTokenRepository.save(AccountVerificationToken
                .builder()
                .token(token)
                .mailSended(false)
                .userId(userId)
                .build());
    }

    public void changeStatus(String token) {
        accountVerificationTokenRepository.findByToken(token).ifPresent(accountVerificationToken -> accountVerificationToken.setMailSended(true));
    }

}
