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
    public partial class EliminarCuenta : System.Web.UI.Page
    {
        public int idTarea;
        public Tareas tarea;
        public int proyecto;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProyectoLogica proy = new ProyectoLogica();
            proyecto = Convert.ToInt32(Session["idProyecto"]);
            string usuario = Session["usuario"].ToString();
            //string permiso = proy.obtienePermisoUsuario(usuario, proyecto);
            AccesoLogica user = new AccesoLogica();
            //idTarea = Convert.ToInt32(Request.QueryString["idTarea"]);
            //tarea = proy.obtieneDatosTarea(idTarea);
            LabelElimTareas.Text = "Se va a eliminar la cuenta, desea continuar?";
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            int proyecto = Convert.ToInt32(Session["idProyecto"]);
            Response.Redirect("~/pantallas/ListaProyectos.aspx");
        }

        protected void eliminarCuenta_Click(object sender, EventArgs e)
        {
            ProyectoLogica proy = new ProyectoLogica();
            bool respuesta = proy.eliminaCuenta(Session["usuario"].ToString());
            if (respuesta)
            {
                Session.Abandon();
                Response.Redirect("~/index.aspx");
            }
            else
            {
                LabelElimTareas.Text = "No se pudo realizar la baja de la cuenta!";
            }

        } 
    }
}