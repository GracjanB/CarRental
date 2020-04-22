package pl.bucior.carrental.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.jpa.TechnicalSupportDoneAction;

@Repository
public interface TechnicalSupportDoneActionRepository extends JpaRepository<TechnicalSupportDoneAction, Long> {
}
