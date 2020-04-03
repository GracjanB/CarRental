package pl.bucior.carrental.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.jpa.Address;
import pl.bucior.carrental.model.jpa.Car;

@Repository
public interface CarRepository extends JpaRepository<Car, String> {

}
