package pl.bucior.carrental.model.request;

import lombok.Data;

import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import java.io.Serializable;

@Data
public class AgencyCreateRequest implements Serializable {
    @NotNull
    private Integer maxCarQuantity;
    @NotBlank
    private String country;
    @NotBlank
    private String city;
    @NotBlank
    private String postalCode;
    @NotBlank
    private String street;
    @NotBlank
    private String houseNo;

    private String flatNo;

}
