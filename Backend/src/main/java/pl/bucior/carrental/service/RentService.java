package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.configuration.exception.ErrorCode;
import pl.bucior.carrental.configuration.exception.WsizException;
import pl.bucior.carrental.model.enums.RentStatus;
import pl.bucior.carrental.model.jpa.Car;
import pl.bucior.carrental.model.jpa.Rent;
import pl.bucior.carrental.model.jpa.User;
import pl.bucior.carrental.model.request.RentCreateRequest;
import pl.bucior.carrental.repository.CarRepository;
import pl.bucior.carrental.repository.RentRepository;
import pl.bucior.carrental.repository.UserRepository;

import javax.transaction.Transactional;
import java.security.Principal;
import java.util.ArrayList;
import java.util.List;

import static pl.bucior.carrental.configuration.exception.ErrorCode.*;

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
        User user = userRepository.findById(request.getUserId())
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, USER_NOT_FOUND));
        Car car = carRepository.findById(request.getCarVin())
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, ErrorCode.CAR_NOT_FOUND));
        List<RentStatus> rentStatusList = new ArrayList<>();
        rentStatusList.add(RentStatus.CANCELLED);
        rentStatusList.add(RentStatus.RETURNED);
        if (rentRepository.findByCarVinAndStatusNotIn(car.getVin(), rentStatusList).isPresent()) {
            throw new WsizException(HttpStatus.CONFLICT, CAR_IS_ALREADY_RENTED);
        }
        if (rentRepository.findByUserIdAndStatusNotIn(request.getUserId(), rentStatusList).isPresent()) {
            throw new WsizException(HttpStatus.CONFLICT, USER_HAS_OPENED_RENT);
        }
        Rent rent = Rent
                .builder()
                .employee(employee)
                .deposit(request.getDeposit())
                .user(user)
                .agency(car.getCurrentAgency())
                .targetAgencyId(request.getTargetAgencyId())
                .car(car)
                .carVin(request.getCarVin())
                .rentStartDate(request.getRentStartDate())
                .rentEndDate(request.getRentEndDate())
                .startMileage(request.getStartMileage())
                .status(RentStatus.CREATED)
                .build();
        rentRepository.save(rent);
        //TODO wysyłka maila z potwierdzeniem wynajmu???
    }

}
