--liquibase formatted sql

--changeset Pawel:1590907688783-20
CREATE SEQUENCE IF NOT EXISTS report_id_seq;

--changeset Pawel:1590907688783-21
CREATE TABLE report
(
    id              BIGINT                      NOT NULL,
    creation_date   TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    update_date     TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    optlock_version BIGINT,
    path            VARCHAR(255)                NOT NULL,
    report_type     VARCHAR(255)                NOT NULL,
    CONSTRAINT "reportPK" PRIMARY KEY (id)
);