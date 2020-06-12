package pl.bucior.carrental.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import pl.bucior.carrental.model.jpa.AccountVerificationToken;

import java.util.Optional;

public interface AccountVerificationTokenRepository extends JpaRepository<AccountVerificationToken, Long> {

    Optional<AccountVerificationToken> findByToken(String token);
}
