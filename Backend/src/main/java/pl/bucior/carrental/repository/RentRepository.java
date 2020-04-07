package pl.bucior.carrental.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.jpa.Rent;
import pl.bucior.carrental.model.jpa.TechnicalSupport;

@Repository
public interface RentRepository extends JpaRepository<Rent, Long> {

}
