use Obligatorio_Web

------------------------
--Alta Articulo
if exists (select * from sysobjects where name = 'Sp_AltaArticulo')
	drop proc Sp_AltaArticulo
	go

CREATE PROC Sp_AltaArticulo 
@Codigoarticulo varchar (6), 
@Precio money, 
@Descripcion varchar(max)
AS
begin try
	If (exists(select * from Articulo where CodigoArticulo = @CodigoArticulo))
		begin
		print 'El codigo del articulo ya existe'
		return -1;
		end
		if (@Precio<=0)
		begin
		print 'El precio debe ser mayor a 0'
		return -2
		end

	INSERT INTO Articulo(CodigoArticulo, Precio, Descripcion) 
	VALUES (@CodigoArticulo,@Precio,@Descripcion)
			RETURN 1	
	end try
	begin catch
	return @@error
	end catch