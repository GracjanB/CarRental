package pl.bucior.carrental.model.jpa;

import lombok.*;
import pl.bucior.carrental.model.enums.ReportType;

import javax.persistence.*;
import java.io.Serializable;

@Entity
@Getter
@Setter
@Builder(toBuilder = true)
@AllArgsConstructor
@NoArgsConstructor
@Table(name = "report", schema = "carrental")
public class Report extends AbstractBaseEntity implements Serializable {

    @Id
    @SequenceGenerator(name = "report_id_seq", sequenceName = "report_id_seq", allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "report_id_seq")
    private Long id;

    @Column(name = "path", nullable = false, unique = true)
    private String path;

    @Enumerated(EnumType.STRING)
    @Column(name = "report_type", nullable = false)
    private ReportType reportType;
}

