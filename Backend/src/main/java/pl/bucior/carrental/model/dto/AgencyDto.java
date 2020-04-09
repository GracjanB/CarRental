package pl.bucior.carrental.model.dto;

import lombok.Data;

import java.io.Serializable;

@Data
public class AgencyDto implements Serializable {

    private Long id;
    private Integer maxCarQuantity;
    private String country;
    private String city;
    private String postalCode;
    private String street;
    private String houseNo;
    private String flatNo;
}
