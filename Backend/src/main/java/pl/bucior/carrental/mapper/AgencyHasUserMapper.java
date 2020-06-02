package pl.bucior.carrental.mapper;

import org.mapstruct.Mapper;
import org.mapstruct.factory.Mappers;
import pl.bucior.carrental.model.dto.AgencyHasUserDto;
import pl.bucior.carrental.model.jpa.AgencyHasUser;

@Mapper(componentModel = "spring")
public interface AgencyHasUserMapper extends ToDtoMapper<AgencyHasUser, AgencyHasUserDto> {

    AgencyHasUserMapper INSTANCE = Mappers.getMapper(AgencyHasUserMapper.class);

    @Override
    default AgencyHasUserDto toDto(AgencyHasUser jpa) {
        if (jpa == null) {
            return null;
        }

        AgencyHasUserDto agencyHasUserDto = new AgencyHasUserDto();

        agencyHasUserDto.setAgency(AgencyMapper.INSTANCE.toDto(jpa.getAgency()));
        agencyHasUserDto.setUser(UserMapper.INSTANCE.toDto(jpa.getUser()));
        agencyHasUserDto.setStartContractTime(jpa.getStartContractTime());
        agencyHasUserDto.setEndContractTime(jpa.getEndContractTime());

        return agencyHasUserDto;
    }
}
