package pl.bucior.carrental.service;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import pl.bucior.carrental.model.request.AgencyCreateRequest;
import pl.bucior.carrental.repository.AgencyRepository;

import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.times;
import static org.mockito.Mockito.verify;
import static org.mockito.MockitoAnnotations.initMocks;


class AgencyServiceTest {

    @InjectMocks
    private AgencyService agencyService;

    @Mock
    private AgencyRepository agencyRepository;

    @BeforeEach
    void setUp() {
        initMocks(this);
    }

    @Test
    void createAgency() {
        AgencyCreateRequest agencyCreateRequest = new AgencyCreateRequest();
        agencyCreateRequest.setCity("tes");
        agencyCreateRequest.setCountry("PL");
        agencyCreateRequest.setFlatNo("1");
        agencyCreateRequest.setHouseNo("2");
        agencyCreateRequest.setMaxCarQuantity(321);
        agencyCreateRequest.setPostalCode("23-123");
        agencyCreateRequest.setStreet("Strumykowa");
        agencyService.createAgency(agencyCreateRequest);
        verify(agencyRepository, times(1)).save(any());
    }

    @Test
    void deleteAgency() {
        agencyService.deleteAgency(1L);
        verify(agencyRepository, times(1)).deleteById(1L);
    }
}