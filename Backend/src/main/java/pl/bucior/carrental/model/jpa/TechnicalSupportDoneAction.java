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
@Table(name = "technical_support_has_action", schema = "carrental")
public class TechnicalSupportDoneAction extends AbstractBaseEntity implements Serializable {

    @Id
    @SequenceGenerator(name = "technical_support_done_action_id_seq", sequenceName = "technical_support_done_action_id_seq", allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "technical_support_done_action_id_seq")
    private Long id;

    @ManyToOne(optional = false, cascade = CascadeType.PERSIST)
    @JoinColumn(name = "technical_support_has_action_id")
    private TechnicalSupportHasAction technicalSupportHasAction;

    @ManyToOne
    @JoinColumn(name = "employee_id")
    private User employee;
}
