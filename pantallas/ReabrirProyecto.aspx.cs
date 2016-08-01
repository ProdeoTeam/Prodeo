using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Datos;

namespace Prodeo.pantallas
{
    public partial class ReabrirProyecto : System.Web.UI.Page
    {
        public int proyecto;
        public Proyectos datosPro;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/index.aspx");
            }
            else
            {
                ProyectoLogica proy = new ProyectoLogica();
                proyecto = Convert.ToInt32(Request.QueryString["idProyecto"]);
                datosPro = proy.obtieneDatosProyecto(proyecto.ToString());
                LabelElimTareas.Text = "Se va a reabrir el proyecto " + datosPro.Nombre + ", ¿desea continuar?";
            }
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pantallas/ListaProyectos.aspx");
        }

        protected void reabrirProyecto_Click(object sender, EventArgs e)
        {
            ProyectoLogica proy = new ProyectoLogica();
            bool respuesta = proy.ReabrirProyecto(proyecto);
            if (respuesta)
            {
                Response.Redirect("~/pantallas/ListaProyectos.aspx");
            }
            else
            {
                LabelElimTareas.Text = "No se pudo reabrir el proyecto " + datosPro.Nombre + "!";
            }

        }
    }
}