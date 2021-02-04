use Obligatorio_Web
------------------------------------------------------------------------------------------------
--Eliminar Categoria

if exists (select * from sysobjects where name = 'Sp_EliminarCategoria')
	drop proc Sp_EliminarCategoria
	go

CREATE PROC Sp_EliminarCategoria
@CodigoCategoria varchar (3)
AS
	If (exists (select * from Avisos where CodigoCategoria = @CodigoCategoria))
	begin
	print 'Categoria con avisos, no se puede eliminar'
		return -2
	end	
	begin try
	Delete Categoria
	where CodigoCategoria = @CodigoCategoria
	print 'La categoria se elimino correctamente'
	return 1
	end try
	begin catch
	return @@error
	end catch
go