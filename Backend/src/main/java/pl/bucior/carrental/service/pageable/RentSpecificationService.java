package pl.bucior.carrental.service.pageable;

import org.springframework.stereotype.Service;
import pl.bucior.carrental.model.jpa.Rent;
import pl.bucior.carrental.model.jpa.User;
import pl.bucior.carrental.util.pageable.AbstractSpecificationService;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@Service
public class RentSpecificationService extends AbstractSpecificationService<Rent, Long> {
    public RentSpecificationService(PageableJpaRepository<Rent, Long> jpaRepository) {
        super(jpaRepository);
    }
}
