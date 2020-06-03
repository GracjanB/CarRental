package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.configuration.exception.ErrorCode;
import pl.bucior.carrental.configuration.exception.WsizException;
import pl.bucior.carrental.model.jpa.AccountVerificationToken;
import pl.bucior.carrental.repository.AccountVerificationTokenRepository;
import pl.bucior.carrental.repository.UserRepository;

import javax.transaction.Transactional;

@Service
@Transactional
@RequiredArgsConstructor
public class AccountVerificationTokenService {

    private final AccountVerificationTokenRepository accountVerificationTokenRepository;
    private final UserRepository userRepository;

    public void createVerificationToken(Long userId, String token) {
        accountVerificationTokenRepository.save(AccountVerificationToken
                .builder()
                .token(token)
                .mailSended(false)
                .userId(userId)
                .user(userRepository.findById(userId).orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.USER_NOT_FOUND)))
                .build());
    }

    public void changeStatus(String token) {
        accountVerificationTokenRepository.findByToken(token).ifPresent(accountVerificationToken -> accountVerificationToken.setMailSended(true));
    }

}
