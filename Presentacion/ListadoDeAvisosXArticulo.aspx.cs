using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Logica;
using Entidades;

namespace Presentacion
{
    public partial class ListadoDeAvisosXArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarArticulos();
            }
        }

        private void ListarArticulos()
        {
            try
            {
                logArticulo logicaArt = new logArticulo();
                cboArticulo.DataSource = logicaArt.ListarEnUso();
                cboArticulo.DataValueField = "Codigo";
                cboArticulo.DataBind();
            }
            catch (Exception ex)
            {

                lblError.Text = "Error al listar Articulo  " + ex.Message;
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;
                logAviso logaviso = new logAviso();

                AvisoDestacado aviso = logaviso.BuscarDestacadoPorArticulo(cboArticulo.SelectedValue.ToString());
                List<AvisoDestacado> avisos = new List<AvisoDestacado>();
                avisos.Add(aviso);

                grdAvisoArticulo.DataSource = avisos;
                grdAvisoArticulo.DataBind();
            }
            catch (Exception ex)
            { 
                lblError.Text = ex.Message; 
            }
        }
    }
}