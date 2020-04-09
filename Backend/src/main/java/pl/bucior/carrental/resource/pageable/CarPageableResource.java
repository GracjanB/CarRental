package pl.bucior.carrental.resource.pageable;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.bucior.carrental.mapper.ToDtoMapper;
import pl.bucior.carrental.model.dto.CarDto;
import pl.bucior.carrental.model.jpa.Car;
import pl.bucior.carrental.util.pageable.AbstractQueryResource;
import pl.bucior.carrental.util.pageable.AbstractSpecificationService;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@RestController
@RequestMapping("car")
public class CarPageableResource extends AbstractQueryResource<Car, String, CarDto> {

    public CarPageableResource(PageableJpaRepository<Car, String> repository, AbstractSpecificationService<Car, String> specificationService, ToDtoMapper<Car, CarDto> mapper) {
        super(repository, specificationService, mapper);
    }
}
