using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidades;
using System.Data.SqlClient;

namespace Persistencia
{
    public class perAviso
    {
        public int AgregarComun(AvisoComun avisoComun)
        {
            Conexion.Conectar();
            SqlCommand cmd = new SqlCommand("Sp_AltaAvisoComun", Conexion.cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FechaPublicacion", avisoComun.Fecha);
            cmd.Parameters.AddWithValue("CodigoCategoria", avisoComun.Categoria.Codigo);

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add(r);

            cmd.ExecuteNonQuery();

            int retorno = Convert.ToInt32(r.Value);

            Conexion.Desconectar();
            return retorno;
        }

        public int AgregarTelefono(int idaviso, string telefono)
        {
            Conexion.Conectar();
            SqlCommand cmd = new SqlCommand("Sp_AltaTelefono", Conexion.cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("IdAviso", idaviso);
            cmd.Parameters.AddWithValue("Telefono", telefono);

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add(r);

            cmd.ExecuteNonQuery();

            int retorno = Convert.ToInt32(r.Value);
            Conexion.Desconectar();
            return retorno;
        }

        public int AgregarPalabrasClaves(int idaviso, string palabrasClaves)
        {
            Conexion.Conectar();
            SqlCommand cmd = new SqlCommand("Sp_AltaPalabras_Claves", Conexion.cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("IdAviso", idaviso);
            cmd.Parameters.AddWithValue("PalabrasClaves", palabrasClaves);

            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add(r);

            cmd.ExecuteNonQuery();

            int retorno = Convert.ToInt32(r.Value);
            Conexion.Desconectar();
            return retorno;
        }

        public int AgregarDestacado(AvisoDestacado avisoDestacado)
        {
            Conexion.Conectar();
            SqlCommand cmd = new SqlCommand("SP_AltaAvisoDestacado", Conexion.cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CodigoCategoria", avisoDestacado.Categoria.Codigo);
            cmd.Parameters.AddWithValue("FechaPublicacion", avisoDestacado.Fecha);
            cmd.Parameters.AddWithValue("CodigoArticulo", avisoDestacado.Articulo.Codigo);


            SqlParameter r = new SqlParameter();
            r.Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add(r);

            cmd.ExecuteNonQuery();

            int retorno = Convert.ToInt32(r.Value);

            Conexion.Desconectar();
            return retorno;
        }

        public List<string> ListarTelefonos(int idAviso)
        {
            Conexion.Conectar();
            SqlCommand cmd = new SqlCommand("Sp_ListarTelefonos", Conexion.cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("IdAviso", idAviso);

            SqlDataReader dr = cmd.ExecuteReader();

            List<string> lista = new List<string>();

            while (dr.Read())
            {
                string tel = dr["telefono"].ToString();
                lista.Add(tel);
            }

            dr.Close();
            Conexion.Desconectar();

            return lista;
        }

        public List<AvisoComun> ListarComunesporCategoria(string CodigoCategoria)
        {
            SqlConnection cnn = new SqlConnection(Conexion.connectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Sp_ListarComunporCategoria", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CodigoCategoria", CodigoCategoria);

            SqlDataReader dr = cmd.ExecuteReader();

            List<AvisoComun> lista = new List<AvisoComun>();
            perCategoria perCategoria = new perCategoria();

            while (dr.Read())
            {
                List<string> telefonos = ListarTelefonos(Convert.ToInt32(dr["IdAviso"]));
                List<string> palabrasClaves = ListarPalabrasClaves(Convert.ToInt32(dr["IdAviso"]));
                Categoria categoria = perCategoria.BuscarCategoria(CodigoCategoria);

                AvisoComun avisoComun = new AvisoComun(Convert.ToInt32(dr["IdAviso"]), Convert.ToDateTime(dr["FechaPublicacion"]), categoria, telefonos, palabrasClaves);

                lista.Add(avisoComun);
            }

            dr.Close();
            cnn.Close();

            return lista;
        }

        public List<string> ListarPalabrasClaves(int idAviso)
        {
            Conexion.Conectar();
            SqlCommand cmd = new SqlCommand("Sp_ListarPalabrasClaves", Conexion.cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("IdAviso", idAviso);

            SqlDataReader dr = cmd.ExecuteReader();

            List<string> lista = new List<string>();

            while (dr.Read())
            {
                string palabrasClaves = dr["PalabrasClaves"].ToString();
                lista.Add(palabrasClaves);
            }

            dr.Close();
            Conexion.Desconectar();

            return lista;
        }

        public List<AvisoDestacado> ListarDestacadosporCategoria(string CodigoCategoria)
        {
            SqlConnection cnn = new SqlConnection(Conexion.connectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Sp_ListarDestacadoporCategoria", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CodigoCategoria", CodigoCategoria);

            SqlDataReader dr = cmd.ExecuteReader();

            List<AvisoDestacado> lista = new List<AvisoDestacado>();
            perCategoria perCategoria = new perCategoria();
            perArticulo perArticulo = new perArticulo();

            while (dr.Read())
            {
                List<string> telefonos = ListarTelefonos(Convert.ToInt32(dr["IdAviso"]));
                Categoria categoria = perCategoria.BuscarCategoria(CodigoCategoria);
                Articulo articulo = perArticulo.BuscarArticulo(CodigoCategoria);

                AvisoDestacado avisoDestacado = new AvisoDestacado(Convert.ToInt32(dr["IdAviso"]), Convert.ToDateTime(dr["FechaPublicacion"]), categoria, telefonos, articulo);

                lista.Add(avisoDestacado);
            }

            dr.Close();
            cnn.Close();

            return lista;
        }

        public AvisoDestacado BuscarAvisoPorArticulo(string codigoArticulo)
        {
            SqlConnection cnn = new SqlConnection(Conexion.connectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand("Sp_BuscarAvisoDestacadoPorArticulo", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CodigoArticulo", codigoArticulo);
            SqlDataReader dr = cmd.ExecuteReader();

            AvisoDestacado aviso = null;

            perCategoria persistenciaCat = new perCategoria();
            perArticulo persistenciaArt = new perArticulo();

            Articulo articulo = persistenciaArt.BuscarArticulo(codigoArticulo);

            while (dr.Read())
            {
                List<string> Telefonos = ListarTelefonos(Convert.ToInt32(dr["IdAviso"]));
                Categoria categoria = persistenciaCat.BuscarCategoria(dr["CodigoCategoria"].ToString());

                aviso = new AvisoDestacado(Convert.ToInt32(dr["IdAviso"]), Convert.ToDateTime(dr["FechaPublicacion"]), categoria, Telefonos, articulo);
            }
            dr.Close();
            cnn.Close();

            return aviso;
        }

        public List<AvisoComun> ListarAvisosComunes()
        {
            SqlConnection cnn = new SqlConnection(Conexion.connectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Sp_ListarAvisoComun", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                     
            
            SqlDataReader dr = cmd.ExecuteReader();

            List<AvisoComun> listaComun = new List<AvisoComun>();
            perCategoria perCategoria = new perCategoria();

            while (dr.Read())
            {
                List<string> telefonos = ListarTelefonos(Convert.ToInt32(dr["IdAviso"]));

                Categoria categoria = perCategoria.BuscarCategoria(dr["CodigoCategoria"].ToString());
                List<string> palabrasClaves = ListarPalabrasClaves(Convert.ToInt32(dr["IdAviso"]));

                AvisoComun comun = new AvisoComun(Convert.ToInt32(dr["IdAviso"]), Convert.ToDateTime(dr["FechaPublicacion"]), categoria, telefonos, palabrasClaves);

                listaComun.Add(comun);
            }

            dr.Close();
            cnn.Close();

            return listaComun;
        }
        public List<AvisoDestacado> ListarAvisosDestacados()
        {
            SqlConnection cnn = new SqlConnection(Conexion.connectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Sp_ListarAvisoDestacado", cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;           

            SqlDataReader dr = cmd.ExecuteReader();

            List<AvisoDestacado> listaDestacado = new List<AvisoDestacado>();
            perCategoria perCategoria = new perCategoria();
            perArticulo perArticulo = new perArticulo();

            while (dr.Read())
            {
                List<string> telefonos = ListarTelefonos(Convert.ToInt32(dr["IdAviso"]));

                Categoria categoria = perCategoria.BuscarCategoria(dr["CodigoCategoria"].ToString());
                Articulo articulo = perArticulo.BuscarArticuloPorId(Convert.ToInt32(dr["IdAviso"]));

                AvisoDestacado avisoDestacado = new AvisoDestacado(Convert.ToInt32(dr["IdAviso"]), Convert.ToDateTime(dr["FechaPublicacion"]), categoria, telefonos, articulo);

                listaDestacado.Add(avisoDestacado);
            }

            dr.Close();
            cnn.Close();

            return listaDestacado;
        }

    }
}
