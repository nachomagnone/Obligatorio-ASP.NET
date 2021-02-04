USE Obligatorio_Web
GO
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'Sp_ListarArticulosenUso')
DROP PROCEDURE Sp_ListarArticulosenUso
GO

CREATE PROC Sp_ListarArticulosenUso
AS
SELECT * FROM Articulo
WHERE CodigoArticulo IN (SELECT CodigoArticulo FROM Posee)
GO
