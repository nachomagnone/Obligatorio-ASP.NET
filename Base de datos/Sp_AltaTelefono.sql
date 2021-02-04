use Obligatorio_Web
----------------------------------

--Alta Telefono

if exists (select * from sysobjects where name = 'Sp_AltaTelefono')
	drop proc Sp_AltaTelefono
go

Create proc Sp_AltaTelefono
@IdAviso int,
@telefono varchar(20)
as
begin try
			declare @IdNuevoAviso int
			set @IdNuevoAviso = IDENT_CURRENT ('Avisos')
insert into Telefonos (IdAviso, Telefono)
	values (@IdNuevoAviso, @telefono)

end try
begin catch
		return @@error
end catch
go