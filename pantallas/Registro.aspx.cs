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
            
            //Si entra a la pantalla en modo "edicion" y el usuario está logueado
            if (Request.QueryString["edit"] == "true") 
            {
                if (Session["usuario"] != null)
                {
                    h2Titulo.InnerText = "MODIFICAR DATOS";
                    CustomValUsuarioRep.Enabled = false;
                    ReqFieldValUsuario.Enabled = false;
                    CustomValEmailRep.Enabled = false;
                    ReqFieldValEmail.Enabled = false;
                    RegExpresValEmail.Enabled = false;
                    string usuarioLogueado = Session["usuario"].ToString();
                    contenBtnReg.Style.Add("display", "none");
                    txtUsuario.Value = usuarioLogueado;
                    txtUsuario.Disabled = true;
                    txtUsuario.Style.Add("color", "#12587B");
                    txtUsuario.Style.Add("font-weight", "bold");

                    string mailUsuario;
                    AccesoLogica logica = new AccesoLogica();
                    mailUsuario = logica.obtenerMailUser(usuarioLogueado);
                    txtEmail.Value = mailUsuario;
                    txtEmail.Disabled = true;
                    txtEmail.Style.Add("color", "#12587B");
                    txtEmail.Style.Add("font-weight", "bold");
                }

                else 
                {
                    contenBtnModif.Style.Add("display", "none");                
                }
            }

            else
            {
                contenBtnModif.Style.Add("display", "none");                
            }                
        }       

        protected void registroForm_Click(object sender, EventArgs e) 
        {
            if (Page.IsValid) 
            { 
                AccesoLogica logica = new AccesoLogica();
                MailLogica mailReg = new MailLogica();                
                CriptografiaLogica encriptaMail = new CriptografiaLogica();

                //Codifica y encripta la direccion de email
                string emailCodificado = HttpUtility.UrlEncode(encriptaMail.Encriptar(txtEmail.Value.Trim()));
                string urlVerificacion = string.Format("http://localhost:8090/pantallas/VerificarEmail.aspx?verif={0}", emailCodificado);

                //Guarda el usuario en la base de datos
                bool registroExitoso = logica.insertaUsuario(txtUsuario.Value, txtPass.Value, txtEmail.Value, emailCodificado);
                
                //Si pudo guardar el usuario en la BD le manda el mail
                if (registroExitoso)
                {                    
                    string estadoDeEnvio = mailReg.enviarMailRegistro(txtEmail.Value, urlVerificacion);
                    lblEstadoOperacion.Text = estadoDeEnvio;
                    //Response.Redirect("~/pantallas/seleccion.aspx");
                }
            }
        }

        protected void modifDatos_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AccesoLogica logica = new AccesoLogica();
                string usuarioLogueado = Session["usuario"].ToString();

                //Actualiza la pass del usuario en la base de datos
                bool actualizacionExitosa = logica.actualizaUsuario(usuarioLogueado, txtPass.Value);
                
                //Si pudo actualizar la pass del usuario en la BD lo informa en pantalla
                if (actualizacionExitosa)
                {
                    lblEstadoOperacion.Text = "Los datos se modificaron correctamente.";
                }
                else
                {
                    lblEstadoOperacion.Text = "Los datos no se pudieron modificar. Por favor, intente luego.";
                }
            }
            
        }
        
        protected void validarUsuarioRep(object source, ServerValidateEventArgs args)
        {
            AccesoLogica logica = new AccesoLogica();           
            bool usuarioValido = logica.verDuplicadoUser(txtUsuario.Value);
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
            bool emailValido = logica.verDuplicadoEmail(txtEmail.Value);
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