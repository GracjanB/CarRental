package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.model.jpa.Address;
import pl.bucior.carrental.model.jpa.Agency;
import pl.bucior.carrental.model.request.AgencyCreateRequest;
import pl.bucior.carrental.repository.AgencyRepository;

import javax.transaction.Transactional;

@Log4j2
@Service
@Transactional
@RequiredArgsConstructor
public class AgencyService {
    private final AgencyRepository agencyRepository;

    public void createAgency(AgencyCreateRequest request) {
        agencyRepository.save(Agency
                .builder()
                .maxCarQuantity(request.getMaxCarQuantity())
                .address(Address
                        .builder()
                        .street(request.getStreet())
                        .postalCode(request.getPostalCode())
                        .houseNo(request.getHouseNo())
                        .flatNo(request.getFlatNo())
                        .country(request.getCountry())
                        .city(request.getCity())
                        .build())
                .build());
    }

    public void deleteAgency(Long id) {
        agencyRepository.deleteById(id);
    }
}
