package pl.bucior.carrental.model.dto;

import lombok.Data;
import pl.bucior.carrental.model.enums.CarType;

import java.io.Serializable;
import java.math.BigDecimal;


@Data
public class CarDto implements Serializable {

    private String vin;
    private String mark;
    private String model;
    private String carVersion;
    private CarType carType;
    private Integer mileage;
    private Integer horsePower;
    private Integer engineCapacity;
    private String registerPlate;
    private BigDecimal dailyPrice;
    private Long parentAgencyId;
    private Long currentAgencyId;

}
