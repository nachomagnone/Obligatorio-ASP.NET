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
    public partial class AgregarAvisoDestacado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["telefonos"] = null;
                ListarCategorias();
                ListarArticulos();
            }
        }

        private void ListarCategorias()
        {
            try
            {
                logCategoria logica = new logCategoria();
                cboCategoriaDestacado.DataSource = logica.listar();
                cboCategoriaDestacado.DataTextField = "Nombre";
                cboCategoriaDestacado.DataValueField = "Codigo";
                cboCategoriaDestacado.DataBind();

            }
            catch
            {
                lblError.Text = "Error al listar";
            }
        }

        private void ListarArticulos()
        {
            try
            {
                logArticulo logicaArt = new logArticulo();
                cboArticulo.DataSource = logicaArt.ListarArticulo();
                cboArticulo.DataValueField = "Codigo";
                cboArticulo.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al listar Articulo  " + ex.Message;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            try
            {
                logCategoria logica = new logCategoria();

                Categoria categoria = logica.Buscar(cboCategoriaDestacado.SelectedValue.ToString());

                if (categoria == null)
                {
                    throw new Exception("Seleccione una categoria");
                }

              logArticulo logicaArt = new logArticulo();  
                
                Articulo articulo = logicaArt.Buscar(cboArticulo.SelectedValue.ToString());

                if (articulo == null)
                {
                    throw new Exception("Seleccione un articulo");
                }

                List<string> telefonos = (List<string>)Session["telefonos"];

               AvisoDestacado avisoDestacado = new AvisoDestacado(0, clnFecha.SelectedDate, categoria, telefonos, articulo);

                logAviso logAviso = new logAviso();
                logAviso.AgregarDesta(avisoDestacado);
                ListarArticulos();
                lstTelefonos.Items.Clear();
                Session["telefonos"] = null;

                lblError.Text = "Aviso agregado " + avisoDestacado.Numero.ToString();

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnAgregarTel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTelefonos.Text == string.Empty)
                    throw new Exception("Debe ingresar telefono");

                if (Session["telefonos"] == null)
                {
                    Session["telefonos"] = new List<string>();
                }
                ((List<string>)Session["telefonos"]).Add(txtTelefonos.Text);

                lstTelefonos.Items.Add(txtTelefonos.Text);
                txtTelefonos.Text = string.Empty;
                txtTelefonos.Focus();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}