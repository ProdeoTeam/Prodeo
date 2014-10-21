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
                AccesoLogica datos = new AccesoLogica();

                string mailAVerificar = cripto.Desencriptar(HttpUtility.UrlDecode(Request.QueryString["verif"]));
                bool resultComprobacion = datos.verDuplicadoEmail(mailAVerificar);

                if (!resultComprobacion)//Devuelve FALSE si existe, por eso lo niego
                {
                    lblMensaje.Text = "El usuario existe.";
                }

                else 
                {
                    lblMensaje.Text = "El usuario que intenta registrar no existe o caducó el link de confirmacion.";
                }
            }
        }
    }
}