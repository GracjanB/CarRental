package pl.bucior.carrental.service.pageable;

import org.springframework.stereotype.Service;
import pl.bucior.carrental.model.jpa.Agency;
import pl.bucior.carrental.util.pageable.AbstractSpecificationService;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@Service
public class AgencySpecificationService extends AbstractSpecificationService<Agency, Long> {
    public AgencySpecificationService(PageableJpaRepository<Agency, Long> jpaRepository) {
        super(jpaRepository);
    }
}
