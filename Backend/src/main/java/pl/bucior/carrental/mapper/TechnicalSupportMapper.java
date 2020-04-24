package pl.bucior.carrental.mapper;

import org.mapstruct.Mapper;
import org.mapstruct.Mapping;
import org.mapstruct.factory.Mappers;
import pl.bucior.carrental.model.dto.TechnicalSupportDto;
import pl.bucior.carrental.model.jpa.TechnicalSupport;

@Mapper(componentModel = "spring")
public interface TechnicalSupportMapper extends ToDtoMapper<TechnicalSupport, TechnicalSupportDto> {

    TechnicalSupportMapper INSTANCE = Mappers.getMapper(TechnicalSupportMapper.class);

    @Mapping(target = "employeeEmail", source = "employee.email")
    @Mapping(target = "registerPlate", source = "car.registerPlate")
    @Mapping(target = "mark", source = "car.mark")
    @Mapping(target = "model", source = "car.model")
    @Mapping(target = "technicalSupportActions", source = "technicalSupportHasActionList")
    TechnicalSupportDto toDto(TechnicalSupport technicalSupport);

}
