using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Datos;

namespace Prodeo
{
    public partial class AltaModulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProyectoLogica proy = new ProyectoLogica();
                int proyecto = Convert.ToInt32(Session["idProyecto"]);
                string usuario = Session["usuario"].ToString();
                string permiso = proy.obtienePermisoUsuario(usuario, proyecto);
                int idModulo = Convert.ToInt32(Request.QueryString["idModulo"]);
                Session["idModulo"] = idModulo;
                if(idModulo == 0)
                {
                    Session["permiso"] = "A";
                    LabelModulo.Text = "Alta de Modulo";
                    btnAltaModulo.Visible = true;
                    btnCancelarModulo.Visible = true;
                    btnVolverModulo.Visible = false;
                    btnEditarModulo.Visible = false;
                    btnCancelarEdicion.Visible = false;
                }
                else
                {
                    btnAltaModulo.Visible = false;
                    btnCancelarModulo.Visible = false;
                    btnVolverModulo.Visible = true;
                    if (permiso == "A")
                    {
                        btnEditarModulo.Visible = true;
                        btnCancelarEdicion.Visible = false;
                    }
                    else
                    {
                        btnEditarModulo.Visible = false;
                        btnCancelarEdicion.Visible = false;
                    }

                    LabelModulo.Text = "Ver Modulo";

                    Modulos mod = proy.obtieneDatosModulo(idModulo);
                    nombreModulo.Value = mod.Nombre;
                    nombreModulo.Disabled = true;
                    descripcion.Value = mod.Descripcion;
                    descripcion.Disabled = true;
                    fechaVencimiento.Value = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(mod.FechaVencimiento));
                    fechaVencimiento.Disabled = true;
                }
                
            }

        }
        protected void altaModuloForm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int proyecto = Convert.ToInt32(Session["idProyecto"]);
                string usuario = Session["usuario"].ToString();
                bool altaExitosa = false;
                Session["permiso"] = "A";
                ProyectoLogica agregaModulo = new ProyectoLogica();
                if (Session["idModulo"].ToString() == "0")
                {
                    altaExitosa = agregaModulo.insertaModulo(nombreModulo.Value, descripcion.Value, DateTime.Now, Convert.ToDateTime(fechaVencimiento.Value), proyecto, usuario);
                }
                else
                {
                    altaExitosa = agregaModulo.actualizaModulo(Convert.ToInt32(Session["idModulo"]), nombreModulo.Value, descripcion.Value, Convert.ToDateTime(fechaVencimiento.Value));
                }
                if (altaExitosa)
                {
                    Session["idModulo"] = null;
                    Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto + "&p=" + Session["permiso"]);
                }
            }
        }

        protected void cancelarModuloForm_Click(object sender, EventArgs e)
        {
            int proyecto = Convert.ToInt32(Session["idProyecto"]);
            Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto + "&p=" + Session["permiso"]);

        }

        protected void editarModulo_Click(object sender, EventArgs e)
        {
            btnEditarModulo.Visible = false;
            btnCancelarEdicion.Visible = true;
            nombreModulo.Disabled = false;
            descripcion.Disabled = false;
            fechaVencimiento.Disabled = false;
            LabelModulo.Text = "Editar Modulo";
            btnAltaModulo.Visible = true;
            btnAltaModulo.InnerText = "Guardar";

        }

        protected void cancelarModulo_Click(object sender, EventArgs e)
        {
            btnEditarModulo.Visible = true;
            btnCancelarEdicion.Visible = false;
            nombreModulo.Disabled = true;
            descripcion.Disabled = true;
            fechaVencimiento.Disabled = true;
            LabelModulo.Text = "Ver Modulo";
            btnAltaModulo.Visible = false;
        }

        protected void validarFechaVenc(object source, ServerValidateEventArgs args)
        {
            AccesoLogica logica = new AccesoLogica();
            DateTime fechaVenc = Convert.ToDateTime(fechaVencimiento.Value);
            int idProyecto = Convert.ToInt32(Session["idProyecto"]);
            bool fechaValida = logica.esFechaModulValida(fechaVenc, idProyecto);
            if (fechaValida)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
                DateTime FechVencProyecto = logica.obtieneVencProyecto(idProyecto);
                CustomValVencValid.ErrorMessage = "La fecha de vencimiento no puede ser mayor a la del proyecto: " + FechVencProyecto;
            }
        }

        protected void validarFechaActual(object source, ServerValidateEventArgs args)
        {
            AccesoLogica logica = new AccesoLogica();
            DateTime fechaVenc = Convert.ToDateTime(fechaVencimiento.Value);
            bool fechaValida = logica.esFechaMayorActual(fechaVenc);
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            if (fechaValida)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
                CustomValFechActual.ErrorMessage = "La fecha ingresada debe ser mayor o igual a la actual: " + fechaActual;
            }
        }

    }
}