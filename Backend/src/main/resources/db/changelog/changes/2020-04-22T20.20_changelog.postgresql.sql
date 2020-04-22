--liquibase formatted sql

--changeset Pawel:1587586847814-20
CREATE TABLE technical_support_done_action
(
    id                              BIGINT                      NOT NULL,
    creation_date                   TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    update_date                     TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    optlock_version                 BIGINT,
    employee_id                     BIGINT,
    technical_support_has_action_id BIGINT                      NOT NULL,
    CONSTRAINT "technical_support_done_actionPK" PRIMARY KEY (id)
);

--changeset Pawel:1587586847814-21
ALTER TABLE technical_support_done_action
    ADD CONSTRAINT "FKb5sdjnu72tmmgop788xn5qerr" FOREIGN KEY (employee_id) REFERENCES users (id);

--changeset Pawel:1587586847814-22
ALTER TABLE technical_support_done_action
    ADD CONSTRAINT "FKmddfm70ltuprfttagopqb6rah" FOREIGN KEY (technical_support_has_action_id) REFERENCES technical_support_has_action (id);

--changeset Pawel:1587586847814-23
ALTER TABLE technical_support_has_action
    DROP CONSTRAINT "FK22k91tlsclpk1xciomspy62lk";

--changeset Pawel:1587586847814-24
ALTER TABLE technical_support_has_action
    DROP CONSTRAINT "FK35jpuxwxbkpawd8x0yg7pyegn";

--changeset Pawel:1587586847814-29
ALTER TABLE technical_support_has_action
    DROP COLUMN employee_id;

--changeset Pawel:1587586847814-30
ALTER TABLE technical_support_has_action
    DROP COLUMN technical_support_has_action_id;