package pl.bucior.carrental.repository;

import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.jpa.TechnicalSupport;
import pl.bucior.carrental.model.jpa.TechnicalSupport_;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@Repository
public interface TechnicalSupportRepository extends PageableJpaRepository<TechnicalSupport, Long> {
    @Override
    default String getKeyName() {
        return TechnicalSupport_.ID;
    }

}
