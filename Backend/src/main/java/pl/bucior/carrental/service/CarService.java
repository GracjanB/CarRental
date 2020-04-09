package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.configuration.exception.WsizException;
import pl.bucior.carrental.model.jpa.Agency;
import pl.bucior.carrental.model.jpa.Car;
import pl.bucior.carrental.model.jpa.PriceList;
import pl.bucior.carrental.model.request.CarCreateRequest;
import pl.bucior.carrental.repository.AgencyRepository;
import pl.bucior.carrental.repository.CarRepository;
import pl.bucior.carrental.repository.PriceListRepository;

import javax.transaction.Transactional;

import static pl.bucior.carrental.configuration.exception.ErrorCode.AGENCY_NOT_FOUND;
import static pl.bucior.carrental.configuration.exception.ErrorCode.PRICE_LIST_NOT_FOUND;

@Service
@Transactional
@RequiredArgsConstructor
public class CarService {

    private final CarRepository carRepository;
    private final AgencyRepository agencyRepository;
    private final PriceListRepository priceListRepository;

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
                .build());
    }

}
