package pl.bucior.carrental.mapper;

import org.mapstruct.Mapper;
import org.mapstruct.Mapping;
import org.mapstruct.factory.Mappers;
import pl.bucior.carrental.model.dto.RentDto;
import pl.bucior.carrental.model.jpa.Rent;

@Mapper(componentModel = "spring")
public interface RentMapper extends ToDtoMapper<Rent, RentDto> {

    RentMapper INSTANCE = Mappers.getMapper(RentMapper.class);

    @Mapping(target = "userMail", source = "user.email")
    @Mapping(target = "employeeMail", source = "employee.email")
    @Mapping(target = "targetAgencyCity", source = "targetAgency.address.city")
    @Mapping(target = "agencyCity", source = "agency.address.city")
    RentDto toDto(Rent rent);

}

