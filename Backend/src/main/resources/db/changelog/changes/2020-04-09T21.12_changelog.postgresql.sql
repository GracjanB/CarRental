--liquibase formatted sql

--changeset Pawel:1586466780602-21
CREATE SEQUENCE IF NOT EXISTS price_list_id_seq;

--changeset Pawel:1586466780602-22
CREATE TABLE price_list
(
    id              BIGINT                      NOT NULL,
    creation_date   TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    update_date     TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    optlock_version BIGINT,
    daily_price     numeric(19, 2)              NOT NULL,
    CONSTRAINT "price_listPK" PRIMARY KEY (id)
);

--changeset Pawel:1586466780602-23
ALTER TABLE car
    ADD engine_capacity INTEGER NOT NULL;

--changeset Pawel:1586466780602-24
ALTER TABLE car
    ADD parent_agency_id BIGINT NOT NULL;

--changeset Pawel:1586466780602-26
ALTER TABLE car
    ADD price_list_id BIGINT;

--changeset Pawel:1586466780602-27
ALTER TABLE car
    ADD CONSTRAINT "UK_b6s9vwuh9wwpx533ajldccc8r" UNIQUE (parent_agency_id);

--changeset Pawel:1586466780602-28
ALTER TABLE car
    ADD CONSTRAINT "UK_h2xwelejeo4qtadg13iya3exq" UNIQUE (current_agency_id);

--changeset Pawel:1586466780602-29
ALTER TABLE car
    ADD CONSTRAINT "UK_h9s2h9nn5ep1pqidvcsm0la43" UNIQUE (price_list_id);

--changeset Pawel:1586466780602-30
ALTER TABLE car
    ADD CONSTRAINT "FK5wqw6yv6lsvf90yoofl61iahm" FOREIGN KEY (parent_agency_id) REFERENCES agency (id);

--changeset Pawel:1586466780602-31
ALTER TABLE car
    ADD CONSTRAINT "FKcs8wmau8dhfh9p1kw60f68k2n" FOREIGN KEY (price_list_id) REFERENCES price_list (id);

--changeset Pawel:1586466780602-36
ALTER TABLE car
    DROP COLUMN engine_power;

