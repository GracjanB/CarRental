package pl.bucior.carrental.service.pageable;

import org.springframework.stereotype.Service;
import pl.bucior.carrental.model.jpa.AgencyHasUser;
import pl.bucior.carrental.util.pageable.AbstractSpecificationService;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@Service
public class AgencyHasUserSpecificationService extends AbstractSpecificationService<AgencyHasUser, Long> {
    public AgencyHasUserSpecificationService(PageableJpaRepository<AgencyHasUser, Long> jpaRepository) {
        super(jpaRepository);
    }
}
