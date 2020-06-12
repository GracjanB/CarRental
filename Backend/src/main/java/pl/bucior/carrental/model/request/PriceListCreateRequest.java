package pl.bucior.carrental.model.request;

import lombok.Data;

import javax.validation.constraints.NotNull;
import java.io.Serializable;
import java.math.BigDecimal;

@Data
public class PriceListCreateRequest implements Serializable {
    @NotNull
    private BigDecimal dailyPrice;
}
