package pl.bucior.carrental.mapper;

import org.mapstruct.Mapper;
import org.mapstruct.Mapping;
import org.mapstruct.factory.Mappers;
import pl.bucior.carrental.model.dto.CarDto;
import pl.bucior.carrental.model.jpa.Car;

@Mapper(componentModel = "spring")
public interface CarMapper extends ToDtoMapper<Car, CarDto> {

    CarMapper INSTANCE = Mappers.getMapper(CarMapper.class);

    @Mapping(target = "dailyPrice", source = "priceList.dailyPrice")
    @Mapping(target = "carPhotoId", source = "carPhoto.id")
    CarDto toDto(Car jpa);
}
