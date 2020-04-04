--liquibase formatted sql

--changeset Pawel:1586033073870-14
CREATE SEQUENCE  IF NOT EXISTS account_verification_token_id_seq;

--changeset Pawel:1586033073870-15
CREATE SEQUENCE  IF NOT EXISTS agency_has_user_id_seq;

--changeset Pawel:1586033073870-16
CREATE SEQUENCE  IF NOT EXISTS agency_id_seq;
