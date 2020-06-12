package pl.bucior.carrental.resource.pageable;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.bucior.carrental.mapper.ToDtoMapper;
import pl.bucior.carrental.model.dto.AgencyHasUserDto;
import pl.bucior.carrental.model.jpa.AgencyHasUser;
import pl.bucior.carrental.util.pageable.AbstractQueryResource;
import pl.bucior.carrental.util.pageable.AbstractSpecificationService;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@RestController
@RequestMapping("agencyHasUser")
public class AgencyHasUserPageableResource extends AbstractQueryResource<AgencyHasUser, Long, AgencyHasUserDto> {

    public AgencyHasUserPageableResource(PageableJpaRepository<AgencyHasUser, Long> repository, AbstractSpecificationService<AgencyHasUser, Long> specificationService, ToDtoMapper<AgencyHasUser, AgencyHasUserDto> mapper) {
        super(repository, specificationService, mapper);
    }
}
