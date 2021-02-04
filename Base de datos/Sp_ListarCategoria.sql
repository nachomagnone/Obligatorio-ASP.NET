use Obligatorio_Web
----------------------------------------------------------------------------------

--Listar Categorias

if exists (select * from sysobjects where name = 'Sp_ListarCategoria')
	drop proc Sp_ListarCategoria
	go
CREATE PROCEDURE Sp_ListarCategoria 
AS
Begin
	SELECT * 
	FROM Categoria
End
go