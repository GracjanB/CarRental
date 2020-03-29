--liquibase formatted sql

--changeset Pawel:1585487773439-1
create table if not exists oauth_access_token
(
    token_id          VARCHAR(255),
    token             bytea,
    authentication_id VARCHAR(255) PRIMARY KEY,
    user_name         VARCHAR(255),
    client_id         VARCHAR(255),
    authentication    bytea,
    refresh_token     VARCHAR(255)
);
--changeset Pawel:1585487773439-2
create table if not exists oauth_refresh_token
(
    token_id       VARCHAR(255),
    token          bytea,
    authentication bytea
);

