package pl.bucior.carrental.model.dto;

import lombok.Data;

import java.io.Serializable;
import java.math.BigDecimal;

@Data
public class PriceListDto implements Serializable {

    private Long id;
    private BigDecimal dailyPrice;

}
