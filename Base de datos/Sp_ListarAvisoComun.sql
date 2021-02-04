use Obligatorio_Web
-----------------------------------------------------------------------------------------
-- Listar Aviso Comun

if exists (select * from sysobjects where name = 'Sp_ListarAvisoComun')
	drop proc Sp_ListarAvisoComun
go

Create proc Sp_ListarAvisoComun
AS
Begin
	SELECT * 
	FROM Comun
	inner join Avisos on Avisos.IdAviso = Comun.IdAviso

End
GO