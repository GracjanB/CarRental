package pl.bucior.carrental.mapper;

import org.mapstruct.Mapper;
import org.mapstruct.factory.Mappers;
import pl.bucior.carrental.model.dto.PriceListDto;
import pl.bucior.carrental.model.jpa.PriceList;

@Mapper(componentModel = "spring")
public interface PriceListMapper extends ToDtoMapper<PriceList, PriceListDto> {

    PriceListMapper INSTANCE = Mappers.getMapper(PriceListMapper.class);

    PriceListDto toDto(PriceList jpa);
}
