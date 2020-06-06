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
    @Mapping(target = "userId", source = "user.id")
    @Mapping(target = "employeeMail", source = "employee.email")
    @Mapping(target = "targetAgencyCity", source = "targetAgency.address.city")
    @Mapping(target = "targetAgencyId", source = "targetAgency.id")
    @Mapping(target = "agencyCity", source = "agency.address.city")
    @Mapping(target = "agencyId", source = "agency.id")
    RentDto toDto(Rent rent);

}

