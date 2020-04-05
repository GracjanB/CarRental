package pl.bucior.carrental.model.jpa;


import lombok.*;
import pl.bucior.carrental.model.enums.TechnicalSupportStatus;

import javax.persistence.*;
import java.io.Serializable;
import java.math.BigDecimal;

@Entity
@Getter
@Setter
@Builder(toBuilder = true)
@AllArgsConstructor
@NoArgsConstructor
@Table(name = "technical_support", schema = "carrental")
public class TechnicalSupport extends AbstractBaseEntity implements Serializable {

    @Id
    @SequenceGenerator(name = "technical_support_id_seq", sequenceName = "technical_support_id_seq", allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "technical_support_id_seq")
    private Long id;

    @OneToOne(optional = false)
    @JoinColumn(name = "rent_id", referencedColumnName = "id")
    private Rent rent;

    @Column(name = "rent_id", insertable = false, updatable = false)
    private Long rentId;

    @ManyToOne(optional = false)
    @JoinColumn(name = "employee_id", referencedColumnName = "id")
    private User employee;

    @Column(name = "employee_id", insertable = false, updatable = false)
    private Long employeeId;

    @ManyToOne(optional = false)
    @JoinColumn(name = "car_vin", referencedColumnName = "vin")
    private Car car;

    @Column(name = "car_vin", insertable = false, updatable = false)
    private String carVin;

    @Column(name = "cost", nullable = false)
    private BigDecimal cost;

    @Column(name = "comment")
    private String comment;

    @Enumerated(EnumType.STRING)
    @Column(name = "status", nullable = false)
    private TechnicalSupportStatus status;
}
