package pl.bucior.carrental.resource.pageable;

import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.bucior.carrental.mapper.ToDtoMapper;
import pl.bucior.carrental.model.dto.UserDto;
import pl.bucior.carrental.model.jpa.User;
import pl.bucior.carrental.util.pageable.AbstractQueryResource;
import pl.bucior.carrental.util.pageable.AbstractSpecificationService;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@RestController
@RequestMapping("user")
public class UserPageableResource extends AbstractQueryResource<User, Long, UserDto> {

    public UserPageableResource(PageableJpaRepository<User, Long> repository, AbstractSpecificationService<User, Long> specificationService, ToDtoMapper<User, UserDto> mapper) {
        super(repository, specificationService, mapper);
    }

    @PreAuthorize("hasAnyRole('EMPLOYEE','MANAGER')")
    @Override
    public ResponseEntity getById(Long aLong) {
        return super.getById(aLong);
    }

    @PreAuthorize("hasAnyRole('EMPLOYEE','MANAGER')")
    @Override
    public ResponseEntity getBySpec(String search, String field, Boolean isAscending, Integer pageNumber, Integer pageSize) {
        return super.getBySpec(search, field, isAscending, pageNumber, pageSize);
    }
}
