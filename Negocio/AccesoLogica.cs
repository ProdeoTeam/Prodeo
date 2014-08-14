using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class AccesoLogica
    {
        public bool VerificaUsuario(string usuario, string pass)
        { 
            Data datos = new Data();
            bool verifica = datos.verificarUsuario(usuario, pass);
            return verifica;
        }
    }
}
