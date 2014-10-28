using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prodeo.pantallas
{
    public partial class VerificarEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            { 
                CriptografiaLogica cripto = new CriptografiaLogica();
                string mailAVerificar = cripto.Desencriptar(HttpUtility.UrlDecode(Request.QueryString["verif"]));

                if (mailAVerificar != "urlInvalida")
                {
                    AccesoLogica logica = new AccesoLogica();
                    bool resultComprobacion = logica.verDuplicadoEmail(mailAVerificar);

                    if (!resultComprobacion)//Devuelve FALSE si existe, por eso lo niego
                    {                        
                        var user = logica.obtieneUsuario(mailAVerificar); //Obtiene el usuario entero
                        if (user.usuarioActivo == true)
                        {
                            lblMensaje.Text = user.nombre + ", su usuario ya fue activado y puede usar su cuenta completamente.";
                        }
                        else 
                        {
                            bool resultModificacion = logica.activaUsuario(user.mail);
                            if (resultModificacion == true)
                            {
                                lblMensaje.Text = "Bienvenido " + user.nombre + ". Su usuario fue activado correctamente.";
                            }
                            else 
                            {
                                lblMensaje.Text = "En este momento no pudimos validar su usuario, por favor intente nuevamente más tarde";
                            }
                        }
                    }

                    else
                    {
                        lblMensaje.Text = "El usuario que intenta registrar no existe o caducó el link de confirmacion.";
                    }
                }
                else 
                {
                    lblMensaje.Text = "La url es inválida";
                }
            }
        }
    }
}