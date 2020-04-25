--liquibase formatted sql

--changeset Pawel:1587822254552-11
ALTER TABLE address
    ALTER COLUMN flat_no DROP NOT NULL;

