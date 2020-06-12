package pl.bucior.carrental.mapper;

import org.mapstruct.Mapper;
import org.mapstruct.factory.Mappers;
import pl.bucior.carrental.model.dto.ReportDto;
import pl.bucior.carrental.model.jpa.Report;

@Mapper(componentModel = "spring")
public interface ReportMapper extends ToDtoMapper<Report, ReportDto> {

    ReportMapper INSTANCE = Mappers.getMapper(ReportMapper.class);

    ReportDto toDto(Report jpa);
}
