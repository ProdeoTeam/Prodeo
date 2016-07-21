using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Negocio;

namespace Prodeo.pantallas
{
    public partial class EliminarTarea : System.Web.UI.Page
    {
        public int idTarea;
        public Tareas tarea;
        public int proyecto;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/index.aspx");
            }
            else
            {
                ProyectoLogica proy = new ProyectoLogica();
                proyecto = Convert.ToInt32(Session["idProyecto"]);
                string usuario = Session["usuario"].ToString();
                string permiso = proy.obtienePermisoUsuario(usuario, proyecto);
                AccesoLogica user = new AccesoLogica();
                idTarea = Convert.ToInt32(Request.QueryString["idTarea"]);
                tarea = proy.obtieneDatosTarea(idTarea);
                LabelElimTareas.Text = "Se va a eliminar la tarea " + tarea.Nombre + ", desea continuar?";
            }
            
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            int proyecto = Convert.ToInt32(Session["idProyecto"]);
            Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto + "&p=" + Session["permiso"]);
        }

        protected void eliminarTarea_Click(object sender, EventArgs e)
        {
            ProyectoLogica proy = new ProyectoLogica();
            bool respuesta = proy.EliminaTarea(idTarea.ToString(),Session["usuario"].ToString());
            if (respuesta)
            {
                Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto + "&p=" + Session["permiso"]);
            }
            else
            {
                LabelElimTareas.Text = "No se pudo realizar la baja del modulo " + tarea.Nombre + "!";
            }

        } 
    }
}