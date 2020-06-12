package pl.bucior.carrental.service.pageable;

import org.springframework.stereotype.Service;
import pl.bucior.carrental.model.jpa.Car;
import pl.bucior.carrental.util.pageable.AbstractSpecificationService;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@Service
public class CarSpecificationService extends AbstractSpecificationService<Car, String> {
    public CarSpecificationService(PageableJpaRepository<Car, String> jpaRepository) {
        super(jpaRepository);
    }
}
