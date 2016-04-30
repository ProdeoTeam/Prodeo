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
        public ArrayList obtenerAvanceDelProyecto(int idProyecto)
        {
            ArrayList datosSerie = new ArrayList();
            AccesoDatos datos = new AccesoDatos();
            //Debe devolver un array con arrays de 2 posiciones. la posicion 0 debe tener el nombre de la porcion y la 1 el valor.
            //ejemplo: [[vencidas, 2],[no vencidas, 3],[finalizadas, 4]]
            try
            {
                datosSerie = datos.obtenerDatosAvanceDelProyecto(idProyecto);


            }
            catch (Exception ex)
            {

            }
            return datosSerie;
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

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public ArrayList obtenerTareasCalendario(int idProyecto, int idModulo)
        {
            ArrayList reporteSource = new ArrayList();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                reporteSource = datos.obtenerDatosTareasDeModuloParaCalendario(idProyecto,idModulo);
            }
            catch (Exception ex)
            {

            }
            return reporteSource;
        }

    }




}

