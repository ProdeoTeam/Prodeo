using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Prodeo.pantallas
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }       

        protected void registroForm_Click(object sender, EventArgs e) 
        {
            if (Page.IsValid) 
            { 
                AccesoLogica logica = new AccesoLogica();
                bool registroExitoso = logica.insertaUsuario(usuario.Value, pass.Value, email.Value);
                if (registroExitoso)
                {
                    Response.Redirect("~/pantallas/seleccion.aspx");
                }
            }
        }

        protected void validarUsuarioRep(object source, ServerValidateEventArgs args)
        {
            AccesoLogica logica = new AccesoLogica();           
            bool usuarioValido = logica.verDuplicadoUser(usuario.Value);
            if (usuarioValido)
            {
                args.IsValid = true;
            }
            else 
            {
                args.IsValid = false;
            }            
        }

        protected void validarEmailRep(object source, ServerValidateEventArgs args)
        {
            AccesoLogica logica = new AccesoLogica();
            bool emailValido = logica.verDuplicadoEmail(email.Value);
            if (emailValido)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}