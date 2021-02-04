
use Obligatorio_Web

------------------------------------
--Buscar Articulo

if exists (select * from sysobjects where name = 'Sp_BuscarArticulo')
	drop proc Sp_BuscarArticulo
	go

create proc Sp_BuscarArticulo @CodigoArticulo varchar (6) 
as
if (len(@CodigoArticulo)!=6)
begin
print 'El codigo tiene que tener seis caracteres'
return -1
end
begin try
if not exists( select * from Articulo where CodigoArticulo = @CodigoArticulo)
begin 
print 'No existe el articulo'
end
select * from Articulo where CodigoArticulo = @CodigoArticulo
return 1
end try
begin catch
return @@error
end catch
go