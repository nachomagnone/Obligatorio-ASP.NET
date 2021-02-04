use Obligatorio_Web
--------------------------------------------------------------------------------------
--Listar Palabras Claves

if exists (select * from sysobjects where name = 'Sp_ListarPalabrasClaves')
	drop proc Sp_ListarPalabrasClaves
	go
CREATE PROCEDURE Sp_ListarPalabrasClaves @idAviso int
as
begin
select * from Palabras_Claves
where IdAviso = @idAviso
end
go