--liquibase formatted sql

--changeset Pawel:1591206032813-24
ALTER TABLE report
    ADD user_id BIGINT NOT NULL;
