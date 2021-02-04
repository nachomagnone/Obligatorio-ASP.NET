using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;

namespace Persistencia
{
   public class perCategoria
    {

       public Categoria BuscarCategoria(string CodigoCategoria)
       {
           Conexion.Conectar();
           SqlCommand cmd = new SqlCommand("Sp_BuscarCategoria", Conexion.cnn);
           cmd.CommandType = System.Data.CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("CodigoCategoria", CodigoCategoria);
           SqlDataReader dr = cmd.ExecuteReader();

           Categoria categoria = null;

           while (dr.Read())
           {
               categoria = new Categoria(CodigoCategoria, dr["Nombre"].ToString(), Convert.ToDouble(dr["PrecioBase"]));
           }
           dr.Close();
           Conexion.Desconectar();
           return categoria;
       }

       public int AgregarCategoria(Categoria categoria)
       {
           Conexion.Conectar();
           SqlCommand cmd = new SqlCommand("Sp_AltaCategoria", Conexion.cnn);
           cmd.CommandType = System.Data.CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("CodigoCategoria", categoria.Codigo);
           cmd.Parameters.AddWithValue("Nombre", categoria.Nombre);
           cmd.Parameters.AddWithValue("PrecioBase", categoria.PrecioBase);

           SqlParameter retorno = new SqlParameter();
           retorno.Direction = System.Data.ParameterDirection.ReturnValue;
           cmd.Parameters.Add(retorno);

           cmd.ExecuteNonQuery();
           int r = Convert.ToInt32(retorno.Value);
           Conexion.Desconectar();

           return r;
       }

       public int Eliminar(string CodigoCategoria)
       {
           Conexion.Conectar();
           SqlCommand cmd = new SqlCommand("Sp_EliminarCategoria", Conexion.cnn);
           cmd.CommandType = System.Data.CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("CodigoCategoria", CodigoCategoria);

           SqlParameter retorno = new SqlParameter();
           retorno.Direction = System.Data.ParameterDirection.ReturnValue;
           cmd.Parameters.Add(retorno);

           cmd.ExecuteNonQuery();
           int r = Convert.ToInt32(retorno.Value);
           Conexion.Desconectar();

           return r;
       }

       public int ModificarCategoria(Categoria categoria)
       {
           Conexion.Conectar();
           SqlCommand cmd = new SqlCommand("Sp_ModificarCategoria", Conexion.cnn);
           cmd.CommandType = System.Data.CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("CodigoCategoria", categoria.Codigo);
           cmd.Parameters.AddWithValue("Nombre", categoria.Nombre);
           cmd.Parameters.AddWithValue("PrecioBase", categoria.PrecioBase);

           SqlParameter r = new SqlParameter();
           r.Direction = System.Data.ParameterDirection.ReturnValue;
           cmd.Parameters.Add(r);

           cmd.ExecuteNonQuery();

           int retorno = Convert.ToInt32(r.Value);

           Conexion.Desconectar();
           return retorno;
       }

       public List<Categoria> listar()
       {
           Conexion.Conectar();
           SqlCommand cmd = new SqlCommand("Sp_ListarCategoria", Conexion.cnn);
           cmd.CommandType = System.Data.CommandType.StoredProcedure;

           SqlDataReader dr = cmd.ExecuteReader();

           List<Categoria> lista = new List<Categoria>();

           while (dr.Read())
           {
               Categoria categoria = new Categoria(dr["CodigoCategoria"].ToString(), dr["Nombre"].ToString(), Convert.ToDouble(dr["PrecioBase"]));

               lista.Add(categoria);
           }

           dr.Close();
           Conexion.Desconectar();

           return lista;

       }

    }
}
