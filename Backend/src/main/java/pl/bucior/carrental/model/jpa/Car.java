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

    @Column(name = "engine_power", nullable = false)
    private Integer enginePower;

    @Column(name = "register_plate", nullable = false)
    private String registerPlate;

//    private Long priceListId;

//    private Long parentAgencyId;

    @ManyToOne(fetch = FetchType.LAZY, optional = false, cascade = {CascadeType.PERSIST, CascadeType.MERGE})
    @JoinColumn(name = "current_agency_id", referencedColumnName = "id")
    private Agency currentAgency;

    @Column(name = "current_agency_id", insertable = false, updatable = false)
    private Long currentAgencyId;
}
