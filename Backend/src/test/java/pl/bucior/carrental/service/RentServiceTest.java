package pl.bucior.carrental.service;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.springframework.context.ApplicationEventPublisher;
import pl.bucior.carrental.model.jpa.*;
import pl.bucior.carrental.model.request.RentCreateRequest;
import pl.bucior.carrental.model.request.RentExpectedCostRequest;
import pl.bucior.carrental.model.request.RentFinishRequest;
import pl.bucior.carrental.model.response.RentExpectedCostResponse;
import pl.bucior.carrental.repository.*;

import java.math.BigDecimal;
import java.security.Principal;
import java.time.ZonedDateTime;
import java.util.Optional;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.ArgumentMatchers.*;
import static org.mockito.Mockito.*;
import static org.mockito.MockitoAnnotations.initMocks;

class RentServiceTest {
    @InjectMocks
    private RentService rentService;

    @Mock
    private RentRepository rentRepository;
    @Mock
    private UserRepository userRepository;
    @Mock
    private CarRepository carRepository;
    @Mock
    private AgencyRepository agencyRepository;
    @Mock
    private TechnicalSupportRepository technicalSupportRepository;
    @Mock
    private TechnicalSupportHasActionRepository technicalSupportHasActionRepository;
    @Mock
    private AgencyHasUserRepository agencyHasUserRepository;
    @Mock
    private ApplicationEventPublisher applicationEventPublisher;
    @Mock
    private Principal principal;


    @BeforeEach
    void setUp() {
        initMocks(this);
    }

    @Test
    void createRent() {
        ZonedDateTime startDateTime = ZonedDateTime.now();
        ZonedDateTime endDateTime = ZonedDateTime.now().plusDays(7L);
        RentCreateRequest request = new RentCreateRequest();
        request.setCarVin("iudgnfiaufbaiusbfd");
        request.setDeposit(new BigDecimal(1000));
        request.setRentStartDate(startDateTime);
        request.setRentEndDate(endDateTime);
        request.setStartMileage(3213123);
        request.setTargetAgencyId(1L);
        request.setUserId(421312L);

        when(principal.getName()).thenReturn("admin@test.pl");
        when(userRepository.findByEmail(any())).thenReturn(java.util.Optional.ofNullable(User.builder().build()));
        when(userRepository.findById(anyLong())).thenReturn(java.util.Optional.ofNullable(User.builder().build()));
        when(carRepository.findById(anyString())).thenReturn(java.util.Optional.ofNullable(Car.builder()
                .priceList(PriceList.builder()
                        .dailyPrice(new BigDecimal(100))
                        .build())
                .build()));
        when(rentRepository.findByCarVinAndStatusNotIn(anyString(), anyList())).thenReturn(Optional.empty());
        when(agencyRepository.findById(anyLong())).thenReturn(Optional.ofNullable(Agency.builder().build()));
        rentService.createRent(request, principal);
        verify(rentRepository, times(1)).save(any());


    }

    @Test
    void finishRent() {
        RentFinishRequest request = new RentFinishRequest();
        request.setEndMileage(234131);
        request.setFinalPrice(new BigDecimal("989.99"));
        request.setRentEndDate(ZonedDateTime.now());
        request.setVin("uinaiunviusabnufans");

        when(rentRepository.findByCarVinAndStatusNotIn(anyString(), anyList())).thenReturn(Optional.ofNullable(
                Rent.builder().build()
        ));
        when(principal.getName()).thenReturn("admin@test.pl");
        when(userRepository.findByEmail(any())).thenReturn(java.util.Optional.ofNullable(User.builder().build()));
        when(agencyHasUserRepository.findByUserId(any())).thenReturn(Optional.ofNullable(AgencyHasUser.builder().build()));
        when(userRepository.findById(anyLong())).thenReturn(java.util.Optional.ofNullable(User.builder().build()));
        when(carRepository.findById(anyString())).thenReturn(java.util.Optional.ofNullable(Car.builder()
                .priceList(PriceList.builder()
                        .dailyPrice(new BigDecimal(100))
                        .build())
                .build()));
        try {
            rentService.finishRent(request, principal);
        } catch (Exception e) {
            fail();
        }
    }

    @Test
    void calculateExpectedCost() {
        ZonedDateTime startDateTime = ZonedDateTime.now();
        ZonedDateTime endDateTime = ZonedDateTime.now().plusDays(7L);
        when(carRepository.findById(anyString())).thenReturn(java.util.Optional.ofNullable(Car.builder()
                .priceList(PriceList.builder()
                        .dailyPrice(new BigDecimal(100))
                        .build())
                .build()));
        RentExpectedCostRequest rentExpectedCostRequest = new RentExpectedCostRequest();
        rentExpectedCostRequest.setCarVin("12kijoida");
        rentExpectedCostRequest.setRentEndDate(endDateTime);
        rentExpectedCostRequest.setRentStartDate(startDateTime);
        RentExpectedCostResponse rentExpectedCostResponse =
                rentService.calculateExpectedCost(rentExpectedCostRequest);
        assertEquals(new BigDecimal("665.00"), rentExpectedCostResponse.getCost());
    }
}