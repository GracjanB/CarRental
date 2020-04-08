package pl.bucior.carrental.repository;

import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.jpa.Rent;
import pl.bucior.carrental.model.jpa.Rent_;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@Repository
public interface RentRepository extends PageableJpaRepository<Rent, Long> {
    @Override
    default String getKeyName() {
        return Rent_.ID;
    }

}
