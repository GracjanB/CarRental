package pl.bucior.carrental.resource;

import io.swagger.annotations.ApiOperation;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import pl.bucior.carrental.configuration.auth.Manager;
import pl.bucior.carrental.configuration.auth.TechnicalEmployee;
import pl.bucior.carrental.configuration.auth.User;
import pl.bucior.carrental.model.request.UserCreateRequest;
import pl.bucior.carrental.model.response.UserRoleResponse;
import pl.bucior.carrental.service.UserService;

import javax.validation.Valid;
import java.security.Principal;

@RestController
@RequiredArgsConstructor
@RequestMapping("user")
public class UserResource {
    private final UserService userService;


    @PostMapping(value = "/registration")
    @ApiOperation(value = "Registration ", notes = "Registration to this service. ")
    public ResponseEntity<Void> signIn(
            @RequestBody @Valid UserCreateRequest request
    ) {
        userService.create(request);
        return new ResponseEntity<>(HttpStatus.CREATED);
    }

    @GetMapping(value = "registrationConfirm")
    @ApiOperation(value = "Confirm registration ", notes = "Confirm registration to this service. ")
    public ResponseEntity<Void> confirmRegistration(@RequestParam(name = "token") String token) {
        userService.confirmRegistration(token);
        return new ResponseEntity<>(HttpStatus.OK);
    }

    @GetMapping(value = "checkRole")
    @ApiOperation(value = "Check role ", notes = "Get role to this service. ")
    public ResponseEntity<UserRoleResponse> getRole(Principal principal) {
        return ResponseEntity
                .status(HttpStatus.OK)
                .body(userService.checkRole(principal));

    }
}
