package pl.bucior.carrental.repository;

import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.jpa.Car;
import pl.bucior.carrental.model.jpa.Car_;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

import java.util.List;

@Repository
public interface CarRepository extends PageableJpaRepository<Car, String> {
    @Override
    default String getKeyName() {
        return Car_.VIN;
    }

    List<Car> findAllByEnabledIsTrue();
}
