use Obligatorio_Web
------------------------------------------------------------------------------------
-- Modificar Categoria

if exists (select * from sysobjects where name = 'Sp_ModificarCategoria')
	drop proc Sp_ModificarCategoria
	go

CREATE PROC Sp_ModificarCategoria
@CodigoCategoria varchar (3), 
@Nombre VARCHAR(50), 
@PrecioBase money
AS
	If (not exists(select * from Categoria where CodigoCategoria = @CodigoCategoria))
	begin
	print 'No existe la categoria'
	return -1
	end
	if (@PrecioBase <=0)
	begin
	print 'El precio debe ser mayor a 0'
	return -2
	end
	begin try
	Update Categoria
	Set Nombre = @Nombre, PrecioBase = @PrecioBase
	where CodigoCategoria = @CodigoCategoria
	end try
	begin catch
	return @@error
	end catch
go