using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Prodeo
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                sessionActiva.Style.Add("display", "block");
                sessionInactiva.Style.Add("display", "none");
                principalProyecto.Style.Add("display", "block");
            } 
            else
            {
                sessionActiva.Style.Add("display", "none");
                sessionInactiva.Style.Add("display", "block");
                principalProyecto.Style.Add("display", "none");
            }
        }

        protected void loginForm_Click(object sender, EventArgs e)
        {
            AccesoLogica access = new AccesoLogica();
            bool acceso = access.verificaUsuario(usuario.Value, pass.Value);
            if (acceso)
            {
                Session["usuario"] = usuario.Value;
                if (Session["usuario"] != null)
                {
                    sessionActiva.Style.Add("display", "block");
                    sessionInactiva.Style.Add("display", "none");
                    principalProyecto.Style.Add("display", "block");
                    Response.Redirect("~/pantallas/seleccion.aspx");
                } 
            }
        }

        protected void closeSession_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/index.aspx");
        }
    }
}

