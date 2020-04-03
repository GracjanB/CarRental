package pl.bucior.carrental.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.jpa.Agency;
import pl.bucior.carrental.model.jpa.AgencyHasUser;

@Repository
public interface AgencyRepository extends JpaRepository<Agency, Long> {

}
