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

        public bool insertaTarea(string idModulo, string nombre, string descripcion, string comentario, DateTime fechaCreacion, DateTime fechaVencimiento, int proyecto, string usuario, string avisos)
        {
            AccesoDatos datos = new AccesoDatos();
            int modulo = Convert.ToInt32(idModulo);
            try
            {
                if (datos.insertarTarea(modulo, nombre, descripcion, comentario, fechaCreacion, fechaVencimiento, proyecto, usuario, avisos) != 0)
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
            return lista;

        }
    }
}
