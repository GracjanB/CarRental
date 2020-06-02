--liquibase formatted sql

--changeset Pawel:1591128574163-21
ALTER TABLE report
    ADD CONSTRAINT UC_REPORTPATH_COL UNIQUE (path);
