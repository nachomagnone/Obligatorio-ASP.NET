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
    public partial class AgregarAvisoComun : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["telefonos"] = null;
                Session["palabrasclaves"] = null;
                ListarCategorias();
            }
        }
        private void ListarCategorias()
        {
            try
            {
                logCategoria logica = new logCategoria();
                cboCategoria.DataSource = logica.listar();
                cboCategoria.DataTextField = "Nombre";
                cboCategoria.DataValueField = "Codigo";
                cboCategoria.DataBind();
            }
            catch
            {
                lblError.Text = "Error al listar";
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            
            try
            {
                logCategoria logica = new logCategoria();
                Categoria categoria = logica.Buscar(cboCategoria.SelectedValue.ToString());
                if (categoria == null)
                    throw new Exception("Seleccione una categoría.");


                List<string> telefonos = (List<string>)Session["telefonos"];
                List<string> palabras = (List<string>)Session["palabrasclaves"];

                AvisoComun avisoComun = new AvisoComun(0, 
                    clnFechaPublicacion.SelectedDate, 
                    categoria, 
                    telefonos, 
                    palabras);
                
                logAviso logAviso = new logAviso();
                logAviso.AgregarCom(avisoComun);
                lstPalabrasClaves.Items.Clear();
                lstTelefonos.Items.Clear();
                Session["palabrasclaves"] = null;
                Session["telefonos"] = null;

                lblError.Text = "Aviso agregado " + avisoComun.Numero.ToString();
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
                    throw new Exception("Debe ingresar teléfono");

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

        protected void btnAgregarPal_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPalabrasClaves.Text == string.Empty)
                    throw new Exception("Ingrese palabra clave");

                if (Session["palabrasclaves"] == null)
                {
                    Session["palabrasclaves"] = new List<string>();
                }

                ((List<string>)Session["palabrasclaves"]).Add(txtPalabrasClaves.Text);

                lstPalabrasClaves.Items.Add(txtPalabrasClaves.Text);
                txtPalabrasClaves.Text = string.Empty;
                txtPalabrasClaves.Focus();

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        protected void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}