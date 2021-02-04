using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Entidades;
using Logica;

namespace Presentacion
{
    public partial class ListadoCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            ListarCategoria();
        }

        public void ListarCategoria()
        {
            try
            {
                logCategoria logica = new logCategoria();
                grdCategoria.DataSource = logica.listar();
                grdCategoria.DataBind();

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

       protected void grdCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;

                logCategoria logica = new logCategoria();
                Categoria categoria = logica.Buscar(grdCategoria.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
                logAviso logicaAviso = new logAviso();
                grdAviso.DataSource = logicaAviso.Listar(categoria.Codigo);
                grdAviso.DataBind();
                 
            }
            catch (Exception ex)
            {

                lblError.Text = ex.Message;
            }
        }


    }
}