using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using AjaxPro;
using Negocio;
using Datos;
namespace Prodeo.pantallas
{
    public partial class VerTareasCalendario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["idProyecto"]
            if (!IsPostBack)
            {
                int idProyecto = Convert.ToInt32(Request.QueryString["idProyecto"]);
                int idModulo = Convert.ToInt32(Request.QueryString["idModulo"]);
                Utility.RegisterTypeForAjax(typeof(ReportesLogica));
                //Session["idProyecto"]
            }
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        private ArrayList obtenerTareas()
        {
            ArrayList aTareas = new ArrayList();
            ArrayList aUnaTarea = new ArrayList();
            Negocio.ReportesLogica neg = new Negocio.ReportesLogica();
            try
            {
                //Crear un array con arrays de 2 posiciones: (0)->Nombre (1)->FechaInicio (2)->FechaVencimiento
                
            }
            catch (Exception)
            {
                aTareas = new ArrayList();
            }
            return aTareas;
        }
    }
}