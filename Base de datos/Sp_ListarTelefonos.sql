use Obligatorio_Web
-----------------------------------------------------------------------------------

--Listar Telefonos

if exists (select * from sysobjects where name = 'Sp_ListarTelefonos')
	drop proc Sp_ListarTelefonos
	go
CREATE PROCEDURE Sp_ListarTelefonos @idAviso int
as
begin
select * from Telefonos
where IdAviso = @idAviso
end
go