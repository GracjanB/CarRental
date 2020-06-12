package pl.bucior.carrental.repository;

import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.jpa.AgencyHasUser;
import pl.bucior.carrental.model.jpa.AgencyHasUser_;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

import java.util.Optional;

@Repository
public interface AgencyHasUserRepository extends PageableJpaRepository<AgencyHasUser, Long> {

    @Override
    default String getKeyName() {
        return AgencyHasUser_.ID;
    }

    Optional<AgencyHasUser> findByUserId(Long userId);

}
