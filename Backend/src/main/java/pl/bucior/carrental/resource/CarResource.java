package pl.bucior.carrental.resource;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import pl.bucior.carrental.configuration.auth.Manager;
import pl.bucior.carrental.model.request.CarCreateRequest;
import pl.bucior.carrental.service.CarService;

import javax.validation.Valid;

@Log4j2
@RestController
@RequestMapping("car")
@RequiredArgsConstructor
public class CarResource {

    private final CarService carService;

    @Manager
    @PostMapping
    public ResponseEntity<Void> createCar(@RequestBody @Valid CarCreateRequest request) {
        carService.createCar(request);
        return ResponseEntity.status(HttpStatus.CREATED).build();
    }

}