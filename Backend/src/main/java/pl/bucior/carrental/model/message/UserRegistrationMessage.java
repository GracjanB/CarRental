package pl.bucior.carrental.model.message;

import lombok.Builder;
import lombok.Data;

@Builder
@Data
public class UserRegistrationMessage {
    private Long id;
    private String password;
    private String email;
}
