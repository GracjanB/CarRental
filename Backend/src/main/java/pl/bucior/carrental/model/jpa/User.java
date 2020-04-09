package pl.bucior.carrental.model.jpa;

import lombok.*;
import pl.bucior.carrental.model.enums.Role;

import javax.persistence.*;
import java.io.Serializable;

@Entity
@Getter
@Setter
@Builder(toBuilder = true)
@AllArgsConstructor
@NoArgsConstructor
@Table(name = "users", schema = "carrental")
public class User extends AbstractBaseEntity implements Serializable {

    @Id
    @SequenceGenerator(name = "user_id_seq", sequenceName = "user_id_seq", allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "user_id_seq")
    private Long id;

    @Column(name = "email", nullable = false, unique = true)
    private String email;

    @Column(name = "password", nullable = false)
    private String password;

    @Column(name = "salt", nullable = false)
    private String salt;

    @Column(name = "role", nullable = false)
    @Enumerated(EnumType.STRING)
    private Role role;

    @Column(name = "first_name", nullable = false)
    private String firstName;

    @Column(name = "last_name", nullable = false)
    private String lastName;

    @Column(name = "pesel", unique = true, nullable = false)
    private String pesel;

    @Column(name = "id_card_number", unique = true, nullable = false)
    private String idCardNumber;

    @ManyToOne(fetch = FetchType.LAZY, cascade = {CascadeType.PERSIST, CascadeType.MERGE, CascadeType.REMOVE}, optional = false)
    @JoinColumn(name = "address_id", referencedColumnName = "id")
    private Address address;

    @Column(name = "address_id", nullable = false, insertable = false, updatable = false)
    private Long addressId;

    @Column(name = "is_active", nullable = false)
    private Boolean isActive = false;
}
