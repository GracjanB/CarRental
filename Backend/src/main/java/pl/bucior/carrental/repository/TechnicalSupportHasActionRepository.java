package pl.bucior.carrental.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.jpa.TechnicalSupportHasAction;

@Repository
public interface TechnicalSupportHasActionRepository extends JpaRepository<TechnicalSupportHasAction, Long> {
}
