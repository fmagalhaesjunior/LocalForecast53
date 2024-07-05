-- init.sql
CREATE TABLE IF NOT EXISTS call_history (
    id SERIAL NOT NULL,
    latitude DOUBLE PRECISION NOT NULL,
    longitude DOUBLE PRECISION NOT NULL,
    callTime TIMESTAMP NOT NULL,
    responseBody JSONB NUT NULL,
    CONSTRAINT PK_call_history 			PRIMARY KEY(Id)
);
