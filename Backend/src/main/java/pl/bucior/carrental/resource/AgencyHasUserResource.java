package pl.bucior.carrental.resource;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import pl.bucior.carrental.model.request.HireEmployeeRequest;
import pl.bucior.carrental.service.AgencyHasUserService;

import javax.validation.Valid;

@Log4j2
@RestController
@RequestMapping("agencyHasUser")
@RequiredArgsConstructor
public class AgencyHasUserResource {

    private final AgencyHasUserService agencyHasUserService;

    //    @Manager
    @PostMapping("hire")
    public ResponseEntity hireEmployee(@RequestBody @Valid HireEmployeeRequest request) {
        agencyHasUserService.hireEmployee(request);
        return ResponseEntity.status(HttpStatus.OK).build();
    }

    //    @Manager
    @PostMapping("fire/{id}")
    public ResponseEntity fireEmployee(@PathVariable("id") Long userId) {
        agencyHasUserService.fireEmployee(userId);
        return ResponseEntity.status(HttpStatus.OK).build();
    }

}
