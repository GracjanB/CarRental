--liquibase formatted sql

--changeset Pawel:1586468191376-19
ALTER TABLE agency
    DROP CONSTRAINT "UK_7vmqa8p2jsvct6baec7sjsiqy";

--changeset Pawel:1586468191376-20
ALTER TABLE users
    DROP CONSTRAINT "UK_hbvhqvjgmhd5omxyo67ynvbyp";

--changeset Pawel:1586468191376-11
ALTER TABLE users
    DROP CONSTRAINT UC_USERSEMAIL_COL;

--changeset Pawel:1586468191376-12
ALTER TABLE users
    ADD CONSTRAINT UC_USERSEMAIL_COL UNIQUE (email);

--changeset Pawel:1586468191376-13
ALTER TABLE users
    DROP CONSTRAINT UC_USERSID_CARD_NUMBER_COL;

--changeset Pawel:1586468191376-14
ALTER TABLE users
    ADD CONSTRAINT UC_USERSID_CARD_NUMBER_COL UNIQUE (id_card_number);

--changeset Pawel:1586468191376-15
ALTER TABLE users
    DROP CONSTRAINT UC_USERSPESEL_COL;

--changeset Pawel:1586468191376-16
ALTER TABLE users
    ADD CONSTRAINT UC_USERSPESEL_COL UNIQUE (pesel);

--changeset Pawel:1586468191376-17
ALTER TABLE technical_support
    DROP CONSTRAINT "UK_rfx102gmxw3pqmakxyoudr5ah";

--changeset Pawel:1586468191376-18
ALTER TABLE technical_support
    ADD CONSTRAINT "UK_rfx102gmxw3pqmakxyoudr5ah" UNIQUE (rent_id);

