use Obligatorio_Web
---------------------------------

--Alta Palabras Claves

if exists (select * from sysobjects where name = 'Sp_AltaPalabras_Claves')
	drop proc Sp_AltaPalabras_Claves
go

Create proc Sp_AltaPalabras_Claves
@IdAviso int,
@PalabrasClaves varchar(200)
as
begin try
			declare @IdNuevoAviso int
			set @IdNuevoAviso = IDENT_CURRENT ('Avisos')
				INSERT INTO Palabras_Claves(IdAviso, PalabrasClaves)
				VALUES (@IdNuevoAviso, @PalabrasClaves)

end try
begin catch
		return @@error
		end catch
GO