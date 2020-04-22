package pl.bucior.carrental.model.jpa;

import lombok.*;
import pl.bucior.carrental.model.enums.TechnicalSupportActionEnum;

import javax.persistence.*;
import java.io.Serializable;

@Entity
@Getter
@Setter
@Builder(toBuilder = true)
@AllArgsConstructor
@NoArgsConstructor
@Table(name = "technical_support_has_action", schema = "carrental")
public class TechnicalSupportHasAction extends AbstractBaseEntity implements Serializable {

    @Id
    @SequenceGenerator(name = "technical_support_has_action_id_seq", sequenceName = "technical_support_has_action_id_seq", allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "technical_support_has_action_id_seq")
    private Long id;

    @ManyToOne(cascade = CascadeType.PERSIST)
    @JoinColumn(name = "technical_support_id", referencedColumnName = "id")
    private TechnicalSupport technicalSupport;

    @Enumerated(EnumType.STRING)
    @Column(name = "technical_support_action", nullable = false)
    private TechnicalSupportActionEnum technicalSupportAction;

    @Column(name = "completed", nullable = false)
    private Boolean completed;

}
