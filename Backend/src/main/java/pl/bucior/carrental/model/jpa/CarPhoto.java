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
@Table(name = "car_photo", schema = "carrental")
public class CarPhoto implements Serializable {

    @Id
    @SequenceGenerator(name = "car_photo_id_seq", sequenceName = "car_photo_id_seq", allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "car_photo_id_seq")
    private Long id;

    @Column(name = "photo", nullable = false)
    private byte[] photo;
}
