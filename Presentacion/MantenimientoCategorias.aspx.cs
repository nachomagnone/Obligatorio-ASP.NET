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
    public partial class MantenimientoCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DesactivoBotones();
            DesactivoTxt();
        }

        private void LimpioFormulario()
        {
            txtCodigoCategoria.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCodigoCategoria.Enabled = true;
            lblError.Text = "";
        }

        private void DesactivoBotones()
        {   
            btnBuscar.Enabled = true;
            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void DesactivoTxt()
        {
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;

                txtNombre.Enabled = true;
                txtPrecio.Enabled = true;

                if (txtCodigoCategoria.Text == string.Empty)
                    throw new Exception("Ingrese Codigo para buscar");

                txtNombre.Text = string.Empty;
                txtPrecio.Text = string.Empty;

                logCategoria logica = new logCategoria();

                Categoria categoria = logica.Buscar(txtCodigoCategoria.Text);

                if (categoria != null)
                {
                    txtNombre.Text = categoria.Nombre;
                    txtPrecio.Text = categoria.PrecioBase.ToString();
                    btnAgregar.Enabled = false;
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    txtCodigoCategoria.Enabled = false;
                    btnBuscar.Enabled = false;
                    txtPrecio.Focus();
                }
                else
                {
                    btnAgregar.Enabled = true;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
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

                Categoria categoria = new Categoria(txtCodigoCategoria.Text, txtNombre.Text, Convert.ToDouble(txtPrecio.Text));

                logCategoria logica = new logCategoria();
                logica.Agregar(categoria);

                lblError.Text = "Categoria agregada";
                LimpioFormulario();
                btnAgregar.Enabled = false;
                txtNombre.Enabled = false;
                txtPrecio.Enabled = false;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;

                Categoria categoria = new Categoria(txtCodigoCategoria.Text, txtNombre.Text, Convert.ToDouble(txtPrecio.Text));

                logCategoria logica = new logCategoria();
                logica.Modificar(categoria);
                lblError.Text = "Categoria modificada";
                LimpioFormulario();
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                txtCodigoCategoria.Enabled = true;
                txtNombre.Enabled = false;
                txtPrecio.Enabled = false;
                btnBuscar.Enabled = true;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = string.Empty;

                logCategoria logica = new logCategoria();
                logica.Eliminar(txtCodigoCategoria.Text);
                lblError.Text = "Categoria eliminada";
                LimpioFormulario();
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                txtNombre.Enabled = false;
                txtPrecio.Enabled = false;
                btnBuscar.Enabled = true;
                txtCodigoCategoria.Text = string.Empty;

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpioFormulario();
            this.DesactivoBotones();
        }


    }
}
