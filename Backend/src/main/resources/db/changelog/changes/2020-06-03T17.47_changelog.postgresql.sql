--liquibase formatted sql

--changeset Pawel:1591206447141-22
ALTER TABLE report
    DROP CONSTRAINT uc_reportpath_col;

--changeset Pawel:1591206447141-13
ALTER TABLE report
    ALTER COLUMN path DROP NOT NULL;