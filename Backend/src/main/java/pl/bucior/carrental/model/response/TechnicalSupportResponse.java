package pl.bucior.carrental.model.response;

import lombok.Data;
import pl.bucior.carrental.model.dto.TechnicalSupportDto;

import java.io.Serializable;
import java.util.List;

@Data
public class TechnicalSupportResponse implements Serializable {

    private List<TechnicalSupportDto> technicalSupports;
}
