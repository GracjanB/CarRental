package pl.bucior.carrental.model.request;

import lombok.Data;
import pl.bucior.carrental.model.enums.Role;

import javax.validation.constraints.NotNull;
import java.io.Serializable;
import java.time.ZonedDateTime;

@Data
public class HireEmployeeRequest implements Serializable {
    @NotNull
    private Long agencyId;
    @NotNull
    private Long userId;

    private Role role;
    @NotNull
    private ZonedDateTime startContractTime;
    @NotNull
    private ZonedDateTime endContractTime;
}
