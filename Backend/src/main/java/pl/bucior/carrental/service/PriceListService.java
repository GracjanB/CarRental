package pl.bucior.carrental.service;

import lombok.RequiredArgsConstructor;
import lombok.extern.log4j.Log4j2;
import org.springframework.stereotype.Service;
import pl.bucior.carrental.model.jpa.PriceList;
import pl.bucior.carrental.model.request.PriceListCreateRequest;
import pl.bucior.carrental.model.response.PriceListCreateResponse;
import pl.bucior.carrental.repository.PriceListRepository;

import javax.transaction.Transactional;

@Log4j2
@Service
@Transactional
@RequiredArgsConstructor
public class PriceListService {
    private final PriceListRepository priceListRepository;

    public PriceListCreateResponse createPriceList(PriceListCreateRequest request) {
        PriceListCreateResponse response = new PriceListCreateResponse();
        response.setId(priceListRepository.save(PriceList
                .builder()
                .dailyPrice(request.getDailyPrice())
                .build()).getId());
        return response;
    }


}
