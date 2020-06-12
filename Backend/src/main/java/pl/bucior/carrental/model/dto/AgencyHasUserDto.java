package pl.bucior.carrental.model.dto;

import lombok.Data;

import java.io.Serializable;
import java.time.ZonedDateTime;

@Data
public class AgencyHasUserDto implements Serializable {
    private AgencyDto agency;
    private UserDto user;
    private ZonedDateTime startContractTime;
    private ZonedDateTime endContractTime;
}
