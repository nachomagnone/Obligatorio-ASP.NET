Use Obligatorio_Web

---Alta Aviso Comun

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'Sp_AltaAvisoComun')
	DROP PROC Sp_AltaAvisoComun
GO
CREATE PROC Sp_AltaAvisoComun
@CodigoCategoria varchar (3), @FechaPublicacion SmallDateTime
AS

			IF Not Exists (SELECT * FROM Categoria WHERE CodigoCategoria = @CodigoCategoria)
			BEGIN
			print 'La categoria para ingresar el Aviso no existe'
			Return -1
			END
										
			BEGIN TRY
				declare @IdNuevoAviso int
				BEGIN TRANSACTION 

					INSERT INTO Avisos (FechaPublicacion, CodigoCategoria)
						VALUES (@FechaPublicacion, @CodigoCategoria)
					SET @IdNuevoAviso = @@IDENTITY
					
					INSERT INTO Comun (IdAviso)
						VALUES (@IdNuevoAviso)

				COMMIT Transaction
				PRINT 'Se agrego el Aviso'
			RETURN @IdNuevoAviso
			END TRY

			BEGIN CATCH
					RollBack Transaction
					Return @@Error
			END CATCH
GO