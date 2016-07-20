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
    public partial class FinalizarProyecto : System.Web.UI.Page
    {
        public int proyecto;
        public Proyectos datosPro;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProyectoLogica proy = new ProyectoLogica();
            proyecto = Convert.ToInt32(Request.QueryString["idProyecto"]);
            string usuario = Session["usuario"].ToString();
            string permiso = proy.obtienePermisoUsuario(usuario, proyecto);
            AccesoLogica user = new AccesoLogica();
            datosPro = proy.obtieneDatosProyecto(proyecto.ToString());
            LabelElimTareas.Text = "Se va a finalizar el proyecto " + datosPro.Nombre + ", desea continuar?";
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            int proyecto = Convert.ToInt32(Session["idProyecto"]);
            Response.Redirect("~/pantallas/ListaProyectos.aspx");
        }

        protected void finalizarProyecto_Click(object sender, EventArgs e)
        {
            ProyectoLogica proy = new ProyectoLogica();
            bool respuesta = proy.FinaizarProyecto(proyecto);
            if (respuesta)
            {
                Response.Redirect("~/pantallas/ListaProyectos.aspx");
            }
            else
            {
                LabelElimTareas.Text = "No se pudo finalizar el proyecto " + datosPro.Nombre + ", el mismo posee tareas sin finalizar!";
            }

        }   
    }
}