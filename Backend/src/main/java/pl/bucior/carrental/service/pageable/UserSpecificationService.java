package pl.bucior.carrental.service.pageable;

import org.springframework.stereotype.Service;
import pl.bucior.carrental.model.jpa.User;
import pl.bucior.carrental.util.pageable.AbstractSpecificationService;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@Service
public class UserSpecificationService extends AbstractSpecificationService<User, Long> {
    public UserSpecificationService(PageableJpaRepository<User, Long> jpaRepository) {
        super(jpaRepository);
    }
}
