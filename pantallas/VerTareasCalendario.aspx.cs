using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Prodeo.pantallas
{
    public partial class VerTareasCalendario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["idProyecto"]
            if (!IsPostBack)
            {
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