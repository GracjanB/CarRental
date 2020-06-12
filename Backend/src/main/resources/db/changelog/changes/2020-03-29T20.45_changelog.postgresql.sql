--liquibase formatted sql

--changeset Pawel:1585514752874-4
CREATE SEQUENCE IF NOT EXISTS address_id_seq;

--changeset Pawel:1585514752874-5
CREATE TABLE address
(
    id              BIGINT                      NOT NULL,
    creation_date   TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    update_date     TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    optlock_version BIGINT,
    city            VARCHAR(255)                NOT NULL,
    country         VARCHAR(255)                NOT NULL,
    flat_no         VARCHAR(255)                NOT NULL,
    house_no        VARCHAR(255)                NOT NULL,
    postal_code     VARCHAR(255)                NOT NULL,
    street          VARCHAR(255)                NOT NULL,
    CONSTRAINT "addressPK" PRIMARY KEY (id)
);

--changeset Pawel:1585514752874-6
CREATE TABLE car
(
    vin             VARCHAR(255)                NOT NULL,
    creation_date   TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    update_date     TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    optlock_version BIGINT,
    car_type        VARCHAR(255)                NOT NULL,
    car_version     VARCHAR(255)                NOT NULL,
    engine_power    INTEGER                     NOT NULL,
    horse_power     INTEGER                     NOT NULL,
    mark            VARCHAR(255)                NOT NULL,
    mileage         INTEGER                     NOT NULL,
    model           VARCHAR(255)                NOT NULL,
    register_plate  VARCHAR(255)                NOT NULL,
    CONSTRAINT "carPK" PRIMARY KEY (vin)
);

--changeset Pawel:1585514752874-7
ALTER TABLE users
    ADD address_id BIGINT not null;

--changeset Pawel:1585514752874-8
ALTER TABLE users
    ADD creation_date TIMESTAMP WITHOUT TIME ZONE NOT NULL;

--changeset Pawel:1585514752874-9
ALTER TABLE users
    ADD first_name VARCHAR(255) NOT NULL;

--changeset Pawel:1585514752874-10
ALTER TABLE users
    ADD id_card_number VARCHAR(255);

--changeset Pawel:1585514752874-11
ALTER TABLE users
    ADD last_name VARCHAR(255) NOT NULL;

--changeset Pawel:1585514752874-12
ALTER TABLE users
    ADD optlock_version BIGINT;

--changeset Pawel:1585514752874-13
ALTER TABLE users
    ADD pesel VARCHAR(255) NOT NULL;

--changeset Pawel:1585514752874-14
ALTER TABLE users
    ADD update_date TIMESTAMP WITHOUT TIME ZONE NOT NULL;

--changeset Pawel:1585514752874-15
ALTER TABLE users
    ADD CONSTRAINT "UK_hbvhqvjgmhd5omxyo67ynvbyp" UNIQUE (address_id);

--changeset Pawel:1585514752874-16
ALTER TABLE users
    ADD CONSTRAINT "FKditu6lr4ek16tkxtdsne0gxib" FOREIGN KEY (address_id) REFERENCES address (id);

--changeset Pawel:1585514752874-2
ALTER TABLE users
    DROP CONSTRAINT UC_USERSEMAIL_COL;

--changeset Pawel:1585514752874-3
ALTER TABLE users
    ADD CONSTRAINT UC_USERSEMAIL_COL UNIQUE (email);

