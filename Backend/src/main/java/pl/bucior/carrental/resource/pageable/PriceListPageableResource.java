package pl.bucior.carrental.resource.pageable;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.bucior.carrental.mapper.ToDtoMapper;
import pl.bucior.carrental.model.dto.PriceListDto;
import pl.bucior.carrental.model.jpa.PriceList;
import pl.bucior.carrental.util.pageable.AbstractQueryResource;
import pl.bucior.carrental.util.pageable.AbstractSpecificationService;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@RestController
@RequestMapping("priceList")
public class PriceListPageableResource extends AbstractQueryResource<PriceList, Long, PriceListDto> {

    public PriceListPageableResource(PageableJpaRepository<PriceList, Long> repository, AbstractSpecificationService<PriceList, Long> specificationService, ToDtoMapper<PriceList, PriceListDto> mapper) {
        super(repository, specificationService, mapper);
    }
}
