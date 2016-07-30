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
        #region "Proyecto"
        public bool insertaProyecto(string nombre, string descrip, DateTime fechaCreacion, DateTime fechaVencimiento, string alerta, string usuario, List<string> usuariosAsignados)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (datos.insertarProyecto(nombre,descrip,fechaCreacion,fechaVencimiento,alerta, usuario, usuariosAsignados) != 0)
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

        public bool actualizaProyecto(string nombre, string descrip, DateTime fechaCreacion, DateTime fechaVencimiento, string alerta, string usuario, List<string> usuariosAsignados, string idProyecto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (datos.actualizarProyecto(nombre, descrip, fechaCreacion, fechaVencimiento, alerta, usuario, usuariosAsignados, idProyecto) != 0)
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

        public List<DatosProyecto> obtieneListaProyecto(string usuario, int abiertoFinalizado)
        {
            AccesoDatos datos = new AccesoDatos();
            List<DatosProyecto> lista = datos.obtenerListaProyectos(usuario, abiertoFinalizado);
            return lista;

        }

        public string obtieneNombreProyecto(int idProyecto)
        {
            AccesoDatos datos = new AccesoDatos();
            string nombre = datos.obtenerNombreProyecto(idProyecto);
            return nombre;
        }

        public Proyectos obtieneDatosProyecto(string proyecto)
        {
            AccesoDatos datos = new AccesoDatos();
            int idProyecto = Convert.ToInt32(proyecto);
            Proyectos pro = datos.obtenerDatosProyecto(idProyecto);
            return pro;
        }

        public List<DatosParticipantesProyecto> obtieneParticipantes(string proyecto)
        {
            AccesoDatos datos = new AccesoDatos();
            int idProyecto = Convert.ToInt32(proyecto);
            List<DatosParticipantesProyecto> listaUsu = datos.obtenerParticipantes(idProyecto);

            return listaUsu;
        }

        public bool EliminaProyecto(int idProyecto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (datos.eliminarProyecto(idProyecto) != 0)
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

        public bool FinaizarProyecto(int idProyecto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (datos.finalizarProyecto(idProyecto) != 0)
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

        public bool ReabrirProyecto(int idProyecto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (datos.reabrirProyecto(idProyecto) != 0)
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

        #endregion
        #region "Modulos"
        public Modulos obtieneDatosModulo(int idModulo)
        {
            AccesoDatos datos = new AccesoDatos();
            Modulos mod = datos.obtenerDatosModulo(idModulo);
            return mod;
        }

        public bool insertaModulo(string nombre, string descrip, DateTime fechaCreacion, DateTime fechaInicio, DateTime fechaVencimiento, int proyecto, string usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (datos.insertarModulo(nombre, descrip, fechaCreacion, fechaInicio, fechaVencimiento, proyecto, usuario) != 0)
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

        public List<DatosModulo> obtieneListaModulos(string usuario, int proyecto, string permiso)
        {
            AccesoDatos datos = new AccesoDatos();
            List<DatosModulo> lista = datos.obtenerListaModulos(usuario, proyecto, permiso);
            return lista;

        }

        public int obtieneCantidadModulos(int proyecto)
        {
            AccesoDatos datos = new AccesoDatos();
            int cantidad = datos.obtenerCantidadModulos(proyecto);
            return cantidad;


        }

        public bool actualizaModulo(int idModulo, string nombre, string descrip, DateTime fechaVencimiento)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (datos.actualizarModulo(idModulo, nombre, descrip, fechaVencimiento) != 0)
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

        public bool EliminaModulo(int idModulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (datos.eliminarModulo(idModulo) != 0)
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

        #endregion
        #region "Tareas"
        public bool insertaTarea(string idModulo, string nombre, string descripcion, string comentario, DateTime fechaCreacion, DateTime fechaVencimiento, DateTime fechaInicio, int proyecto, string usuario, string avisos, string prioridad, string idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            int modulo = Convert.ToInt32(idModulo);
            int idUser = Convert.ToInt32(idUsuario);
            try
            {
                if (datos.insertarTarea(modulo, nombre, descripcion, comentario, fechaCreacion, fechaVencimiento, fechaInicio, proyecto, usuario, avisos, prioridad, idUser) != 0)
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

        public Tareas obtieneDatosTarea(int idTarea)
        {
            AccesoDatos datos = new AccesoDatos();
            Tareas tarea = datos.obtenerTareas(idTarea);
            return tarea;

        }

        public int obtieneCantidadTareaPend(int idModulo)
        {
            AccesoDatos datos = new AccesoDatos();
            int cantidad = datos.obtenerCantidadTareasPend(idModulo);
            return cantidad;

        }

        public bool ActualizaTarea(string idTarea, string idModulo, string nombre, string descripcion, string comentario, DateTime fechaCreacion, DateTime fechaVencimiento, DateTime fechaInicio, int proyecto, string usuario, string avisos, string prioridad, string idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            int modulo = Convert.ToInt32(idModulo);
            int idUser = Convert.ToInt32(idUsuario);
            int tarea = Convert.ToInt32(idTarea);
            try
            {
                if (datos.ActualizarTarea(tarea, modulo, nombre, descripcion, comentario, fechaCreacion, fechaVencimiento, fechaInicio, proyecto, usuario, avisos, prioridad, idUser) != 0)
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

        public bool EliminaTarea(string idTarea, string usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            int tarea = Convert.ToInt32(idTarea);
            try
            {
                if (datos.eliminarTarea(tarea, usuario) != 0)
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
        public bool finalizaTarea(string idTarea, string usuario, string comentario, string horas)
        {
            AccesoDatos datos = new AccesoDatos();
            int tarea = Convert.ToInt32(idTarea);
            try
            {
                if (datos.finalizarTarea(horas,usuario,tarea,comentario) != 0)
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

        public List<DatosTarea> obtieneListaTareas(int modulo)
        {
            AccesoDatos datos = new AccesoDatos();
            List<DatosTarea> lista = datos.obtenerListaTareas(modulo);
            if (lista.Count() > 0)
            {
                foreach (DatosTarea lis in lista)
                {
                    int result = DateTime.Compare(lis.FechaLimite, DateTime.Now);
                    if(lis.Estado != "Finalizada")
                    {
                        if (result > 0)
                        {
                            lis.Estado = "Pendiente";
                        }
                        else if (result == 0)
                        {
                            lis.Estado = "Pendiente";
                        }
                        else
                        {
                            lis.Estado = "Vencido";
                        }
                    }
                    
                }
            }
            return lista;

        }

        public List<DatosTarea> obtieneListaTareasUsusario(int modulo, string usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<DatosTarea> lista = datos.obtenerListaTareasUsuario(modulo, usuario);
            foreach (DatosTarea dato in lista)
            {

                int result = DateTime.Compare(dato.FechaLimite, DateTime.Now);
                if (result > 0)
                {
                    dato.Estado = "Pendiente";
                }
                else if (result == 0)
                {
                    dato.Estado = "Pendiente";
                }
                else
                {
                    dato.Estado = "Vencido";
                }

            }
            return lista;

        }

        #endregion

        #region "Usuarios"

        public bool verificaUsuarioRegistrado(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            bool existe = datos.verificarUsusarioRegistrado(email);
            return existe;
        }

        public string obtienePermisoUsuario(string usuario, int idProyecto)
        {
            AccesoDatos datos = new AccesoDatos();
            string permiso = datos.obtenerPermisoUsuario(usuario, idProyecto);
            return permiso;
        }

        public bool eliminaCuenta(string usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            bool exito = datos.eliminarCuenta(usuario);
            return exito;

        }

        public bool desvincularProyecto(string usuario, int idProyecto)
        {
            AccesoDatos datos = new AccesoDatos();
            bool exito = datos.desvincularProyecto(usuario, idProyecto);
            return exito;

        }
        #endregion

    }
}
