package pl.bucior.carrental.service.pageable;

import org.springframework.stereotype.Service;
import pl.bucior.carrental.model.jpa.Report;
import pl.bucior.carrental.util.pageable.AbstractSpecificationService;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@Service
public class ReportSpecificationService extends AbstractSpecificationService<Report, Long> {
    public ReportSpecificationService(PageableJpaRepository<Report, Long> jpaRepository) {
        super(jpaRepository);
    }
}
