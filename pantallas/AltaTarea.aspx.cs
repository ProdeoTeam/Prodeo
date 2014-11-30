using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Prodeo.pantallas
{
    public partial class AltaTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProyectoLogica proy = new ProyectoLogica();
                int proyecto = Convert.ToInt32(Session["idProyecto"]);
                Session["permiso"] = "A";
                string usuario = Session["usuario"].ToString();
                string permiso = proy.obtienePermisoUsuario(usuario, proyecto);
                AccesoLogica user = new AccesoLogica();
                listaModulos.DataSource = proy.obtieneListaModulos(usuario, proyecto, permiso);
                listaModulos.DataValueField = "IdModulo";
                listaModulos.DataTextField = "Nombre";
                listaModulos.DataBind();
                usuariosLista.DataSource = user.obtieneListaUsuarios(proyecto);
                usuariosLista.DataValueField = "idUsuario";
                usuariosLista.DataTextField = "nombre";
                usuariosLista.DataBind();
            }
        }

        protected void altaTareaForm_Click(object sender, EventArgs e)
        {
            int proyecto = Convert.ToInt32(Session["idProyecto"]);
            string usuario = Session["usuario"].ToString();
            Session["permiso"] = "A";
            ProyectoLogica agregaTarea = new ProyectoLogica();
            bool altaExitosa = agregaTarea.insertaTarea(listaModulos.Value, nombreTarea.Value, descripcion.Value, comentario.Value, DateTime.Now, Convert.ToDateTime(fechaVencimiento.Value), proyecto, usuario, avisoVencimientos.Value, listaPrioridad.Value, usuariosLista.Value);
            if (altaExitosa)
            {
                Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto + "&p=A");
            }
        }

        protected void cancelarTareaForm_Click(object sender, EventArgs e)
        {
            int proyecto = Convert.ToInt32(Session["idProyecto"]);
            Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto);
        }
    }
}