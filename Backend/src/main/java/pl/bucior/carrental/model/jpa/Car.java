package pl.bucior.carrental.model.jpa;

import lombok.*;
import pl.bucior.carrental.model.enums.CarType;

import javax.persistence.*;
import java.io.Serializable;

@Entity
@Getter
@Setter
@Builder(toBuilder = true)
@AllArgsConstructor
@NoArgsConstructor
@Table(name = "car", schema = "carrental")
public class Car extends AbstractBaseEntity implements Serializable {

    @Id
    private String vin;

    @Column(name = "mark", nullable = false)
    private String mark;

    @Column(name = "model", nullable = false)
    private String model;

    @Column(name = "car_version", nullable = false)
    private String carVersion;

    @Column(name = "car_type", nullable = false)
    @Enumerated(EnumType.STRING)
    private CarType carType;

    @Column(name = "mileage", nullable = false)
    private Integer mileage;

    @Column(name = "horse_power", nullable = false)
    private Integer horsePower;

    @Column(name = "engine_capacity", nullable = false)
    private Integer engineCapacity;

    @Column(name = "register_plate", nullable = false)
    private String registerPlate;

    @ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.DETACH, optional = false)
    @JoinColumn(name = "price_list_id", referencedColumnName = "id")
    private PriceList priceList;

    @Column(name = "price_list_id", insertable = false, updatable = false)
    private Long priceListId;

    @ManyToOne(fetch = FetchType.LAZY, optional = false, cascade = CascadeType.DETACH)
    @JoinColumn(name = "parent_agency_id", referencedColumnName = "id")
    private Agency parentAgency;

    @Column(name = "parent_agency_id", insertable = false, updatable = false)
    private Long parentAgencyId;

    @ManyToOne(fetch = FetchType.LAZY, optional = false, cascade = CascadeType.DETACH)
    @JoinColumn(name = "current_agency_id", referencedColumnName = "id")
    private Agency currentAgency;

    @Column(name = "current_agency_id", insertable = false, updatable = false)
    private Long currentAgencyId;

    private Boolean enabled;
}
