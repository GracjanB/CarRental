package pl.bucior.carrental.resource;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;
import pl.bucior.carrental.configuration.auth.Employee;
import pl.bucior.carrental.configuration.auth.Manager;
import pl.bucior.carrental.model.enums.TechnicalSupportActionEnum;
import pl.bucior.carrental.model.request.RentCreateRequest;
import pl.bucior.carrental.model.request.RentFinishRequest;
import pl.bucior.carrental.service.RentService;
import springfox.documentation.annotations.ApiIgnore;

import java.security.Principal;
import java.util.ArrayList;
import java.util.EnumSet;
import java.util.List;

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

    @PreAuthorize("hasAnyRole('MANAGER','EMPLOYEE')")
    @GetMapping(value = "action")
    public ResponseEntity<List<TechnicalSupportActionEnum>> getActions() {
        return ResponseEntity.ok(new ArrayList<>(EnumSet.allOf(TechnicalSupportActionEnum.class)));
    }

    @PreAuthorize("hasAnyRole('MANAGER','EMPLOYEE')")
    @PostMapping("finish")
    public ResponseEntity<Void> finishRent(@RequestBody RentFinishRequest request, @ApiIgnore Principal principal) {
        rentService.finishRent(request, principal);
        return ResponseEntity.status(HttpStatus.OK).build();
    }


}
