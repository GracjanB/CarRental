package pl.bucior.carrental.repository;

import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.enums.RentStatus;
import pl.bucior.carrental.model.jpa.Car;
import pl.bucior.carrental.model.jpa.Rent;
import pl.bucior.carrental.model.jpa.Rent_;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

import java.util.List;
import java.util.Optional;

@Repository
public interface RentRepository extends PageableJpaRepository<Rent, Long> {
    @Override
    default String getKeyName() {
        return Rent_.ID;
    }

    Optional<Rent> findByCarVinAndStatusNotIn(String vin, List<RentStatus> status);

    Optional<Rent> findByUserIdAndStatusNotIn(Long userId, List<RentStatus> status);

    @Query(value = "select c from Car c left join Rent r on r.carVin = c.vin where r.status not in ('RETURNED','CANCELLED') and c.enabled = true")
    List<Car> findCarsWithOpenRent();
}
