--liquibase formatted sql

--changeset Pawel:1586122700615-17
CREATE SEQUENCE IF NOT EXISTS rent_id_seq;

--changeset Pawel:1586122700615-18
CREATE SEQUENCE IF NOT EXISTS technical_support_id_seq;

--changeset Pawel:1586122700615-19
CREATE TABLE rent
(
    id               BIGINT                      NOT NULL,
    creation_date    TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    update_date      TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    optlock_version  BIGINT,
    agency_id        BIGINT,
    calculated_price numeric(19, 2),
    car_vin          varchar(255),
    deposit          numeric(19, 2),
    employee_id      BIGINT,
    end_mileage      INTEGER,
    final_price      numeric(19, 2),
    rent_end_date    TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    rent_start_date  TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    start_mileage    INTEGER,
    status           VARCHAR(255)                NOT NULL,
    target_agency_id BIGINT,
    user_id          BIGINT,
    CONSTRAINT "rentPK" PRIMARY KEY (id)
);

--changeset Pawel:1586122700615-20
CREATE TABLE technical_support
(
    id              BIGINT                      NOT NULL,
    creation_date   TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    update_date     TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    optlock_version BIGINT,
    car_vin         VARCHAR(255),
    comment         VARCHAR(255),
    cost            numeric(19, 2)              NOT NULL,
    employee_id     BIGINT,
    rent_id         BIGINT,
    status          VARCHAR(255)                NOT NULL,
    CONSTRAINT "technical_supportPK" PRIMARY KEY (id)
);

--changeset Pawel:1586122700615-21
ALTER TABLE technical_support
    ADD CONSTRAINT "UK_rfx102gmxw3pqmakxyoudr5ah" UNIQUE (rent_id);

--changeset Pawel:1586122700615-22
ALTER TABLE rent
    ADD CONSTRAINT "FK6hkmanhhpnljo2c1etqqoupha" FOREIGN KEY (target_agency_id) REFERENCES agency (id);

--changeset Pawel:1586122700615-23
ALTER TABLE technical_support
    ADD CONSTRAINT "FK8vbegswrsmroy84il7i26a7cm" FOREIGN KEY (employee_id) REFERENCES users (id);

--changeset Pawel:1586122700615-24
ALTER TABLE rent
    ADD CONSTRAINT "FKct50ksblmxkqn8wbgph1voosj" FOREIGN KEY (employee_id) REFERENCES users (id);

--changeset Pawel:1586122700615-25
ALTER TABLE rent
    ADD CONSTRAINT "FKhppmevt9ea2wr4p48qy9l29tv" FOREIGN KEY (agency_id) REFERENCES agency (id);

--changeset Pawel:1586122700615-26
ALTER TABLE rent
    ADD CONSTRAINT "FKiunsk40im8en24qmir2ecujmu" FOREIGN KEY (user_id) REFERENCES users (id);

--changeset Pawel:1586122700615-27
ALTER TABLE rent
    ADD CONSTRAINT "FKl03x5h09wtqcymg87wgle1k2n" FOREIGN KEY (car_vin) REFERENCES car (vin);

--changeset Pawel:1586122700615-28
ALTER TABLE technical_support
    ADD CONSTRAINT "FKqxdqrr0crjexm8fxpv8y1in51" FOREIGN KEY (rent_id) REFERENCES rent (id);

--changeset Pawel:1586122700615-29
ALTER TABLE technical_support
    ADD CONSTRAINT "FKs5uguitm5iscdc5t5osoohh2e" FOREIGN KEY (car_vin) REFERENCES car (vin);


