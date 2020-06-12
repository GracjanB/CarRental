package pl.bucior.carrental.util.pageable;

import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Sort;
import org.springframework.data.jpa.domain.Specification;

import javax.annotation.PostConstruct;
import java.lang.reflect.ParameterizedType;
import java.util.HashSet;

public abstract class AbstractSpecificationService<T, ID> {

    private Class<T> entityBeanType;
    private SpecificationFactory<T> specificationFactory;
    private final PageableJpaRepository<T, ID> jpaRepository;

    public AbstractSpecificationService(PageableJpaRepository<T, ID> jpaRepository) {
        this.jpaRepository = jpaRepository;
        this.entityBeanType = ((Class<T>) ((ParameterizedType) getClass()
                .getGenericSuperclass()).getActualTypeArguments()[0]);
    }

    @PostConstruct
    public void init() {
        specificationFactory = new SpecificationFactory<>(new SpecificationsBuilder<>(jpaRepository.getFields(new HashSet<>(), entityBeanType)));
    }

    public Page<T> getBySpec(String search, String field, Boolean isAscending, Integer pageNumber, Integer pageSize) {
        Specification<T> spec = specificationFactory.createSpecification(search);
        PageRequest pageRequest = PageRequest.of(pageNumber, pageSize, Sort.by(isAscending ? Sort.Direction.ASC : Sort.Direction.DESC, field != null ? field : jpaRepository.getKeyName()));
        return jpaRepository.findAll(spec, pageRequest);
    }


}
