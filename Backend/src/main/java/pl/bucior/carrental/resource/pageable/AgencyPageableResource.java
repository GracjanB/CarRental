package pl.bucior.carrental.resource.pageable;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.bucior.carrental.mapper.ToDtoMapper;
import pl.bucior.carrental.model.dto.AgencyDto;
import pl.bucior.carrental.model.jpa.Agency;
import pl.bucior.carrental.util.pageable.AbstractQueryResource;
import pl.bucior.carrental.util.pageable.AbstractSpecificationService;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@RestController
@RequestMapping("agency")
public class AgencyPageableResource extends AbstractQueryResource<Agency, Long, AgencyDto> {

    public AgencyPageableResource(PageableJpaRepository<Agency, Long> repository, AbstractSpecificationService<Agency, Long> specificationService, ToDtoMapper<Agency, AgencyDto> mapper) {
        super(repository, specificationService, mapper);
    }
}
