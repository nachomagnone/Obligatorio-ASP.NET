USE Obligatorio_Web
GO
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'Sp_BuscarAvisoDestacadoPorArticulo')
DROP PROCEDURE Sp_BuscarAvisoDestacadoPorArticulo
GO
CREATE PROC Sp_BuscarAvisoDestacadoPorArticulo @CodigoArticulo varchar(6)
AS
Select * FROM Destacado
INNER JOIN Avisos on Avisos.IdAviso = Destacado.IdAviso
INNER JOIN Posee ON Destacado.IdAviso = Posee.IdAviso
WHERE Posee.CodigoArticulo = @CodigoArticulo
GO

