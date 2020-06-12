package pl.bucior.carrental.repository;

import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.jpa.Agency;
import pl.bucior.carrental.model.jpa.Agency_;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@Repository
public interface AgencyRepository extends PageableJpaRepository<Agency, Long> {

    @Override
    default String getKeyName() {
        return Agency_.ID;
    }


}
