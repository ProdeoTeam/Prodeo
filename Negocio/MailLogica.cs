using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace Negocio
{
    public class MailLogica
    {
        public string enviarMailRegistro(string destinatario, string urlVerificacion)
        {
            //Define instancia de la clase MailMessage
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(destinatario));
            email.From = new MailAddress("prodeoteam@gmail.com");
            //email.Subject = "Asunto ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
            email.Subject = "Bienvenido a prodeo";
            email.Body = "Le damos la bienvenida a <b>PRODEO</b>. Para finalizar el registro, por favor haga clic en el siguiente link: <a href=\"" + urlVerificacion + "\">Finalizar registro</a><p>Si el link no funciona en su navegador, pegue la siguiente dirección en una nueva pestaña:</p><b>"+urlVerificacion+"</b><br/><p>Muchas gracias.</p>";                            
            email.IsBodyHtml = true;
            //email.Priority = MailPriority.Normal;

            //Define la instancia de SMTP
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("prodeoteam@gmail.com", "equipoprodeo");

            string output = null;

            //Envío del correo
            try
            {
                smtp.Send(email);
                email.Dispose();
                output = "Le env&iacute;amos un link a su correo para que pueda finalizar el registro.";
            }
            catch (Exception ex)
            {
                output = "No pudimos enviarle el mail de confirmaci&oacute;n, por favor chequee su conexi&oacute;n a Internet.";
                //output = "Error enviando correo electrónico: " + ex.Message;
            }
        
            return output;
        }

        public bool enviarMailContacto(string nombreContacto, string mailContacto, string asunto, string mensajeContacto)
        {
            bool envioOk = false;
            AccesoDatos datos;
            string cuerpoMail;
            try
            {
                datos = new AccesoDatos();
                cuerpoMail = "Asunto: " + asunto + System.Environment.NewLine;
                cuerpoMail = "Nombre: " + nombreContacto + System.Environment.NewLine;
                cuerpoMail = "Mail: " + mailContacto + System.Environment.NewLine;
                cuerpoMail = "Mensaje: " + mensajeContacto + System.Environment.NewLine;
                if (datos.insertarMail(0, 0, 0, "Mail de contacto de usuario " + nombreContacto, cuerpoMail, "prodeoteam@gmail.com") >= 0)
                {
                    envioOk = true;
                } 
            }
            catch (Exception)
            {
                envioOk = false;
            }
            return envioOk;
        }

        public bool enviarMailNewsletter(string nombreContacto, string mailContacto, string asunto, string mensajeContacto)
        {
            bool envioOk = false;
            AccesoDatos datos;
            string cuerpoMail;
            try
            {
                datos = new AccesoDatos();
                cuerpoMail = "Asunto: " + asunto + "</br>";
                cuerpoMail = cuerpoMail + "Nombre: " + nombreContacto + "</br>";
                cuerpoMail = cuerpoMail + "Mail: " + mailContacto + "</br>";
                cuerpoMail = cuerpoMail + "Mensaje: " + mensajeContacto + "</br>";
                if (datos.insertarMail(0, 0, 0, "Solicitud de Newsletter " + nombreContacto, cuerpoMail, "prodeoteam@gmail.com") >= 0)
                {
                    envioOk = true;
                }
            }
            catch (Exception)
            {
                envioOk = false;
            }
            return envioOk;
        }

        public bool enviarMail(int idModulo, int idProyecto, int idTarea, string asunto, string detalle, string destinatarios)
        {
            bool envioOk = false;
            AccesoDatos datos;
            try
            {
                datos = new AccesoDatos();
                if (datos.insertarMail(idModulo,idProyecto,idTarea,asunto,detalle,destinatarios) >= 0)
                {
                    envioOk = true;
                }
            }
            catch (Exception)
            {
                envioOk = false;
            }
            return envioOk;
        }
    }
}
