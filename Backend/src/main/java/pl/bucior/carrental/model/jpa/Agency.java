package pl.bucior.carrental.model.jpa;

import lombok.*;

import javax.persistence.*;
import java.io.Serializable;

@Entity
@Getter
@Setter
@Builder(toBuilder = true)
@AllArgsConstructor
@NoArgsConstructor
@Table(name = "agency", schema = "carrental")
public class Agency extends AbstractBaseEntity implements Serializable {

    @Id
    @SequenceGenerator(name = "agency_id_seq", sequenceName = "agency_id_seq", allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "agency_id_seq")
    private Long id;

    @ManyToOne(optional = false, cascade = {CascadeType.PERSIST, CascadeType.MERGE, CascadeType.REMOVE})
    @JoinColumn(name = "address_id", referencedColumnName = "id")
    private Address address;

    @Column(name = "address_id", insertable = false, updatable = false)
    private Long addressId;

    @Column(name = "max_car_quantity", nullable = false)
    private Integer maxCarQuantity;
}
