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
    public partial class ListadoAvisos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cboListado.Items.Add("Listar todos los Avisos");
                cboListado.Items.Add("Listar Avisos Comunes");
                cboListado.Items.Add("Listar Avisos Destacados");
            }
        }

        public void ListarTodolosAvisos()
        {
            try
            {
                logAviso logAviso = new logAviso();
                if (cboListado.SelectedValue.ToString() == "Listar todos los Avisos")
                    lstAvisos.DataSource = logAviso.ListadoAvisos();
                lstAvisos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message; 
            }
        }

        public void Listar_Comunes()
        {
            try
            {
                logAviso logAvisoComun = new logAviso();
                if (cboListado.SelectedValue.ToString() == "Listar Avisos Comunes")
                    lstAvisos.DataSource = logAvisoComun.ListarAvisosComunes();
                lstAvisos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        public void Listar_Destacados()
        {
            try
            {
                logAviso logAvisoDestacado = new logAviso();
                if (cboListado.SelectedValue.ToString() == "Listar Avisos Destacados")
                    lstAvisos.DataSource = logAvisoDestacado.ListarAvisosDestacados();
                lstAvisos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnDesplegar_Click(object sender, EventArgs e)
        {
            ListarTodolosAvisos();
            Listar_Comunes();
            Listar_Destacados();
        }

        protected void lstAvisos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cboListado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}