using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AccesoDatos
    {
        //validación para el login
        public bool verificarUsuario(string usuario, string pass)
        {
            prodeoEntities prod = new prodeoEntities();
            bool userValid = false;
            MD5 md5Hash = MD5.Create();
            string passMd5 = GetMd5Hash(md5Hash, pass);
            var user = (from u in prod.Usuarios
                        where u.nombre == usuario && u.password == passMd5
                        select u).Count();
            if (user != 0)
            {
                userValid = true;
            }
            else
            {
                userValid = false;
            }
            return userValid;
        }

        //validación para que no se registre con un usuario que ya existe
        public bool verUsuarioRep(string usuario)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            bool usuarioVal = false;
            var user = (from u in prodeoContext.Usuarios
                        where u.nombre == usuario
                        select u).Count();
            if (user == 0)
            {
                return usuarioVal = true;
            }
            else
            {
               return usuarioVal = false;
            }            
        }

        //validación para que no se registre con un mail que ya existe
        public bool verEmailRep(string email)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            bool emailVal = false;
            var emailReg = (from e in prodeoContext.Usuarios
                        where e.mail == email
                        select e).Count();
            if (emailReg == 0)
            {
                return emailVal = true;
            }
            else
            {
                return emailVal = false;
            }            
        }

        //guarda los datos de registro en la BD
        public int insertarUsuario(string usuario, string pass, string email)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            Usuarios nuevoUsuario = new Usuarios();
            MD5 md5Hash = MD5.Create();
            string passMd5 = GetMd5Hash(md5Hash, pass);
            nuevoUsuario.nombre = usuario;
            nuevoUsuario.password = passMd5;
            nuevoUsuario.mail = email;
            prodeoContext.Usuarios.Add(nuevoUsuario);
            return prodeoContext.SaveChanges(); //SaveChanges devuelve el N° de objetos escritos en la BD            
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }

        public int insertarProyecto(string nombre, string descrip, DateTime fechaCreacion, DateTime fechaVencimiento, string alerta)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            Proyectos proy = new Proyectos();
            proy.Nombre = nombre;
            proy.Descripcion = descrip;
            proy.FechaCreacion = fechaCreacion;
            proy.FechaVencimiento = fechaVencimiento;
            proy.AlertaPrevia = alerta;
            prodeoContext.Proyectos.Add(proy);
            return prodeoContext.SaveChanges();
        }

    }
}
