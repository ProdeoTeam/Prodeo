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
                int proyecto = Convert.ToInt32(Session["idProyecto"]);
                string usuario = Session["usuario"].ToString();
                ProyectoLogica proy = new ProyectoLogica();
                listaModulos.DataSource = proy.obtieneListaModulos(usuario, proyecto);
                listaModulos.DataValueField = "IdModulo";
                listaModulos.DataTextField = "Nombre";
                listaModulos.DataBind();
            }
        }

        protected void altaTareaForm_Click(object sender, EventArgs e)
        {
            int proyecto = Convert.ToInt32(Session["idProyecto"]);
            string usuario = Session["usuario"].ToString();
            ProyectoLogica agregaTarea = new ProyectoLogica();
            bool altaExitosa = agregaTarea.insertaTarea(listaModulos.Value, nombreTarea.Value, descripcion.Value, comentario.Value, DateTime.Now, Convert.ToDateTime(fechaVencimiento.Value), proyecto, usuario, avisoVencimientos.Value);
            if (altaExitosa)
            {
                Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto);
            }
        }
    }
}