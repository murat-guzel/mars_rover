CREATE DATABASE "MarsRover";

\c MarsRover


-- Table: public.RoverLog

-- DROP TABLE IF EXISTS public."RoverLog";

CREATE TABLE IF NOT EXISTS public."RoverLog"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Message" text COLLATE pg_catalog."default" NOT NULL,
    "LogLevel" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "RoverLog_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."RoverLog"
    OWNER to postgres;