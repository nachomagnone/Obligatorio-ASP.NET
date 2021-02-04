use Obligatorio_Web
------------------------------------------------------------------------------------

--Alta Categoria

if exists (select * from sysobjects where name = 'Sp_AltaCategoria')
	drop proc Sp_AltaCategoria
	go

CREATE PROC Sp_AltaCategoria 
@CodigoCategoria varchar (3), 
@Nombre varchar(50),
@PrecioBase money
AS
begin try
if(LEN(@CodigoCategoria) !=3)
begin
print 'El codigo debe de tener tres caracteres'
return -1
end
	If (exists(select * from Categoria where CodigoCategoria = @CodigoCategoria))
		begin
		print 'El codigo de la categoria ya existe'
		return -2;
		end
		if (@PrecioBase<=0)
		begin
		print 'El precio debe ser mayor a 0'
		return -3
		end

	INSERT INTO Categoria(CodigoCategoria,Nombre, PrecioBase) 
	VALUES (@CodigoCategoria, @Nombre, @PrecioBase)
			RETURN 1	
	end try
	begin catch
	return @@error
	end catch
go