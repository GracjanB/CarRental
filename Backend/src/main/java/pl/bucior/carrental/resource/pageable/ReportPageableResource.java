package pl.bucior.carrental.resource.pageable;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.bucior.carrental.mapper.ToDtoMapper;
import pl.bucior.carrental.model.dto.ReportDto;
import pl.bucior.carrental.model.jpa.Report;
import pl.bucior.carrental.util.pageable.AbstractQueryResource;
import pl.bucior.carrental.util.pageable.AbstractSpecificationService;
import pl.bucior.carrental.util.pageable.PageableJpaRepository;

@RestController
@RequestMapping("report")
public class ReportPageableResource extends AbstractQueryResource<Report, Long, ReportDto> {

    public ReportPageableResource(PageableJpaRepository<Report, Long> repository, AbstractSpecificationService<Report, Long> specificationService, ToDtoMapper<Report, ReportDto> mapper) {
        super(repository, specificationService, mapper);
    }
}
