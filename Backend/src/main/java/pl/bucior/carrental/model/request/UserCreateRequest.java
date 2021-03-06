package pl.bucior.carrental.model.request;

import io.swagger.annotations.ApiModelProperty;
import lombok.*;
import org.hibernate.validator.constraints.Length;

import javax.validation.constraints.Email;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotEmpty;
import java.io.Serializable;

@Getter
@Setter
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class UserCreateRequest implements Serializable {

    @NotEmpty
    @Length(max = 255)
    @ApiModelProperty(value = "First name", required = true)
    private String firstName;

    @NotEmpty
    @Length(max = 255)
    @ApiModelProperty(value = "Last name", required = true)
    private String lastName;

    @NotBlank
    private String pesel;
    @NotBlank
    private String idCardNumber;

    @NotEmpty
    @Length(max = 255)
    @Email
    @ApiModelProperty(value = "E-mail", required = true)
    private String email;

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
