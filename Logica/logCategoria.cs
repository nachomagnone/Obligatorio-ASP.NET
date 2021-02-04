using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Entidades;
using Persistencia;

namespace Logica
{
    public class logCategoria
    {

        perCategoria persistencia = new perCategoria();

        public Categoria Buscar(string CodigoCategoria)
        {
            return persistencia.BuscarCategoria(CodigoCategoria);
        }

        public void Agregar(Categoria categoria)
        {
            int valor = persistencia.AgregarCategoria(categoria);
            if (valor == 0)
                throw new Exception("Error al ingresar la Categoria");
        }

        public void Modificar(Categoria categoria)
        {
            int valor = persistencia.ModificarCategoria(categoria);
            if (valor == 0)
                throw new Exception("Error al modificar la Categoria");
        }

        public void Eliminar(string CodigoCategoria)
        {
            int valor = persistencia.Eliminar(CodigoCategoria);
            if (valor == 0)
                throw new Exception("Error al eliminar la Categoria");
        }

        public List<Categoria> listar()
        {
            List<Categoria> categoria = new List<Categoria>();
            categoria.AddRange(persistencia.listar());

            return categoria;
        }
    }
}
