package pl.bucior.carrental.model.response;

import lombok.Data;
import pl.bucior.carrental.model.enums.Role;

import java.io.Serializable;

@Data
public class UserRoleResponse implements Serializable {
    private Role role;
}
