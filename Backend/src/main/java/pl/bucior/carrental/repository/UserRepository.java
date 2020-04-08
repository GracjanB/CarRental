package pl.bucior.carrental.repository;

import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.jpa.User;
import pl.bucior.carrental.model.jpa.User_;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

import java.util.Optional;

@Repository
public interface UserRepository extends PageableJpaRepository<User, Long> {

    @Override
    default String getKeyName() {
        return User_.ID;
    }


    Optional<User> findByEmail(String email);
}
