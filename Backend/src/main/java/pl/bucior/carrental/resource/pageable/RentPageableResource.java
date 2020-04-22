package pl.bucior.carrental.resource.pageable;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.bucior.carrental.mapper.ToDtoMapper;
import pl.bucior.carrental.model.dto.RentDto;
import pl.bucior.carrental.model.jpa.Rent;
import pl.bucior.carrental.util.pageable.AbstractQueryResource;
import pl.bucior.carrental.util.pageable.AbstractSpecificationService;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@RestController
@RequestMapping("rent")
public class RentPageableResource extends AbstractQueryResource<Rent, Long, RentDto> {

    public RentPageableResource(PageableJpaRepository<Rent, Long> repository, AbstractSpecificationService<Rent, Long> specificationService, ToDtoMapper<Rent, RentDto> mapper) {
        super(repository, specificationService, mapper);
    }
}
