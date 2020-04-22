package pl.bucior.carrental.model.request;

import lombok.Data;
import pl.bucior.carrental.model.enums.TechnicalSupportActionEnum;

import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import java.io.Serializable;
import java.math.BigDecimal;
import java.time.ZonedDateTime;
import java.util.List;

@Data
public class RentFinishRequest implements Serializable {
    @NotBlank
    private String vin;
    @NotNull
    private Integer endMileage;
    @NotNull
    private ZonedDateTime rentEndDate;
    @NotNull
    private BigDecimal finalPrice;
    private TechnicalSupport technicalSupport;

    @Data
    public static class TechnicalSupport {
        private List<TechnicalSupportActionEnum> technicalSupportActions;
        @NotNull
        private BigDecimal technicalSupportCost;
        private String comment;
    }
}
