package pl.bucior.carrental.model.response;

import lombok.Data;
import pl.bucior.carrental.model.dto.CarDto;

import java.io.Serializable;
import java.util.List;

@Data
public class AvailableCarResponse implements Serializable {

    private List<CarDto> cars;
}
