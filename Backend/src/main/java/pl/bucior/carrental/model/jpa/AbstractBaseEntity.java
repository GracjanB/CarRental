package pl.bucior.carrental.model.jpa;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.experimental.SuperBuilder;

import javax.persistence.*;
import java.io.Serializable;
import java.time.ZonedDateTime;

@NoArgsConstructor
@Getter
@Setter
@MappedSuperclass
@SuperBuilder
public abstract class AbstractBaseEntity implements Serializable {

    @Column(name = "creation_date", nullable = false)
    protected ZonedDateTime creationDate;

    @Column(name = "update_date", nullable = false)
    protected ZonedDateTime updateDate;

    @Version
    @Column(name = "optlock_version")
    protected Long version;

    @PrePersist
    protected void prePersist() {
        creationDate = ZonedDateTime.now();
        updateDate = ZonedDateTime.now();
    }

    @PreUpdate
    protected void preUpdate() {
        updateDate = ZonedDateTime.now();
    }

}

