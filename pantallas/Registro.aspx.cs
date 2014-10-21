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
                MailRegistroLogica mailReg = new MailRegistroLogica();                
                CriptografiaLogica encriptaMail = new CriptografiaLogica();

                //Codifica y encripta la direccion de email
                string emailCodificado = HttpUtility.UrlEncode(encriptaMail.Encriptar(email.Value.Trim()));
                string urlVerificacion = string.Format("http://localhost:8090/pantallas/VerificarEmail.aspx?verif={0}", emailCodificado);

                //Guarda el usuario en la base de datos
                bool registroExitoso = logica.insertaUsuario(usuario.Value, pass.Value, email.Value, emailCodificado);
                
                //Si pudo guardar el usuario en la BD le manda el mail
                if (registroExitoso)
                {                    
                    string estadoDeEnvio = mailReg.enviarMailRegistro(email.Value, urlVerificacion);
                    lblEstadoMail.Text = estadoDeEnvio;
                    //Response.Redirect("~/pantallas/seleccion.aspx");
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