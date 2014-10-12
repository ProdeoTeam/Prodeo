using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using Negocio.Clases_Entidad;
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
            try
            {
                tabla = this.simularDatosTareasPorUsuario();

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
            try
            {
                tabla = this.simularDatosTareasPorUsuario();

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
            try
            {
                tabla = this.simularDatosTareasPorModulo();

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


        private DataTable simularDatosTareasPorUsuario()
        {
            DataTable tabla = new DataTable();
            DataColumn columna = new DataColumn();
            DataRow fila;
            columna.ColumnName = "usuario";
            tabla.Columns.Add(columna);
            columna = new DataColumn();
            columna.ColumnName = "estado";
            tabla.Columns.Add(columna);
            columna = new DataColumn();
            columna.ColumnName = "condicionvencimiento";
            tabla.Columns.Add(columna);
            columna = new DataColumn();
            columna.ColumnName = "cantidad";
            tabla.Columns.Add(columna);

            fila = tabla.NewRow();
            fila["usuario"] = "Rodolfo";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "NoVencida";
            fila["cantidad"] = 30;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["usuario"] = "Rodolfo";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "Vencida";
            fila["cantidad"] = 20;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["usuario"] = "Rodolfo";
            fila["estado"] = "Finalizado";
            fila["condicionvencimiento"] = "";
            fila["cantidad"] = 10;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["usuario"] = "Jose";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "NoVencida";
            fila["cantidad"] = 35;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["usuario"] = "Jose";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "Vencida";
            fila["cantidad"] = 25;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["usuario"] = "Jose";
            fila["estado"] = "Finalizado";
            fila["condicionvencimiento"] = "";
            fila["cantidad"] = 15;
            tabla.Rows.Add(fila);

            return tabla;
        }

        private DataTable simularDatosTareasPorModulo()
        {
            DataTable tabla = new DataTable();
            DataColumn columna = new DataColumn();
            DataRow fila;
            columna.ColumnName = "modulo";
            tabla.Columns.Add(columna);
            columna = new DataColumn();
            columna.ColumnName = "estado";
            tabla.Columns.Add(columna);
            columna = new DataColumn();
            columna.ColumnName = "condicionvencimiento";
            tabla.Columns.Add(columna);
            columna = new DataColumn();
            columna.ColumnName = "cantidad";
            tabla.Columns.Add(columna);

            fila = tabla.NewRow();
            fila["modulo"] = "Comprar Elementos";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "NoVencida";
            fila["cantidad"] = 30;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["modulo"] = "Comprar Elementos";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "Vencida";
            fila["cantidad"] = 20;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["modulo"] = "Comprar Elementos";
            fila["estado"] = "Finalizado";
            fila["condicionvencimiento"] = "";
            fila["cantidad"] = 10;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["modulo"] = "Pintado";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "NoVencida";
            fila["cantidad"] = 35;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["modulo"] = "Pintado";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "Vencida";
            fila["cantidad"] = 25;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["modulo"] = "Pintado";
            fila["estado"] = "Finalizado";
            fila["condicionvencimiento"] = "";
            fila["cantidad"] = 15;
            tabla.Rows.Add(fila);

            return tabla;
        }
    }




}

