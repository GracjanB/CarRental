package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.context.ApplicationEventPublisher;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.configuration.exception.ErrorCode;
import pl.bucior.carrental.configuration.exception.WsizException;
import pl.bucior.carrental.model.enums.RentStatus;
import pl.bucior.carrental.model.enums.Role;
import pl.bucior.carrental.model.enums.TechnicalSupportStatus;
import pl.bucior.carrental.model.jpa.*;
import pl.bucior.carrental.model.message.TechnicalSupportMessage;
import pl.bucior.carrental.model.request.RentCreateRequest;
import pl.bucior.carrental.model.request.RentExpectedCostRequest;
import pl.bucior.carrental.model.request.RentFinishRequest;
import pl.bucior.carrental.model.response.RentExpectedCostResponse;
import pl.bucior.carrental.repository.*;
import pl.bucior.carrental.service.event.EmailEvent;

import javax.transaction.Transactional;
import java.math.BigDecimal;
import java.math.RoundingMode;
import java.security.Principal;
import java.time.ZonedDateTime;
import java.time.temporal.ChronoUnit;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

import static pl.bucior.carrental.configuration.exception.ErrorCode.*;

@Log4j2
@Service
@Transactional
@RequiredArgsConstructor
public class RentService {
    private final RentRepository rentRepository;
    private final UserRepository userRepository;
    private final CarRepository carRepository;
    private final AgencyRepository agencyRepository;
    private final TechnicalSupportRepository technicalSupportRepository;
    private final TechnicalSupportHasActionRepository technicalSupportHasActionRepository;
    private final AgencyHasUserRepository agencyHasUserRepository;
    private final ApplicationEventPublisher applicationEventPublisher;

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
        if (technicalSupportRepository.findAllByCarVinAndStatusIsNot(request.getCarVin(), TechnicalSupportStatus.ENDED).size() > 0) {
            throw new WsizException(HttpStatus.CONFLICT, CAR_HAS_OPENED_TECHNICAL_SUPPORT);
        }
        if (rentRepository.findByUserIdAndStatusNotIn(request.getUserId(), rentStatusList).isPresent()) {
            throw new WsizException(HttpStatus.CONFLICT, USER_HAS_OPENED_RENT);
        }
        Agency targetAgency = agencyRepository.findById(request.getTargetAgencyId())
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, AGENCY_NOT_FOUND));
        BigDecimal calculatedPrice = BigDecimal.valueOf(zonedDateTimeDifference(request.getRentStartDate(), request.getRentEndDate(), ChronoUnit.DAYS));
        calculatedPrice = calculateBonus(calculatedPrice);
        calculatedPrice = calculatedPrice.multiply(car.getPriceList().getDailyPrice());

        Rent rent = Rent
                .builder()
                .employee(employee)
                .deposit(request.getDeposit())
                .user(user)
                .agency(car.getCurrentAgency())
                .targetAgency(targetAgency)
                .car(car)
                .carVin(request.getCarVin())
                .rentStartDate(request.getRentStartDate())
                .rentEndDate(request.getRentEndDate())
                .calculatedPrice(calculatedPrice)
                .startMileage(request.getStartMileage())
                .status(RentStatus.CREATED)
                .build();
        rentRepository.save(rent);

        //TODO wysyłka maila z potwierdzeniem wynajmu???
    }

    private long zonedDateTimeDifference(ZonedDateTime d1, ZonedDateTime d2, ChronoUnit unit) {
        return unit.between(d1, d2);
    }

    private BigDecimal calculateBonus(BigDecimal daysValue) {
        BigDecimal bonus = daysValue.divide(BigDecimal.valueOf(7L), RoundingMode.DOWN);
        if (bonus.compareTo(BigDecimal.ONE) >= 0) {
            daysValue = daysValue.multiply(BigDecimal.valueOf(0.95));
        } else if (bonus.compareTo(BigDecimal.valueOf(2L)) >= 0) {
            daysValue = daysValue.multiply(BigDecimal.valueOf(0.90));
        } else if (bonus.compareTo(BigDecimal.valueOf(4L)) >= 0) {
            daysValue = daysValue.multiply(BigDecimal.valueOf(0.75));
        }
        return daysValue;
    }

    public void finishRent(RentFinishRequest request, Principal principal) {
        List<RentStatus> rentStatusList = new ArrayList<>();
        rentStatusList.add(RentStatus.CANCELLED);
        rentStatusList.add(RentStatus.RETURNED);
        Car car = carRepository.findById(request.getVin())
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, CAR_NOT_FOUND));
        Rent rent = rentRepository.findByCarVinAndStatusNotIn(request.getVin(), rentStatusList)
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, RENT_NOT_FOUND));
        User employee = userRepository.findByEmail(principal.getName())
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, USER_NOT_FOUND));
        AgencyHasUser agencyHasUser = agencyHasUserRepository.findByUserId(employee.getId())
                .orElseThrow(() -> new WsizException(HttpStatus.CONFLICT, USER_IS_NOT_EMPLOYEE));
        rent.setFinalPrice(request.getFinalPrice());
        rent.setEndMileage(request.getEndMileage());
        rent.setRentEndDate(request.getRentEndDate() != null ? request.getRentEndDate() : rent.getRentEndDate());
        rent.setStatus(RentStatus.RETURNED);
        car.setCurrentAgency(agencyHasUser.getAgency());
        if (request.getTechnicalSupport() != null &&
                request.getTechnicalSupport().getTechnicalSupportActions() != null &&
                request.getTechnicalSupport().getTechnicalSupportActions().size() > 0) {
            TechnicalSupport technicalSupport = technicalSupportRepository.save(TechnicalSupport
                    .builder()
                    .rent(rent)
                    .employee(employee)
                    .car(car)
                    .status(TechnicalSupportStatus.CREATED)
                    .cost(request.getTechnicalSupport().getTechnicalSupportCost())
                    .comment(request.getTechnicalSupport().getComment())
                    .build());
            request.getTechnicalSupport().getTechnicalSupportActions()
                    .forEach(tcha -> {
                        technicalSupportHasActionRepository.save(TechnicalSupportHasAction
                                .builder()
                                .completed(false)
                                .technicalSupport(technicalSupport)
                                .technicalSupportAction(tcha)
                                .build());
                    });
            TechnicalSupportMessage technicalSupportMessage = new TechnicalSupportMessage();
            technicalSupportMessage.setEmails(userRepository.findAllByRole(Role.TECHNICAL_EMPLOYEE)
                    .stream().map(User::getEmail).collect(Collectors.toList()));
            technicalSupportMessage.setRegisterPlate(car.getRegisterPlate());
            technicalSupportMessage.setAddress(String.format("%s, %s %s%s",
                    agencyHasUser.getAgency().getAddress().getCity(),
                    agencyHasUser.getAgency().getAddress().getStreet(),
                    agencyHasUser.getAgency().getAddress().getHouseNo(),
                    agencyHasUser.getAgency().getAddress().getFlatNo() != null ? "/" +
                            agencyHasUser.getAgency().getAddress().getFlatNo() : ""));
            applicationEventPublisher.publishEvent(new EmailEvent(technicalSupportMessage));
        }
    }

    public RentExpectedCostResponse calculateExpectedCost(RentExpectedCostRequest request) {
        Car car = carRepository.findById(request.getCarVin())
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, CAR_NOT_FOUND));

        BigDecimal calculatedPrice = BigDecimal.valueOf(zonedDateTimeDifference(request.getRentStartDate(), request.getRentEndDate(), ChronoUnit.DAYS));
        calculatedPrice = calculateBonus(calculatedPrice);
        calculatedPrice = calculatedPrice.multiply(car.getPriceList().getDailyPrice());

        RentExpectedCostResponse rentExpectedCostResponse = new RentExpectedCostResponse();
        rentExpectedCostResponse.setCost(calculatedPrice);
        return rentExpectedCostResponse;
    }

}
