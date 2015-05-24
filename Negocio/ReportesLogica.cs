using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
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
        public Datos.Reportes.DatosReportes obtenerTareasPorUsuario(int idProyecto)
        {
            Datos.Reportes.DatosReportes reporteSource = new Datos.Reportes.DatosReportes();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                reporteSource = datos.obtenerDatosTareasPorUsuario(idProyecto);
            }
            catch (Exception ex)
            {

            }
            return reporteSource;
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public Datos.Reportes.DatosReportes obtenerAvanceDelProyecto(int idProyecto)
        {
            ArrayList tareas = new ArrayList();
            DataTable tabla = new DataTable();
            AccesoDatos datos = new AccesoDatos();
            Datos.Reportes.DatosReportes reportesSource = new Datos.Reportes.DatosReportes();
            try
            {
                reportesSource = datos.obtenerDatosTareasPorUsuario(idProyecto);


            }
            catch (Exception ex)
            {

            }
            return reportesSource;
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public Datos.Reportes.DatosReportes obtenerTareasPorModulo(int idProyecto)
        {
            Datos.Reportes.DatosReportes reporteSource = new Datos.Reportes.DatosReportes();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                reporteSource = datos.obtenerDatosTareasPorModulos(idProyecto);
            }
            catch (Exception ex)
            {

            }
            return reporteSource;
        }


    }




}

