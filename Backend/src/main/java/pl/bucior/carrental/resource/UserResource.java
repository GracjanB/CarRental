package pl.bucior.carrental.resource;

import io.swagger.annotations.ApiOperation;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import pl.bucior.carrental.model.request.UserChangePasswordRequest;
import pl.bucior.carrental.model.request.UserCreateRequest;
import pl.bucior.carrental.model.response.UserDetailsResponse;
import pl.bucior.carrental.model.response.UserRoleResponse;
import pl.bucior.carrental.service.UserService;
import springfox.documentation.annotations.ApiIgnore;

import javax.servlet.http.HttpServletRequest;
import javax.validation.Valid;
import java.security.Principal;

@RestController
@RequiredArgsConstructor
@RequestMapping("user")
public class UserResource {
    private final UserService userService;

    @PostMapping(value = "registration")
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

    @PostMapping(value = "passwordChange")
    @ApiOperation(value = "Change password", notes = "Change password to this service. ")
    public ResponseEntity<Void> changePassword(@RequestBody @Valid UserChangePasswordRequest request, @ApiIgnore Principal principal) {
        userService.changePassword(request, principal);
        return new ResponseEntity<>(HttpStatus.OK);
    }

    @GetMapping
    @ApiOperation(value = "Get user details")
    public ResponseEntity<UserDetailsResponse> getUserDetails(@ApiIgnore Principal principal) {
        return ResponseEntity
                .status(HttpStatus.OK)
                .body(userService.getUserDetails(principal));
    }

    @GetMapping(value = "checkRole")
    @ApiOperation(value = "Check role ", notes = "Get role to this service. ")
    public ResponseEntity<UserRoleResponse> getRole(@ApiIgnore Principal principal) {
        return ResponseEntity
                .status(HttpStatus.OK)
                .body(userService.checkRole(principal));

    }

    @DeleteMapping(value = "logout")
    @ApiOperation(value = "Logout", notes = "Logout from service. ")
    public ResponseEntity logout(@ApiIgnore HttpServletRequest request) {
        userService.logout(request);
        return ResponseEntity
                .status(HttpStatus.NO_CONTENT).build();

    }
}
