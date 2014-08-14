using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Data
    {
        public bool verificarUsuario(string usuario, string pass)
        {
            prodeoEntities prod = new prodeoEntities();
            bool userValid = false;
            var user = (from u in prod.Usuarios
                        where u.mail == usuario && u.password == pass
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
    }
}
