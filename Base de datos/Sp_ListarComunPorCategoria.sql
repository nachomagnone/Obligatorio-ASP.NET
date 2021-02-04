use Obligatorio_Web
------------------------------------------------------------------------------------

--Listar Comun por Categoria

if exists (select * from sysobjects where name = 'Sp_ListarComunporCategoria')
	drop proc Sp_ListarComunporCategoria
	go
CREATE PROCEDURE Sp_ListarComunporCategoria @CodigoCategoria varchar(3)
AS
Begin
if not exists(select * from Categoria where CodigoCategoria = @CodigoCategoria)
return -1
	SELECT * 
	FROM Comun
	inner join Avisos on Avisos.IdAviso = Comun.IdAviso
	where @CodigoCategoria = CodigoCategoria
End
go