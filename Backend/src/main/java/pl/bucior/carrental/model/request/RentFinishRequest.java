package pl.bucior.carrental.model.request;

import lombok.Data;
import pl.bucior.carrental.model.enums.TechnicalSupportActionEnum;

import java.io.Serializable;
import java.math.BigDecimal;
import java.time.ZonedDateTime;
import java.util.List;

@Data
public class RentFinishRequest implements Serializable {
    private String vin;
    private Integer endMileage;
    private ZonedDateTime rentEndDate;
    private BigDecimal finalPrice;
    private List<TechnicalSupportActionEnum> technicalSupportActions;


}
