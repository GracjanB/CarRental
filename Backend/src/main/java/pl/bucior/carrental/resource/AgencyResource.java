package pl.bucior.carrental.resource;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import pl.bucior.carrental.configuration.auth.Manager;
import pl.bucior.carrental.model.request.AgencyCreateRequest;
import pl.bucior.carrental.service.AgencyService;

import javax.validation.Valid;

@Log4j2
@RestController
@RequestMapping("agency")
@RequiredArgsConstructor
public class AgencyResource {

    private final AgencyService agencyService;

    @Manager
    @PostMapping
    public ResponseEntity<Void> createAgency(@RequestBody @Valid AgencyCreateRequest request) {
        agencyService.createAgency(request);
        return ResponseEntity.status(HttpStatus.CREATED).build();
    }

    @Manager
    @DeleteMapping
    public ResponseEntity<Void> deleteAgency(@RequestParam("id") Long id) {
        agencyService.deleteAgency(id);
        return ResponseEntity.status(HttpStatus.NO_CONTENT).build();
    }
}

