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
    //[AjaxPro.AjaxNamespace("AjaxReportes")]
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Utility.RegisterTypeForAjax(typeof(Negocio.AjaxReportes));
            //Utility.RegisterTypeForAjax(typeof(Reportes));
            if(!IsPostBack)
            {
                Utility.RegisterTypeForAjax(typeof(ReportesLogica));
                string usuario = Session["usuario"].ToString();
                ProyectoLogica proy = new ProyectoLogica();
            
                proyectosLista.DataSource = proy.obtieneListaProyecto(Session["usuario"].ToString());
                proyectosLista.DataValueField = "Id";
                proyectosLista.DataTextField = "Nombre";
                proyectosLista.DataBind();
            }
        }

        [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
        public ArrayList obtenerTareasPorUsuario()
        {
            Negocio.ReportesLogica reporteLogica = new Negocio.ReportesLogica();
            ArrayList datosReporte = new ArrayList();

            datosReporte = reporteLogica.obtenerTareasPorUsuario(1);
            return datosReporte;
        }
    }
}