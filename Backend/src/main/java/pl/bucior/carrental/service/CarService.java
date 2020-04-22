package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.configuration.exception.WsizException;
import pl.bucior.carrental.mapper.CarMapper;
import pl.bucior.carrental.model.dto.CarDto;
import pl.bucior.carrental.model.enums.RentStatus;
import pl.bucior.carrental.model.jpa.Agency;
import pl.bucior.carrental.model.jpa.Car;
import pl.bucior.carrental.model.jpa.PriceList;
import pl.bucior.carrental.model.request.CarCreateRequest;
import pl.bucior.carrental.model.response.AvailableCarResponse;
import pl.bucior.carrental.repository.*;

import javax.transaction.Transactional;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

import static pl.bucior.carrental.configuration.exception.ErrorCode.*;

@Log4j2
@Service
@Transactional
@RequiredArgsConstructor
public class CarService {

    private final CarRepository carRepository;
    private final AgencyRepository agencyRepository;
    private final RentRepository rentRepository;
    private final PriceListRepository priceListRepository;
    private final TechnicalSupportRepository technicalSupportRepository;

    public void createCar(CarCreateRequest request) {
        Agency agency = agencyRepository.findById(request.getAgencyId())
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, AGENCY_NOT_FOUND));
        PriceList priceList = priceListRepository.findById(request.getPriceListId())
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, PRICE_LIST_NOT_FOUND));
        carRepository.save(Car
                .builder()
                .carType(request.getCarType())
                .carVersion(request.getCarVersion())
                .currentAgency(agency)
                .parentAgency(agency)
                .horsePower(request.getHorsePower())
                .mark(request.getMark())
                .mileage(request.getMileage())
                .model(request.getModel())
                .priceList(priceList)
                .registerPlate(request.getRegisterPlate())
                .vin(request.getVin())
                .engineCapacity(request.getEngineCapacity())
                .enabled(true)
                .build());
    }


    public AvailableCarResponse getAvailableCars() {
        AvailableCarResponse response = new AvailableCarResponse();
        List<Car> cars = carRepository.findAllByEnabledIsTrue();
        List<Car> rentedCars = rentRepository.findCarsWithOpenRent();
        List<Car> carsWithTechnicalSupport = technicalSupportRepository.findCarsWithOpenTechnicalSupport();
        cars.removeAll(rentedCars);
        cars.removeAll(carsWithTechnicalSupport);
        List<CarDto> carDtoList = cars.stream().map(CarMapper.INSTANCE::toDto).collect(Collectors.toList());
        response.setCars(carDtoList);
        return response;
    }

    public void disableCar(String vin) {
        log.info("disableCar - invoked for car with VIN = " + vin);
        Car car = carRepository.findById(vin)
                .orElseThrow(() -> new WsizException(HttpStatus.NOT_FOUND, CAR_NOT_FOUND));
        List<RentStatus> statuses = new ArrayList<>();
        statuses.add(RentStatus.RETURNED);
        statuses.add(RentStatus.CANCELLED);
        if (rentRepository.findByCarVinAndStatusNotIn(vin, statuses).isPresent()) {
            log.warn(String.format("Car with VIN = %s , has opened rent, cannot disable!", vin));
            throw new WsizException(HttpStatus.CONFLICT, CANNOT_DELETE_CAR_WITH_OPEN_RENT);
        }
        car.setEnabled(false);
        log.info(String.format("Car with VIN = %s has been disabled successfully", vin));
    }
}
