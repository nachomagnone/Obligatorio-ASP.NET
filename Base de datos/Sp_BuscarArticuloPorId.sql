use Obligatorio_Web
-------------------------

--Buscar Articulos por ID
if exists (select * from sysobjects where name = 'Sp_BuscarArticuloPorId')
	drop proc Sp_BuscarArticuloPorId
	go

	create proc Sp_BuscarArticuloPorId @IdAviso int
	as

	select * from Articulo
	inner join Posee on Posee.CodigoArticulo = Articulo.CodigoArticulo
	where @IdAviso = IdAviso
	go