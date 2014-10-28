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
        public bool verificaUsuario(string usuario, string pass)
        {
            AccesoDatos datos = new AccesoDatos();
            bool verifica = datos.verificarUsuario(usuario, pass);
            return verifica;
        }

        public bool verDuplicadoUser(string usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            bool usuarioValid = datos.verUsuarioRep(usuario);
            return usuarioValid;
        }

        public bool verDuplicadoEmail(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            bool emailValid = datos.verEmailRep(email);
            return emailValid;
        }

        public bool insertaUsuario(string usuario, string pass, string email, string emailCodificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (datos.insertarUsuario(usuario, pass, email, emailCodificado) != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<Usuarios> obtieneListaUsuarios()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Usuarios> lista = datos.obtenerListaUsuarios();
            return lista;
        }

        public Usuarios obtieneUsuario(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuarios usuario = datos.obtenerUsuario(email);
            return usuario;
        }

        public bool activaUsuario(string email) 
        {
            AccesoDatos datos = new AccesoDatos();
            bool resultModif = datos.activarUsuario(email);
            return resultModif;
        }
    }
}
