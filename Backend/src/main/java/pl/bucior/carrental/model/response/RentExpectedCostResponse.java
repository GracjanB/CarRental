package pl.bucior.carrental.model.response;

import lombok.Data;

import java.io.Serializable;
import java.math.BigDecimal;

@Data
public class RentExpectedCostResponse implements Serializable {
    private BigDecimal cost;
}
