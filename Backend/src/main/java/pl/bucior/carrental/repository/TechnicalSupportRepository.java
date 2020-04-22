package pl.bucior.carrental.repository;

import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.enums.TechnicalSupportStatus;
import pl.bucior.carrental.model.jpa.Car;
import pl.bucior.carrental.model.jpa.TechnicalSupport;
import pl.bucior.carrental.model.jpa.TechnicalSupport_;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

import java.util.Collection;
import java.util.List;

@Repository
public interface TechnicalSupportRepository extends PageableJpaRepository<TechnicalSupport, Long> {
    @Override
    default String getKeyName() {
        return TechnicalSupport_.ID;
    }

    List<TechnicalSupport> findAllByCarVinAndStatusIsNot(String carVin, TechnicalSupportStatus status);

    @Query(value = "select c from Car c left join TechnicalSupport ts on ts.carVin = c.vin where ts.status='CREATED' and c.enabled = true")
    List<Car> findCarsWithOpenTechnicalSupport();
}
