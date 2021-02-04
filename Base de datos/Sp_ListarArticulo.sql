use Obligatorio_Web
-------------------------------

--Listar Articulos
if exists (select * from sysobjects where name = 'Sp_ListarArticulo')
	drop proc Sp_ListarArticulo
	go
CREATE PROCEDURE Sp_ListarArticulo 
AS
Begin
	SELECT * 
	FROM Articulo
	where not CodigoArticulo in(select CodigoArticulo from Posee)
End
go