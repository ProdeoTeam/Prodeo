using System;
using System.Collections.Generic;
using Datos;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProyectoLogica
    {
        public bool insertaProyecto(string nombre, string descrip, DateTime fechaCreacion, DateTime fechaVencimiento, string alerta, string usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (datos.insertarProyecto(nombre,descrip,fechaCreacion,fechaVencimiento,alerta, usuario) != 0)
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

        public bool insertaModulo(string nombre, string descrip, DateTime fechaCreacion, DateTime fechaVencimiento, int proyecto, string usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (datos.insertarModulo(nombre, descrip, fechaCreacion, fechaVencimiento, proyecto, usuario) != 0)
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

        public bool insertaTarea(string idModulo, string nombre, string descripcion, string comentario, DateTime fechaCreacion, DateTime fechaVencimiento, int proyecto, string usuario, string avisos, string prioridad, string idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            int modulo = Convert.ToInt32(idModulo);
            int idUser = Convert.ToInt32(idUsuario);
            try
            {
                if (datos.insertarTarea(modulo, nombre, descripcion, comentario, fechaCreacion, fechaVencimiento, proyecto, usuario, avisos, prioridad, idUser) != 0)
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

        public List<DatosProyecto> obtieneListaProyecto(string usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<DatosProyecto> lista = datos.obtenerListaProyectos(usuario);
            return lista;

        }
        public List<DatosModulo> obtieneListaModulos(string usuario, int proyecto)
        {
            AccesoDatos datos = new AccesoDatos();
            List<DatosModulo> lista = datos.obtenerListaModulos(usuario, proyecto);
            return lista;

        }

        public List<DatosTarea> obtieneListaTareas(int modulo)
        {
            AccesoDatos datos = new AccesoDatos();
            List<DatosTarea> lista = datos.obtenerListaTareas(modulo);
            if (lista.Count() > 0)
            {
                int result = DateTime.Compare(Convert.ToDateTime(lista[0].FechaLimite), DateTime.Now);
                if (result > 0)
                {
                    lista[0].Estado = "Pendiente";
                }
                else if (result == 0)
                {
                    lista[0].Estado = "Pendiente";
                }
                else
                {
                    lista[0].Estado = "Vencido";
                }
            }
            return lista;

        }

        public string obtieneNombreProyecto(int idProyecto)
        {
            AccesoDatos datos = new AccesoDatos();
            string nombre = datos.obtenerNombreProyecto(idProyecto);
            return nombre;
        }

        public bool verificaUsuarioRegistrado(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            bool existe = datos.verificarUsusarioRegistrado(email);
            return existe;
        }
    }
}
