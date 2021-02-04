use Obligatorio_Web
----------------------------------------------------------------------------------------
--Listar Destacado por Categoria

if exists (select * from sysobjects where name = 'Sp_ListarDestacadoporCategoria')
	drop proc Sp_ListarDestacadoporCategoria
	go
CREATE PROCEDURE Sp_ListarDestacadoporCategoria @CodigoCategoria varchar(3)
AS
Begin
if not exists(select * from Categoria where CodigoCategoria = @CodigoCategoria)
return -1

	SELECT * 
	FROM Destacado
	inner join Avisos on Avisos.IdAviso = Destacado.IdAviso
	where @CodigoCategoria = Avisos.CodigoCategoria
End
go