package pl.bucior.carrental.model.jpa;

import lombok.*;

import javax.persistence.*;
import java.time.ZonedDateTime;

@Entity
@Getter
@Setter
@Builder(toBuilder = true)
@AllArgsConstructor
@NoArgsConstructor
@Table(name = "account_verification_token", schema = "carrental")
public class AccountVerificationToken extends AbstractBaseEntity {

    private static final int EXPIRATION = 60 * 24;

    @Id
    @SequenceGenerator(name = "account_verification_token_id_seq", sequenceName = "account_verification_token_id_seq", allocationSize = 1)
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "account_verification_token_id_seq")
    private Long id;

    @Column(name = "token", nullable = false)
    private String token;

    @OneToOne(cascade = CascadeType.REMOVE)
    @JoinColumn(name = "user_id", nullable = false)
    private User user;

    @Column(name = "user_id", insertable = false, updatable = false)
    private Long userId;

    @Column(name = "expiration_time", nullable = false)
    private final ZonedDateTime expirationTime = ZonedDateTime.now().plusMinutes(EXPIRATION);

    @Column(name = "mail_sended", nullable = false)
    private Boolean mailSended = false;
}
