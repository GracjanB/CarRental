package pl.bucior.carrental.model.dto;

import lombok.Data;
import pl.bucior.carrental.model.enums.Role;

import java.io.Serializable;

@Data
public class UserDto implements Serializable {
    private Long id;
    private String email;
    private Role role;
    private String firstName;
    private String lastName;
    private String pesel;
    private String idCardNumber;
    private Boolean isActive;
}
