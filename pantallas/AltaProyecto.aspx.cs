using System;
using System.Collections.Generic;
using System.Linq;
using Negocio;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prodeo.pantallas
{
    public partial class AltaProyecto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void altaProyForm_Click(object sender, EventArgs e)
        {
            string usuario = Session["usuario"].ToString();
            ProyectoLogica agregaProyecto = new ProyectoLogica();
            bool altaExitosa = agregaProyecto.insertaProyecto(nombreProyecto.Value, descripcion.Value, DateTime.Now, Convert.ToDateTime(fechaVencimiento.Value), avisoVencimientos.Value,usuario);
            if (altaExitosa)
            {
                Response.Redirect("~/pantallas/ListaProyectos.aspx");
            }
        }
    }
}