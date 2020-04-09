package pl.bucior.carrental.resource;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.bucior.carrental.configuration.auth.Employee;
import pl.bucior.carrental.configuration.auth.Manager;
import pl.bucior.carrental.model.request.RentCreateRequest;
import pl.bucior.carrental.service.RentService;
import springfox.documentation.annotations.ApiIgnore;

import java.security.Principal;

@Log4j2
@RestController
@RequiredArgsConstructor
@RequestMapping("rent")
public class RentResource {

    private final RentService rentService;

    @Manager
    @Employee
    @PostMapping
    public ResponseEntity<Void> createRent(@RequestBody RentCreateRequest request, @ApiIgnore Principal principal) {
        rentService.createRent(request, principal);
        return ResponseEntity.status(HttpStatus.CREATED).build();
    }

}
