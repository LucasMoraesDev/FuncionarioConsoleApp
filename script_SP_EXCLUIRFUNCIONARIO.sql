﻿-- Stored Procedure SP_EXCLUIRFUNCIONARIO
CREATE PROCEDURE SP_EXCLUIRFUNCIONARIO
    @ID UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM FUNCIONARIO
    WHERE ID = @ID
END
