﻿-- Criação da tabela FUNCIONARIO
CREATE TABLE FUNCIONARIO (
    ID UNIQUEIDENTIFIER NOT NULL,
    NOME NVARCHAR(150) NOT NULL,
    MATRICULA NVARCHAR(6) NOT NULL,
    CPF NVARCHAR(11) NOT NULL,
    CONSTRAINT PK_FUNCIONARIO PRIMARY KEY (ID)
)
