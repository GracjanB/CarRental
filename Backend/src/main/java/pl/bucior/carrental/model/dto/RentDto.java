package pl.bucior.carrental.model.dto;

import lombok.Data;
import pl.bucior.carrental.model.enums.RentStatus;

import java.io.Serializable;
import java.math.BigDecimal;
import java.time.ZonedDateTime;

@Data
public class RentDto implements Serializable {

    private Long id;

    private String userMail;

    private String carVin;

    private String agencyCity;

    private String targetAgencyCity;

    private String employeeMail;

    private ZonedDateTime rentStartDate;

    private ZonedDateTime rentEndDate;

    private Integer startMileage;

    private Integer endMileage;

    private BigDecimal deposit;

    private BigDecimal calculatedPrice;

    private BigDecimal finalPrice;

    private RentStatus status;
}
