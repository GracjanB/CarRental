package pl.bucior.carrental.util.pageable;

import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.NoRepositoryBean;

import java.lang.reflect.Field;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Set;
import java.util.stream.Collectors;

@NoRepositoryBean
public interface PageableJpaRepository<T, ID> extends JpaRepository<T, ID> {

    String getKeyName();

    Page<T> findAll(Specification<T> specification, Pageable pageable);

    default List<String> getFields(Set<String> fields, Class<?> type) {
        fields.addAll(Arrays.stream(type.getDeclaredFields()).map(Field::getName).collect(Collectors.toList()));

        Class<?> superclass = type.getSuperclass();
        while (superclass != null) {
            fields.addAll(Arrays.stream(superclass.getDeclaredFields()).map(Field::getName).collect(Collectors.toList()));
            superclass = superclass.getSuperclass();
        }

        return new ArrayList<>(fields);
    }

}
