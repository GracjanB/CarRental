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
@Table(name = "address", schema = "carrental")
public class Address extends AbstractBaseEntity implements Serializable {

    @Id
    @SequenceGenerator(name = "address_id_seq", sequenceName = "address_id_seq", allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "address_id_seq")
    private Long id;

    @Column(name = "country", nullable = false)
    private String country;

    @Column(name = "city", nullable = false)
    private String city;

    @Column(name = "postal_code", nullable = false)
    private String postalCode;

    @Column(name = "street", nullable = false)
    private String street;

    @Column(name = "house_no", nullable = false)
    private String houseNo;

    @Column(name = "flat_no")
    private String flatNo;


    public String getAddressLine() {
        return String.format("%s, %s %s%s",
                this.getCity(),
                this.getStreet(),
                this.getHouseNo(),
                this.getFlatNo() != null ? "/" +
                        this.getFlatNo() : "");
    }
}
