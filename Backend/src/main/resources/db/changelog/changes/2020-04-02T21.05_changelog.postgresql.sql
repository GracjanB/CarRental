--liquibase formatted sql

--changeset Pawel:1585861549515-14
CREATE TABLE account_verification_token
(
    id              BIGINT                      NOT NULL,
    creation_date   TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    update_date     TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    optlock_version BIGINT,
    expiration_time TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    mail_sended     BOOLEAN                     NOT NULL,
    token           VARCHAR(255)                NOT NULL,
    user_id         BIGINT,
    CONSTRAINT "account_verification_tokenPK" PRIMARY KEY (id)
);

--changeset Pawel:1585861549515-15
CREATE TABLE agency
(
    id               BIGINT                      NOT NULL,
    creation_date    TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    update_date      TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    optlock_version  BIGINT,
    address_id       BIGINT,
    max_car_quantity INTEGER                     NOT NULL,
    CONSTRAINT "agencyPK" PRIMARY KEY (id)
);

--changeset Pawel:1585861549515-16
CREATE TABLE agency_has_user
(
    id                  BIGINT                      NOT NULL,
    creation_date       TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    update_date         TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    optlock_version     BIGINT,
    agency_id           BIGINT,
    end_contract_time   TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    start_contract_time TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    user_id             BIGINT,
    CONSTRAINT "agency_has_userPK" PRIMARY KEY (id)
);

--changeset Pawel:1585861549515-17
ALTER TABLE car
    ADD current_agency_id BIGINT;

--changeset Pawel:1585861549515-18
ALTER TABLE users
    ADD is_active BOOLEAN NOT NULL default false;

--changeset Pawel:1585861549515-19
ALTER TABLE agency
    ADD CONSTRAINT "UK_7vmqa8p2jsvct6baec7sjsiqy" UNIQUE (address_id);

--changeset Pawel:1585861549515-20
ALTER TABLE agency_has_user
    ADD CONSTRAINT "FK38rwel8u2nc8npta5lg6jvd9s" FOREIGN KEY (user_id) REFERENCES users (id);

--changeset Pawel:1585861549515-21
ALTER TABLE car
    ADD CONSTRAINT "FK546osh7nx8rhlhpqpm0f2hqhe" FOREIGN KEY (current_agency_id) REFERENCES agency (id);

--changeset Pawel:1585861549515-22
ALTER TABLE agency_has_user
    ADD CONSTRAINT "FKb37fpj43lqdh8jad9nw3eqm5s" FOREIGN KEY (agency_id) REFERENCES agency (id);

--changeset Pawel:1585861549515-23
ALTER TABLE agency
    ADD CONSTRAINT "FKiqovy0gm1lebgwor5g2kdfcmk" FOREIGN KEY (address_id) REFERENCES address (id);

--changeset Pawel:1585861549515-24
ALTER TABLE account_verification_token
    ADD CONSTRAINT "FKpru848s0sv2csw4y6cye22gjs" FOREIGN KEY (user_id) REFERENCES users (id);

--changeset Pawel:1585861549515-6
ALTER TABLE users
    DROP CONSTRAINT UC_USERSEMAIL_COL;

--changeset Pawel:1585861549515-7
ALTER TABLE users
    ADD CONSTRAINT UC_USERSEMAIL_COL UNIQUE (email);

--changeset Pawel:1585861549515-8
ALTER TABLE users
    DROP CONSTRAINT UC_USERSID_CARD_NUMBER_COL;

--changeset Pawel:1585861549515-9
ALTER TABLE users
    ADD CONSTRAINT UC_USERSID_CARD_NUMBER_COL UNIQUE (id_card_number);

--changeset Pawel:1585861549515-10
ALTER TABLE users
    DROP CONSTRAINT UC_USERSPESEL_COL;

--changeset Pawel:1585861549515-11
ALTER TABLE users
    ADD CONSTRAINT UC_USERSPESEL_COL UNIQUE (pesel);

--changeset Pawel:1585861549515-12
ALTER TABLE users
    DROP CONSTRAINT "UK_hbvhqvjgmhd5omxyo67ynvbyp";

--changeset Pawel:1585861549515-13
ALTER TABLE users
    ADD CONSTRAINT "UK_hbvhqvjgmhd5omxyo67ynvbyp" UNIQUE (address_id);

