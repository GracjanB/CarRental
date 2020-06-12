package pl.bucior.carrental.model.request;

import lombok.Data;

import java.io.Serializable;
import java.time.ZonedDateTime;

@Data
public class RentExpectedCostRequest implements Serializable {
    private String carVin;

    private ZonedDateTime rentStartDate;

    private ZonedDateTime rentEndDate;

}
