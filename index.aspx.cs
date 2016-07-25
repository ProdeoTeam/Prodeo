using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Prodeo
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            MailLogica mailUtil = new MailLogica();
            mailUtil.enviarMailNewsletter(txtName.Value, txtEmail.Value, "Newsletter", "Me gustaría recibir sus newsletters!");
            MostrarMensaje("Mensaje enviado. Gracias por contactarse con nosotros!");
        }

        public void MostrarMensaje(string msj)
        {
            string scriptMsj;
            scriptMsj = "<script type='text/javascript'>";
            scriptMsj = "alert('" + msj + "');";
            scriptMsj = "</script>";
            Response.Write(scriptMsj);
        }
    }
}