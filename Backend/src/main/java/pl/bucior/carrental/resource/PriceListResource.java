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
import pl.bucior.carrental.model.request.PriceListCreateRequest;
import pl.bucior.carrental.model.response.PriceListCreateResponse;
import pl.bucior.carrental.service.PriceListService;

import javax.validation.Valid;

@Log4j2
@RestController
@RequestMapping("priceList")
@RequiredArgsConstructor
public class PriceListResource {

    private final PriceListService priceListService;

    @Manager
    @PostMapping
    public ResponseEntity<PriceListCreateResponse> createPriceList(@RequestBody @Valid PriceListCreateRequest request) {
        return ResponseEntity.status(HttpStatus.CREATED).body(priceListService.createPriceList(request));
    }


}
