using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using Negocio.Clases_Entidad;
using Datos;
//using AjaxPro;

namespace Negocio
{

    [AjaxPro.AjaxNamespace("AjaxReportes")]
    /// <summary>
    /// Devuelve un array de arrays de 2 posiciones. La primer posicion de los arrays contenidos tiene una descripcion y la segunda el valor numerico.
    /// </summary>
    public class ReportesLogica
    {
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public ArrayList obtenerTareasPorUsuario(int idProyecto)
        {
            ArrayList tareas = new ArrayList();
            ArrayList auxtarea;
            DataTable tabla = new DataTable();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                tabla = datos.simularDatosTareasPorUsuario();

                foreach (DataRow unaFila in tabla.Rows)
                {
                    ReporteModel tareasDeUnUsuario;
                    Boolean yaSeAgrego = false;
                    for (int i = 0; i < tareas.Count; i++)
                    {
                        tareasDeUnUsuario = (ReporteModel)tareas[i];
                        if (tareasDeUnUsuario.Nombre == unaFila["usuario"].ToString())
                        {
                            yaSeAgrego = true;
                            if ((string)unaFila["estado"] == "Pendiente")
                            {
                                if ((string)unaFila["condicionvencimiento"] == "Vencida")
                                {
                                    tareasDeUnUsuario.TareasPendientesVencidas = Convert.ToInt32(unaFila["cantidad"]);
                                }
                                else
                                {
                                    tareasDeUnUsuario.TareasPendientesNoVencidas = Convert.ToInt32(unaFila["cantidad"]);
                                }
                            }
                            else
                            {
                                tareasDeUnUsuario.TareasFinalizadas = Convert.ToInt32(unaFila["cantidad"]);
                            }
                        }
                    }
                    if (!yaSeAgrego)
                    {
                        tareasDeUnUsuario = new ReporteModel();
                        tareasDeUnUsuario.Nombre = unaFila["usuario"].ToString();
                        if ((string)unaFila["estado"] == "Pendiente")
                        {
                            if ((string)unaFila["condicionvencimiento"] == "Vencida")
                            {
                                tareasDeUnUsuario.TareasPendientesVencidas = Convert.ToInt32(unaFila["cantidad"]);
                            }
                            else
                            {
                                tareasDeUnUsuario.TareasPendientesNoVencidas = Convert.ToInt32(unaFila["cantidad"]);
                            }

                        }
                        else
                        {
                            tareasDeUnUsuario.TareasFinalizadas = Convert.ToInt32(unaFila["cantidad"]);
                        }
                        tareas.Add(tareasDeUnUsuario);
                    }
                }

                //auxtarea = new ArrayList();
                //auxtarea.Add("Carlos");
                //auxtarea.Add(10);
                //tareas.Add(auxtarea);
                //auxtarea = new ArrayList();
                //auxtarea.Add("Pedro");
                //auxtarea.Add(20);
                //tareas.Add(auxtarea);
                //auxtarea = new ArrayList();
                //auxtarea.Add("Raul");
                //auxtarea.Add(30);
                //tareas.Add(auxtarea);

            }
            catch (Exception ex)
            {

            }
            return tareas;
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public ArrayList obtenerAvanceDelProyecto(int idProyecto)
        {
            ArrayList tareas = new ArrayList();
            DataTable tabla = new DataTable();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                tabla = datos.simularDatosTareasPorUsuario();

                foreach (DataRow unaFila in tabla.Rows)
                {
                    ReporteModel tareasDeUnUsuario;
                    Boolean yaSeAgrego = false;
                    for (int i = 0; i < tareas.Count; i++)
                    {
                        tareasDeUnUsuario = (ReporteModel)tareas[i];
                        if (tareasDeUnUsuario.Nombre == unaFila["usuario"].ToString())
                        {
                            yaSeAgrego = true;
                            if ((string)unaFila["estado"] == "Pendiente")
                            {
                                if ((string)unaFila["condicionvencimiento"] == "Vencida")
                                {
                                    tareasDeUnUsuario.TareasPendientesVencidas = Convert.ToInt32(unaFila["cantidad"]);
                                }
                                else
                                {
                                    tareasDeUnUsuario.TareasPendientesNoVencidas = Convert.ToInt32(unaFila["cantidad"]);
                                }
                            }
                            else
                            {
                                tareasDeUnUsuario.TareasFinalizadas = Convert.ToInt32(unaFila["cantidad"]);
                            }
                        }
                    }
                    if (!yaSeAgrego)
                    {
                        tareasDeUnUsuario = new ReporteModel();
                        tareasDeUnUsuario.Nombre = unaFila["usuario"].ToString();
                        if ((string)unaFila["estado"] == "Pendiente")
                        {
                            if ((string)unaFila["condicionvencimiento"] == "Vencida")
                            {
                                tareasDeUnUsuario.TareasPendientesVencidas = Convert.ToInt32(unaFila["cantidad"]);
                            }
                            else
                            {
                                tareasDeUnUsuario.TareasPendientesNoVencidas = Convert.ToInt32(unaFila["cantidad"]);
                            }

                        }
                        else
                        {
                            tareasDeUnUsuario.TareasFinalizadas = Convert.ToInt32(unaFila["cantidad"]);
                        }
                        tareas.Add(tareasDeUnUsuario);
                    }
                }

                //auxtarea = new ArrayList();
                //auxtarea.Add("Carlos");
                //auxtarea.Add(10);
                //tareas.Add(auxtarea);
                //auxtarea = new ArrayList();
                //auxtarea.Add("Pedro");
                //auxtarea.Add(20);
                //tareas.Add(auxtarea);
                //auxtarea = new ArrayList();
                //auxtarea.Add("Raul");
                //auxtarea.Add(30);
                //tareas.Add(auxtarea);

            }
            catch (Exception ex)
            {

            }
            return tareas;
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public ArrayList obtenerTareasPorModulo(int idProyecto)
        {
            ArrayList tareas = new ArrayList();
            ArrayList auxtarea;
            DataTable tabla = new DataTable();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                tabla = datos.simularDatosTareasPorModulo();

                foreach (DataRow unaFila in tabla.Rows)
                {
                    ReporteModel tareasDeUnModulo;
                    Boolean yaSeAgrego = false;
                    for (int i = 0; i < tareas.Count; i++)
                    {
                        tareasDeUnModulo = (ReporteModel)tareas[i];
                        if (tareasDeUnModulo.Nombre == unaFila["modulo"].ToString())
                        {
                            yaSeAgrego = true;
                            if ((string)unaFila["estado"] == "Pendiente")
                            {
                                if ((string)unaFila["condicionvencimiento"] == "Vencida")
                                {
                                    tareasDeUnModulo.TareasPendientesVencidas = Convert.ToInt32(unaFila["cantidad"]);
                                }
                                else
                                {
                                    tareasDeUnModulo.TareasPendientesNoVencidas = Convert.ToInt32(unaFila["cantidad"]);
                                }
                            }
                            else
                            {
                                tareasDeUnModulo.TareasFinalizadas = Convert.ToInt32(unaFila["cantidad"]);
                            }
                        }
                    }
                    if (!yaSeAgrego)
                    {
                        tareasDeUnModulo = new ReporteModel();
                        tareasDeUnModulo.Nombre = unaFila["modulo"].ToString();
                        if ((string)unaFila["estado"] == "Pendiente")
                        {
                            if ((string)unaFila["condicionvencimiento"] == "Vencida")
                            {
                                tareasDeUnModulo.TareasPendientesVencidas = Convert.ToInt32(unaFila["cantidad"]);
                            }
                            else
                            {
                                tareasDeUnModulo.TareasPendientesNoVencidas = Convert.ToInt32(unaFila["cantidad"]);
                            }

                        }
                        else
                        {
                            tareasDeUnModulo.TareasFinalizadas = Convert.ToInt32(unaFila["cantidad"]);
                        }
                        tareas.Add(tareasDeUnModulo);
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return tareas;
        }


    }




}

