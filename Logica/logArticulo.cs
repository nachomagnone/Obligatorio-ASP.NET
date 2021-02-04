using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Entidades;
using Persistencia;

namespace Logica
{
   public class logArticulo
    {
       perArticulo persistencia = new perArticulo();

       public Articulo Buscar(string CodigoArticulo)
       {
           return persistencia.BuscarArticulo(CodigoArticulo);
       }

       public void Agregar(Articulo articulo)
       {
           int valor = persistencia.AgregarArticulo(articulo);
           if (valor == 0)
               throw new Exception("Error al ingresar el Articulo");
       }

       public List<Articulo> ListarArticulo()
       {
           List<Articulo> articulo = new List<Articulo>();
           articulo.AddRange(persistencia.listarArticulo());
           return articulo;
       }

       public List<Articulo> ListarEnUso()
       {
           return persistencia.ListarArticulosenUso();
       }
//--------------------------chequear---------------------------------------
       public Articulo BuscarArtPorId(int idAviso)
       {
           return persistencia.BuscarArticuloPorId(idAviso);
       }
    }
}
