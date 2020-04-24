package pl.bucior.carrental.model.dto;

import lombok.Data;
import pl.bucior.carrental.model.enums.TechnicalSupportStatus;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

@Data
public class TechnicalSupportDto implements Serializable {
    private Long id;
    private Long rentId;
    private String employeeEmail;
    private String registerPlate;
    private String mark;
    private String model;
    private String carVin;
    private BigDecimal cost;
    private String comment;
    private TechnicalSupportStatus status;
    private List<TechnicalSupportHasActionDto> technicalSupportActions;
}
