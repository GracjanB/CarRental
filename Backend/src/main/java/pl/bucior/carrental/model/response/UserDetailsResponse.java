package pl.bucior.carrental.model.response;

import lombok.Data;
import pl.bucior.carrental.model.dto.UserDto;

import java.io.Serializable;

@Data
public class UserDetailsResponse implements Serializable {
    private UserDto user;
}
