package pl.bucior.carrental.service.pageable;

import org.springframework.stereotype.Service;
import pl.bucior.carrental.model.jpa.PriceList;
import pl.bucior.carrental.util.pageable.AbstractSpecificationService;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@Service
public class PriceListSpecificationService extends AbstractSpecificationService<PriceList, Long> {
    public PriceListSpecificationService(PageableJpaRepository<PriceList, Long> jpaRepository) {
        super(jpaRepository);
    }
}
