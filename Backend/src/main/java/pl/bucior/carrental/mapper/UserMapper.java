package pl.bucior.carrental.mapper;

import org.mapstruct.Mapper;
import org.mapstruct.factory.Mappers;
import pl.bucior.carrental.model.dto.UserDto;
import pl.bucior.carrental.model.jpa.User;

@Mapper(componentModel = "spring")
public interface UserMapper extends ToDtoMapper<User, UserDto> {

    UserMapper INSTANCE = Mappers.getMapper(UserMapper.class);

    UserDto toDto(User jpa);
}
