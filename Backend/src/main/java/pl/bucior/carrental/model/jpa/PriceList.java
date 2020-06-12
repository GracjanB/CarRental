package pl.bucior.carrental.model.jpa;

import lombok.*;

import javax.persistence.*;
import java.io.Serializable;
import java.math.BigDecimal;

@Entity
@Getter
@Setter
@Builder(toBuilder = true)
@AllArgsConstructor
@NoArgsConstructor
@Table(name = "price_list", schema = "carrental")
public class PriceList extends AbstractBaseEntity implements Serializable {
    @Id
    @SequenceGenerator(name = "price_list_id_seq", sequenceName = "price_list_id_seq", allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "price_list_id_seq")
    private Long id;

    @Column(name = "daily_price", nullable = false)
    private BigDecimal dailyPrice;

}
