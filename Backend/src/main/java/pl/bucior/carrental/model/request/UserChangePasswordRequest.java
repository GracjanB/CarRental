package pl.bucior.carrental.model.request;

import io.swagger.annotations.ApiModelProperty;
import lombok.Data;
import org.hibernate.validator.constraints.Length;

import javax.validation.constraints.NotEmpty;
import java.io.Serializable;

@Data
public class UserChangePasswordRequest implements Serializable {
    @NotEmpty
    @Length(min = 8, max = 255)
    @ApiModelProperty(value = "password", required = true)
    private String password;
}
