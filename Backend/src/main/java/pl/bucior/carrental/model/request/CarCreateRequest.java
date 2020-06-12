package pl.bucior.carrental.model.request;

import lombok.Data;
import org.hibernate.validator.constraints.Length;
import pl.bucior.carrental.model.enums.CarType;

import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import java.io.Serializable;

@Data
public class CarCreateRequest implements Serializable {
    @Length(min = 17, max = 17)
    private String vin;
    @NotNull
    private Long priceListId;
    @NotNull
    private Long agencyId;
    @NotNull
    private CarType carType;
    @NotBlank
    private String mark;
    @NotBlank
    private String model;
    @NotBlank
    private String carVersion;
    @NotNull
    private Integer horsePower;
    @NotNull
    private Integer engineCapacity;
    @NotNull
    private Integer mileage;
    @NotBlank
    @Length(min = 2, max = 9)
    private String registerPlate;

}
