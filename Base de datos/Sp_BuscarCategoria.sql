Use Obligatorio_Web
--------------------------------------------------
--Buscar Categoria

if exists (select * from sysobjects where name = 'Sp_BuscarCategoria')
	drop proc Sp_BuscarCategoria
	go

create proc Sp_BuscarCategoria
@CodigoCategoria varchar (3) 
as
if(len(@CodigoCategoria)!=3)
begin
	print 'El codigo debe tener tres caracteres'
	return -1
	end
	if not exists ( select * from Categoria where CodigoCategoria = @CodigoCategoria)
	begin
	print 'El codigo de la categoria no existe'
	return -2
	end
select * from Categoria where CodigoCategoria = @CodigoCategoria
return 1
go