use Obligatorio_Web
-----------------------------------------------------------------------------
--Alta Aviso Destacado

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'SP_AltaAvisoDestacado')
	DROP PROC SP_AltaAvisoDestacado
GO
CREATE PROC SP_AltaAvisoDestacado
@CodigoCategoria varchar (3), 
@FechaPublicacion SmallDateTime, 
@CodigoArticulo varchar (6)

AS

			IF Not Exists (SELECT * FROM Categoria WHERE CodigoCategoria = @CodigoCategoria)
			BEGIN
			print 'La categoria para ingresar el Aviso no existe'
			Return -1
			END
			if exists (select * from Posee where CodigoArticulo = @CodigoArticulo)
			begin
				print 'Articulo en uso'
			return -2
			end
						
			BEGIN TRY
				declare @IdNuevoAviso int
				BEGIN TRANSACTION

					INSERT INTO Avisos (FechaPublicacion, CodigoCategoria)
						VALUES (@FechaPublicacion, @CodigoCategoria)

					SET @IdNuevoAviso = @@IDENTITY
					INSERT INTO Destacado (IdAviso)
						VALUES (@IdNuevoAviso)
															
					INSERT INTO Posee (IdAviso, CodigoArticulo)
						VALUES (@IdNuevoAviso, @CodigoArticulo)

				COMMIT Transaction
				RETURN @IdNuevoAviso
			END TRY

			BEGIN CATCH
					RollBack Transaction
					Return @@Error
			END CATCH
GO