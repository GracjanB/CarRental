--liquibase formatted sql

--changeset Pawel:1587586105117-19
CREATE SEQUENCE IF NOT EXISTS technical_support_done_action_id_seq;

--changeset Pawel:1587586105117-20
CREATE SEQUENCE IF NOT EXISTS technical_support_has_action_id_seq;

--changeset Pawel:1587586105117-21
CREATE TABLE technical_support_has_action
(
    id                              BIGINT                      NOT NULL,
    creation_date                   TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    update_date                     TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    optlock_version                 BIGINT,
    completed                       BOOLEAN                     NOT NULL,
    technical_support_action        VARCHAR(255)                NOT NULL,
    employee_id                     BIGINT,
    technical_support_has_action_id BIGINT                      NOT NULL,
    technical_support_id            BIGINT,
    CONSTRAINT "technical_support_has_actionPK" PRIMARY KEY (id)
);

--changeset Pawel:1587586105117-22
ALTER TABLE technical_support_has_action
    ADD CONSTRAINT "FK22k91tlsclpk1xciomspy62lk" FOREIGN KEY (employee_id) REFERENCES users (id);

--changeset Pawel:1587586105117-23
ALTER TABLE technical_support_has_action
    ADD CONSTRAINT "FK35jpuxwxbkpawd8x0yg7pyegn" FOREIGN KEY (technical_support_has_action_id) REFERENCES technical_support_has_action (id);

--changeset Pawel:1587586105117-24
ALTER TABLE technical_support_has_action
    ADD CONSTRAINT "FKqufc9ey0u093h3d9ls7qd52n9" FOREIGN KEY (technical_support_id) REFERENCES technical_support (id);

--changeset Pawel:1587586105117-10
ALTER TABLE car
    ALTER COLUMN parent_agency_id DROP NOT NULL;

--changeset Pawel:1587586105117-11
ALTER TABLE users
    DROP CONSTRAINT UC_USERSEMAIL_COL;

--changeset Pawel:1587586105117-12
ALTER TABLE users
    ADD CONSTRAINT UC_USERSEMAIL_COL UNIQUE (email);

--changeset Pawel:1587586105117-13
ALTER TABLE users
    DROP CONSTRAINT UC_USERSID_CARD_NUMBER_COL;

--changeset Pawel:1587586105117-14
ALTER TABLE users
    ADD CONSTRAINT UC_USERSID_CARD_NUMBER_COL UNIQUE (id_card_number);

--changeset Pawel:1587586105117-15
ALTER TABLE users
    DROP CONSTRAINT UC_USERSPESEL_COL;

--changeset Pawel:1587586105117-16
ALTER TABLE users
    ADD CONSTRAINT UC_USERSPESEL_COL UNIQUE (pesel);

--changeset Pawel:1587586105117-17
ALTER TABLE technical_support
    DROP CONSTRAINT "UK_rfx102gmxw3pqmakxyoudr5ah";

--changeset Pawel:1587586105117-18
ALTER TABLE technical_support
    ADD CONSTRAINT "UK_rfx102gmxw3pqmakxyoudr5ah" UNIQUE (rent_id);

