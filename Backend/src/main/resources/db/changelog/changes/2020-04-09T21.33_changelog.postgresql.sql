--liquibase formatted sql

--changeset Pawel:1586468000284-23
ALTER TABLE car
    DROP CONSTRAINT "UK_b6s9vwuh9wwpx533ajldccc8r";

--changeset Pawel:1586468000284-24
ALTER TABLE car
    DROP CONSTRAINT "UK_h2xwelejeo4qtadg13iya3exq";

--changeset Pawel:1586468000284-25
ALTER TABLE car
    DROP CONSTRAINT "UK_h9s2h9nn5ep1pqidvcsm0la43";

--changeset Pawel:1586468000284-11
ALTER TABLE users
    DROP CONSTRAINT UC_USERSEMAIL_COL;

--changeset Pawel:1586468000284-12
ALTER TABLE users
    ADD CONSTRAINT UC_USERSEMAIL_COL UNIQUE (email);

--changeset Pawel:1586468000284-13
ALTER TABLE users
    DROP CONSTRAINT UC_USERSID_CARD_NUMBER_COL;

--changeset Pawel:1586468000284-14
ALTER TABLE users
    ADD CONSTRAINT UC_USERSID_CARD_NUMBER_COL UNIQUE (id_card_number);

--changeset Pawel:1586468000284-15
ALTER TABLE users
    DROP CONSTRAINT UC_USERSPESEL_COL;

--changeset Pawel:1586468000284-16
ALTER TABLE users
    ADD CONSTRAINT UC_USERSPESEL_COL UNIQUE (pesel);

--changeset Pawel:1586468000284-17
ALTER TABLE agency
    DROP CONSTRAINT "UK_7vmqa8p2jsvct6baec7sjsiqy";

--changeset Pawel:1586468000284-18
ALTER TABLE agency
    ADD CONSTRAINT "UK_7vmqa8p2jsvct6baec7sjsiqy" UNIQUE (address_id);

--changeset Pawel:1586468000284-19
ALTER TABLE users
    DROP CONSTRAINT "UK_hbvhqvjgmhd5omxyo67ynvbyp";

--changeset Pawel:1586468000284-20
ALTER TABLE users
    ADD CONSTRAINT "UK_hbvhqvjgmhd5omxyo67ynvbyp" UNIQUE (address_id);

--changeset Pawel:1586468000284-21
ALTER TABLE technical_support
    DROP CONSTRAINT "UK_rfx102gmxw3pqmakxyoudr5ah";

--changeset Pawel:1586468000284-22
ALTER TABLE technical_support
    ADD CONSTRAINT "UK_rfx102gmxw3pqmakxyoudr5ah" UNIQUE (rent_id);

