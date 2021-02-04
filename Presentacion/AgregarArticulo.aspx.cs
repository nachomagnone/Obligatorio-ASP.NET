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
    public partial class AgregarArticulo : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
                DesactivoBotones();
                txtPrecio.Enabled = false;
                txtDescripcion.Enabled = false;    
        }

        private void LimpioFormulario()
        {
            txtCodigo.Text = "";
            txtPrecio.Text = "";
            txtDescripcion.Text = "";
            txtCodigo.Enabled = true;
            txtPrecio.Enabled = false;
            txtDescripcion.Enabled = false;
            lblError.Text = "";
        }

        private void DesactivoBotones()
        {
            btnAgregar.Enabled = false;
            btnBuscar.Enabled = true;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;

                if (txtCodigo.Text == string.Empty)
                    throw new Exception("Ingrese Codigo Articulo para buscar");

                logArticulo logica = new logArticulo();

              Articulo articulo = logica.Buscar(txtCodigo.Text);

                if (articulo != null)
                {
                    lblError.Text = "El articulo ya existe";
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtDescripcion.Text = articulo.Descripcion;
                    btnAgregar.Enabled = false;
                    txtCodigo.Enabled = false;
                }
                else
                {
                    txtCodigo.Enabled = false;
                    txtPrecio.Enabled = true;
                    txtDescripcion.Enabled = true;

                    txtPrecio.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    btnAgregar.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;

                logArticulo logica = new logArticulo();
                Articulo articulo = logica.Buscar(txtCodigo.Text);

                if (articulo == null)
                {
                    Articulo art = new Articulo(txtCodigo.Text, Convert.ToDouble(txtPrecio.Text), txtDescripcion.Text);
                    logica.Agregar(art);
                    lblError.Text = "Articulo Agregado correctamente";
                    btnAgregar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpioFormulario();
            this.DesactivoBotones();
        }
    }
}