--liquibase formatted sql

--changeset Pawel:1586644867954-19
ALTER TABLE car
    ADD enabled BOOLEAN;
