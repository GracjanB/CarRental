package pl.bucior.carrental.model.request;

import lombok.*;
import org.hibernate.validator.constraints.Length;

import javax.validation.constraints.Email;
import javax.validation.constraints.NotEmpty;

@Getter
@Setter
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class UserCreateRequest {

//    @NotEmpty
//    @Length(max = 255)
////    @ApiModelProperty(value = "First name", required = true)
//    private String firstName;
//
//    @NotEmpty
//    @Length(max = 255)
////    @ApiModelProperty(value = "Last name", required = true)
//    private String lastName;

    @NotEmpty
    @Length(min = 8, max = 255)
//    @ApiModelProperty(value = "password", required = true)
    private String password;

    @NotEmpty
    @Length(max = 255)
    @Email
//    @ApiModelProperty(value = "E-mail", required = true)
    private String email;

}
