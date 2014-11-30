using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Prodeo
{
    public partial class AltaModulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void altaModuloForm_Click(object sender, EventArgs e)
        {
            int proyecto = Convert.ToInt32(Session["idProyecto"]);
            string usuario = Session["usuario"].ToString();
            Session["permiso"] = "A";
            ProyectoLogica agregaModulo = new ProyectoLogica();
            bool altaExitosa = agregaModulo.insertaModulo(nombreModulo.Value, descripcion.Value, DateTime.Now, Convert.ToDateTime(fechaVencimiento.Value), proyecto, usuario);
            if (altaExitosa)
            {
                Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto="+proyecto+"&p=A");
            }
        }

        protected void cancelarModuloForm_Click(object sender, EventArgs e)
        {
            int proyecto = Convert.ToInt32(Session["idProyecto"]);
            Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto);

        }
    }
}