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
@RequestMapping("/user")
public class UserResource {
    private final UserService userService;


    @RequestMapping(value = "/sign-in", method = RequestMethod.POST)
    @ApiOperation(value = "Sign in ", notes = "Sign in to this service. ")
    public ResponseEntity<Void> signIn(
            @RequestBody @Valid UserCreateRequest request
    ) {
        userService.create(request);
        return new ResponseEntity<>(HttpStatus.CREATED);
    }
//
//    /**
//     * <p>
//     *     Metoda tworząca endpoint do wylogowywania z serwisu
//     * </p>
//     * @param request Dane requesta pobierane automatycznie
//     * @return Prawda jeśli wylogowano oraz kod 200
//     */
//    @RequestMapping(value = "/sign-out", method = RequestMethod.DELETE)
//    @ApiOperation(value = "Sign out ", notes = "Sign out from this service. ")
//    public ResponseEntity<Boolean> singOut(HttpServletRequest request) {
//        return ResponseEntity
//                .status(HttpStatus.OK)
//                .body(userService.deleteToken(request));
//    }
//
@GetMapping(value = "/checkRole")
@ApiOperation(value = "Check role ", notes = "Get role to this service. ")
public ResponseEntity<UserRoleResponse> getRole(Principal principal) {
    return ResponseEntity
            .status(HttpStatus.OK)
            .body(userService.checkRole(principal));

}
}
