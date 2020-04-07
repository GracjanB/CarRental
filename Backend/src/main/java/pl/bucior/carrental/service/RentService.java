package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.configuration.exception.ErrorCode;
import pl.bucior.carrental.configuration.exception.WsizException;
import pl.bucior.carrental.model.jpa.Car;
import pl.bucior.carrental.model.jpa.Rent;
import pl.bucior.carrental.model.jpa.User;
import pl.bucior.carrental.model.request.RentCreateRequest;
import pl.bucior.carrental.repository.CarRepository;
import pl.bucior.carrental.repository.RentRepository;
import pl.bucior.carrental.repository.UserRepository;

import javax.transaction.Transactional;
import java.security.Principal;

@Log4j2
@Service
@Transactional
@RequiredArgsConstructor
public class RentService {
    private final RentRepository rentRepository;
    private final UserRepository userRepository;
    private final CarRepository carRepository;

    public void createRent(RentCreateRequest request, Principal principal) {
        User employee = userRepository.findByEmail(principal.getName()).orElseThrow(AssertionError::new);
        Car car = carRepository.findById(request.getCarVin())
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.CAR_NOT_FOUND));
        Rent rent = Rent
                .builder()
                .employee(employee)
                .deposit(request.getDeposit())
                .userId(request.getUserId())
                .agency(car.getCurrentAgency())
                .targetAgencyId(request.getTargetAgencyId())
                .car(car)
                .carVin(request.getCarVin())
                .rentStartDate(request.getRentStartDate())
                .rentEndDate(request.getRentEndDate())
                .startMileage(request.getStartMileage())
                .build();
        rentRepository.save(rent);
        //TODO wysyłka maila z potwierdzeniem wynajmu???
    }

}
