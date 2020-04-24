package pl.bucior.carrental.model.dto;

import lombok.Data;
import pl.bucior.carrental.model.enums.TechnicalSupportActionEnum;

import java.io.Serializable;

@Data
public class TechnicalSupportHasActionDto implements Serializable {

    private Long id;
    private TechnicalSupportActionEnum technicalSupportAction;
    private Boolean completed;
}
