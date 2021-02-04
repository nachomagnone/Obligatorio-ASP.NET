use Obligatorio_Web
----------------------------------------------------------------------------------------------
--Listar Aviso Destacado

if exists (select * from sysobjects where name = 'Sp_ListarAvisoDestacado')
	drop proc Sp_ListarAvisoDestacado
go

Create proc Sp_ListarAvisoDestacado
AS
Begin
	SELECT * 
	FROM Destacado
	inner join Avisos on Avisos.IdAviso = Destacado.IdAviso
	inner join Posee on Posee.IdAviso = Destacado.IdAviso
End
go