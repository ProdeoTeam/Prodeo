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
    public partial class EliminarModulo : System.Web.UI.Page
    {
        public int idModulo;
        public Modulos modulo;
        public int proyecto;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
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
                idModulo = Convert.ToInt32(Request.QueryString["idModulo"]);
                modulo = proy.obtieneDatosModulo(idModulo);
                LabelElimTareas.Text = "Se va a eliminar el modulo " + modulo.Nombre + ", desea continuar?";
            }
                
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            int proyecto = Convert.ToInt32(Session["idProyecto"]);
            Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto + "&p=" + Session["permiso"]);
        }

        protected void eliminarModulo_Click(object sender, EventArgs e)
        {
            ProyectoLogica proy = new ProyectoLogica();
            bool respuesta = proy.EliminaModulo(idModulo);
            if (respuesta)
            {
                Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto + "&p=" + Session["permiso"]);
            }
            else
            {
                LabelElimTareas.Text = "No se pudo realizar la baja del modulo " + modulo.Nombre + "!";
            }

        }   
    }
}