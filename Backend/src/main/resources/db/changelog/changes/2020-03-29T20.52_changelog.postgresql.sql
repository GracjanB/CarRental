--liquibase formatted sql

--changeset Pawel:1585515156811-9
ALTER TABLE users
    ADD CONSTRAINT UC_USERSID_CARD_NUMBER_COL UNIQUE (id_card_number);

--changeset Pawel:1585515156811-10
ALTER TABLE users
    ADD CONSTRAINT UC_USERSPESEL_COL UNIQUE (pesel);

--changeset Pawel:1585515156811-4
ALTER TABLE users
    ALTER COLUMN id_card_number SET NOT NULL;

--changeset Pawel:1585515156811-5
ALTER TABLE users
    DROP CONSTRAINT UC_USERSEMAIL_COL;

--changeset Pawel:1585515156811-6
ALTER TABLE users
    ADD CONSTRAINT UC_USERSEMAIL_COL UNIQUE (email);

--changeset Pawel:1585515156811-7
ALTER TABLE users
    DROP CONSTRAINT "UK_hbvhqvjgmhd5omxyo67ynvbyp";

--changeset Pawel:1585515156811-8
ALTER TABLE users
    ADD CONSTRAINT "UK_hbvhqvjgmhd5omxyo67ynvbyp" UNIQUE (address_id);

