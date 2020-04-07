package pl.bucior.carrental.model.request;

import lombok.Data;

import java.io.Serializable;
import java.math.BigDecimal;
import java.time.ZonedDateTime;

@Data
public class RentCreateRequest implements Serializable {

    private Long userId;

    private String carVin;

    private Long targetAgencyId;

    private ZonedDateTime rentStartDate;

    private ZonedDateTime rentEndDate;

    private Integer startMileage;

    private BigDecimal deposit;

}
