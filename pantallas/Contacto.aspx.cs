using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
namespace Prodeo.pantallas
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            MailLogica mailUtil = new MailLogica();
            mailUtil.enviarMailContacto(txtNombre.Value, txtEmail.Value, txtAsunto.Value, txtAreaMensaje.Value);
            MostrarMensaje("Mensaje enviado. Gracias por contactarse con nosotros!");
        }

        public void MostrarMensaje(string msj){
            string scriptMsj;
            scriptMsj = "<script type='text/javascript'>";
            scriptMsj = "alert('" + msj + "');";
            scriptMsj = "</script>";
            Response.Write(scriptMsj);
        }
    }
}