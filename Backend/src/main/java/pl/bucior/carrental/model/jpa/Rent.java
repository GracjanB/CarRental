package pl.bucior.carrental.model.jpa;

import lombok.*;
import pl.bucior.carrental.model.enums.RentStatus;

import javax.persistence.*;
import java.io.Serializable;
import java.math.BigDecimal;
import java.time.ZonedDateTime;

@Entity
@Getter
@Setter
@Builder(toBuilder = true)
@AllArgsConstructor
@NoArgsConstructor
@Table(name = "rent", schema = "carrental")
public class Rent extends AbstractBaseEntity implements Serializable {

    @Id
    @SequenceGenerator(name = "rent_id_seq", sequenceName = "rent_id_seq", allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "rent_id_seq")
    private Long id;

    @ManyToOne(optional = false)
    @JoinColumn(name = "user_id", referencedColumnName = "id")
    private User user;

    @Column(name = "user_id", insertable = false, updatable = false)
    private Long userId;

    @ManyToOne(optional = true, cascade = CascadeType.DETACH)
    @JoinColumn(name = "car_vin", referencedColumnName = "vin")
    private Car car;

    @Column(name = "car_vin", insertable = false, updatable = false)
    private String carVin;

    @ManyToOne(optional = false)
    @JoinColumn(name = "agency_id", referencedColumnName = "id")
    private Agency agency;

    @Column(name = "agency_id", insertable = false, updatable = false)
    private Long agencyId;

    @ManyToOne(optional = false)
    @JoinColumn(name = "target_agency_id", referencedColumnName = "id")
    private Agency targetAgency;

    @Column(name = "target_agency_id", insertable = false, updatable = false)
    private Long targetAgencyId;

    @ManyToOne(optional = false)
    @JoinColumn(name = "employee_id", referencedColumnName = "id")
    private User employee;

    @Column(name = "employee_id", insertable = false, updatable = false)
    private Long employeeId;

    @Column(name = "rent_start_date", nullable = false)
    private ZonedDateTime rentStartDate;

    @Column(name = "rent_end_date", nullable = false)
    private ZonedDateTime rentEndDate;

    @Column(name = "start_mileage")
    private Integer startMileage;

    @Column(name = "end_mileage")
    private Integer endMileage;

    @Column(name = "deposit")
    private BigDecimal deposit;

    @Column(name = "calculated_price")
    private BigDecimal calculatedPrice;

    @Column(name = "final_price")
    private BigDecimal finalPrice;

    @Enumerated(EnumType.STRING)
    @Column(name = "status", nullable = false)
    private RentStatus status;
}

