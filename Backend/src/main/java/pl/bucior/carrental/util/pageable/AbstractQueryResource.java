package pl.bucior.carrental.util.pageable;

import lombok.RequiredArgsConstructor;
import org.springframework.data.domain.Page;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestParam;
import pl.bucior.carrental.mapper.ToDtoMapper;


@RequiredArgsConstructor
public abstract class AbstractQueryResource<T, ID, TDTO> {

    private final PageableJpaRepository<T, ID> repository;
    private final AbstractSpecificationService<T, ID> specificationService;
    private final ToDtoMapper<T, TDTO> mapper;

    @GetMapping("{id}")
    public ResponseEntity getById(@PathVariable("id") ID id) {
        return new ResponseEntity<>(
                ObjectResponse.builder()
                        .data(repository.findById(id).map(mapper::toDto))
                        .build(),
                HttpStatus.OK);
    }

    @GetMapping("/bySpec")
    public ResponseEntity getBySpec(
            @RequestParam(value = "search", required = false) String search,
            @RequestParam(value = "field", required = false) String field,
            @RequestParam(value = "isAscending", defaultValue = "true", required = false) Boolean isAscending,
            @RequestParam(value = "pageNumber", defaultValue = "0", required = false) Integer pageNumber,
            @RequestParam(value = "pageSize", defaultValue = "25", required = false) Integer pageSize) {

        Page<T> pageResponse = specificationService.getBySpec(search, field, isAscending, pageNumber, pageSize);
        return new ResponseEntity<>(pageResponse.map(mapper::toDto), HttpStatus.OK);
    }
}
