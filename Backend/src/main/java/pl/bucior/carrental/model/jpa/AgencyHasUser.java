package pl.bucior.carrental.model.jpa;


import lombok.*;

import javax.persistence.*;
import java.io.Serializable;
import java.time.ZonedDateTime;

@Entity
@Getter
@Setter
@Builder(toBuilder = true)
@AllArgsConstructor
@NoArgsConstructor
@Table(name = "agency_has_user", schema = "carrental")
public class AgencyHasUser extends AbstractBaseEntity implements Serializable {

    @Id
    @SequenceGenerator(name = "agency_has_user_id_seq", sequenceName = "agency_has_user_id_seq", allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "agency_has_user_id_seq")
    private Long id;

    @ManyToOne(optional = false)
    @JoinColumn(name = "agency_id", referencedColumnName = "id")
    private Agency agency;

    @Column(name = "agency_id", insertable = false, updatable = false)
    private Long agencyId;

    @OneToOne
    @JoinColumn(name = "user_id", referencedColumnName = "id")
    private User user;

    @Column(name = "user_id", insertable = false, updatable = false)
    private Long userId;

    @Column(name = "start_contract_time", nullable = false)
    private ZonedDateTime startContractTime = ZonedDateTime.now(); //DEFAULT VALUE

    @Column(name = "end_contract_time", nullable = false)
    private ZonedDateTime endContractTime = ZonedDateTime.now().plusMonths(1L); //DEFAULT VALUE
}
