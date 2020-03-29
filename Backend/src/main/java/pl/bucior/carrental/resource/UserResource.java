package pl.bucior.carrental.resource;

import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import pl.bucior.carrental.model.request.UserCreateRequest;
import pl.bucior.carrental.service.UserService;

import javax.servlet.http.HttpServletRequest;
import javax.validation.Valid;
import java.security.Principal;

@RestController
@RequiredArgsConstructor
@RequestMapping("/user")
public class UserResource {
    private final UserService userService;


    @RequestMapping(value = "/sign-in", method = RequestMethod.POST)
//    @ApiOperation(value = "Sign in ", notes = "Sign in to this service. ")
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
//    /**
//     * <p>
//     *     Metoda tworząca endpoint do sprawdzenia czy użytkownik jest adminem
//     * </p>
//     * @param principal Informacje o użytkowniku pobierane automatycznie
//     * @return prawda jeśli jest adminem oraz kod 200
//     */
//    @RequestMapping(value = "/isadmin", method = RequestMethod.POST)
//    @ApiOperation(value = "Get role ", notes = "Get role to this service. ")
//    public ResponseEntity<Boolean> getRole(Principal principal) {
//        return ResponseEntity
//                .status(HttpStatus.OK)
//                .body(userService.isAdmin(principal));
//
//    }
}
