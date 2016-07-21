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
                sessionActiva.Visible = true;
                sessionInactiva.Visible = false;
                principalProyecto.Visible = true;
                userLogueado.Visible = true;
                userName.InnerHtml = Session["usuario"].ToString();
            }
            else
            {                
                sessionActiva.Visible = false;
                sessionInactiva.Visible = true;
                principalProyecto.Visible = false;
                userLogueado.Visible = false;
                linkMisProy.Visible = false;
                linkEditUser.Visible = false;
                linkEliminarCuenta.Visible = false;
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
                    sessionActiva.Visible = true;
                    sessionInactiva.Visible = false;
                    principalProyecto.Visible = true;
                    userLogueado.Visible = true;
                    userName.InnerHtml = Session["usuario"].ToString();
                    Response.Redirect("~/pantallas/seleccion.aspx");
                } 
            }
        }

        protected void closeSession_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/index.aspx");
        }

        protected void editarUsuario_Click(object sender, EventArgs e) 
        {            
            Response.Redirect("~/pantallas/Registro.aspx?edit=true");                                   
        }

        protected void eliminarCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pantallas/EliminarCuenta.aspx");
        }

        protected void misProyectos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pantallas/ListaProyectos.aspx");
        }
        
    }
}

