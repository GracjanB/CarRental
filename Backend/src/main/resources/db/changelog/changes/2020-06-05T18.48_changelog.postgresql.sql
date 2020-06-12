--liquibase formatted sql

--changeset Pawel:1591382929569-21
CREATE SEQUENCE IF NOT EXISTS car_photo_id_seq;

--changeset Pawel:1591382929569-22
CREATE TABLE car_photo
(
    id    BIGINT NOT NULL,
    photo BYTEA  NOT NULL,
    CONSTRAINT "car_photoPK" PRIMARY KEY (id)
);

--changeset Pawel:1591382929569-23
ALTER TABLE car
    ADD car_photo_id BIGINT;
