package pl.bucior.carrental.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.jpa.Address;
import pl.bucior.carrental.model.jpa.User;

import java.util.Optional;

@Repository
public interface AddressRepository extends JpaRepository<Address, Long> {

}
