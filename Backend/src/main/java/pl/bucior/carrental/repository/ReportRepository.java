package pl.bucior.carrental.repository;

import org.springframework.stereotype.Repository;
import pl.bucior.carrental.model.jpa.Report;
import pl.bucior.carrental.model.jpa.Report_;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

import java.time.ZonedDateTime;
import java.util.Optional;

@Repository
public interface ReportRepository extends PageableJpaRepository<Report, Long> {

    @Override
    default String getKeyName() {
        return Report_.ID;
    }

    Optional<Report> findByCreationDateBetween(ZonedDateTime creationDate, ZonedDateTime creationDate2);
}
