--liquibase formatted sql

--changeset Pawel:1585253038080-1
CREATE SEQUENCE  IF NOT EXISTS user_id_seq;

--changeset Pawel:1585253038080-2
CREATE TABLE users (id BIGINT NOT NULL, email VARCHAR(255) NOT NULL, password VARCHAR(255) NOT NULL, role VARCHAR(255) NOT NULL, salt VARCHAR(255) NOT NULL, CONSTRAINT "usersPK" PRIMARY KEY (id));

--changeset Pawel:1585253038080-3
ALTER TABLE users ADD CONSTRAINT UC_USERSEMAIL_COL UNIQUE (email);

