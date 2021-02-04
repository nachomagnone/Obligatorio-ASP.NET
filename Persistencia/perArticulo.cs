using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Entidades;

namespace Persistencia
{
   public class perArticulo
    {
       public Articulo BuscarArticulo(string CodigoArticulo)
       {
           Conexion.Conectar();
           SqlCommand cmd = new SqlCommand("Sp_BuscarArticulo", Conexion.cnn);
           cmd.CommandType = System.Data.CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("CodigoArticulo", CodigoArticulo);
           SqlDataReader dr = cmd.ExecuteReader();

           Articulo articulo = null;

           while (dr.Read())
           {
               articulo = new Articulo(dr["CodigoArticulo"].ToString(), Convert.ToDouble(dr["Precio"]), dr["Descripcion"].ToString());
           }
           dr.Close();
           Conexion.Desconectar();
           return articulo;
       }

       public Articulo BuscarArticuloPorId(int idAviso)
       {
           Conexion.Conectar();
           SqlCommand cmd = new SqlCommand("Sp_BuscarArticuloPorId", Conexion.cnn);
           cmd.CommandType = System.Data.CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("IdAviso", idAviso);
           SqlDataReader dr = cmd.ExecuteReader();

           Articulo articulo = null;

           while (dr.Read())
           {
               articulo = new Articulo(dr["CodigoArticulo"].ToString(), Convert.ToDouble(dr["Precio"]), dr["Descripcion"].ToString());
           }
           dr.Close();
           Conexion.Desconectar();
           return articulo;
       }

       public int AgregarArticulo(Articulo articulo)
       {
           Conexion.Conectar();
           SqlCommand cmd = new SqlCommand("Sp_AltaArticulo", Conexion.cnn);
           cmd.CommandType = System.Data.CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("CodigoArticulo", articulo.Codigo);
           cmd.Parameters.AddWithValue("Precio", articulo.Precio);
           cmd.Parameters.AddWithValue("Descripcion", articulo.Descripcion);

           SqlParameter retorno = new SqlParameter();
           retorno.Direction = System.Data.ParameterDirection.ReturnValue;
           cmd.Parameters.Add(retorno);

           cmd.ExecuteNonQuery();

           int r = Convert.ToInt32(retorno.Value);
           Conexion.Desconectar();

           return r;
       }

       public List<Articulo> listarArticulo()
       {
           Conexion.Conectar();
           SqlCommand cmd = new SqlCommand("Sp_ListarArticulo", Conexion.cnn);
           cmd.CommandType = System.Data.CommandType.StoredProcedure;

           SqlDataReader dr = cmd.ExecuteReader();

           List<Articulo> lista = new List<Articulo>();

           while (dr.Read())
           {
               Articulo articulo = new Articulo(dr["CodigoArticulo"].ToString(), Convert.ToDouble(dr["Precio"]), dr["Descripcion"].ToString());

               lista.Add(articulo);
           }

           dr.Close();
           Conexion.Desconectar();

           return lista;

       }

       public List<Articulo> ListarArticulosenUso()
       {
           Conexion.Conectar();
           SqlCommand cmd = new SqlCommand("Sp_ListarArticulosenUso", Conexion.cnn);
           cmd.CommandType = System.Data.CommandType.StoredProcedure;

           SqlDataReader dr = cmd.ExecuteReader();
           List<Articulo> lista = new List<Articulo>();

           while (dr.Read())
           {
               Articulo articulo = new Articulo(dr["codigoArticulo"].ToString(), Convert.ToInt32(dr["Precio"]), dr["Descripcion"].ToString());
               lista.Add(articulo);
           }

           dr.Close();
           Conexion.Desconectar();

           return lista;
       }

    }

}
