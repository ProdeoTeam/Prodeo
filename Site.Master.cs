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

        }

        protected void loginForm_Click(object sender, EventArgs e)
        {
            AccesoLogica access = new AccesoLogica();
            bool acceso = access.verificaUsuario(usuario.Value, pass.Value);
            if (acceso)
            {
                Session.Add("usuario",usuario.Value);
                Response.Redirect("~/pantallas/seleccion.aspx");
            }
        }
    }
}
