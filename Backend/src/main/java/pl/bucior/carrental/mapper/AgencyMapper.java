package pl.bucior.carrental.mapper;

import org.mapstruct.Mapper;
import org.mapstruct.Mapping;
import org.mapstruct.factory.Mappers;
import pl.bucior.carrental.model.dto.AgencyDto;
import pl.bucior.carrental.model.jpa.Agency;

@Mapper(componentModel = "spring")
public interface AgencyMapper extends ToDtoMapper<Agency, AgencyDto> {

    AgencyMapper INSTANCE = Mappers.getMapper(AgencyMapper.class);

    @Mapping(target = "country", source = "address.country")
    @Mapping(target = "city", source = "address.city")
    @Mapping(target = "postalCode", source = "address.postalCode")
    @Mapping(target = "street", source = "address.street")
    @Mapping(target = "houseNo", source = "address.houseNo")
    @Mapping(target = "flatNo", source = "address.flatNo")
    AgencyDto toDto(Agency jpa);
}
