using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Prodeo.pantallas
{
    public partial class VerProyecto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            presentarContenidoProyecto();

        }
        /// <summary>
        /// Se devuelve un datatable con todos las tareas del proyecto.
        /// </summary>
        /// <returns></returns>
        System.Data.DataTable obtenerTareas()
        {
            DataTable dtTareas = new DataTable();
            DataColumn unaColumna;
            //una de las columnas tiene que ser el modulo para agruparlas cuando las queremos presentar en accordion
            unaColumna = new DataColumn("NombreModulo");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("NombreTarea");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("EstadoTarea");
            dtTareas.Columns.Add(unaColumna);

            for (int i = 1; i < 5; i++)
            {
                string nombreModulo = "Modulo " + i;
                for (int j = 0; j < 4; j++)
                {
                    DataRow dr = dtTareas.NewRow();
                    dr.SetField("NombreModulo",nombreModulo);
                    dr.SetField("NombreTarea", "Tarea " + i.ToString() + j.ToString());
                    dr.SetField("EstadoTarea", "Pendiente");
                    dtTareas.Rows.Add(dr);
                }
            }

            return dtTareas;
        }

        /// <summary>
        /// Se procesan las tareas, separandolas por modulos 
        /// y se devuelve una lista de objetos que cada uno tiene Titulo del modulo y un Datatable con las tareas.
        /// </summary>
        /// <returns></returns>
        List<Entidad.Modulo> obtenerListaModulos()
        {
            List<Entidad.Modulo> listaDeModulos;
            Entidad.Modulo unModulo;
            listaDeModulos = new List<Entidad.Modulo>();
            
            //Aca se debería recorrer un datatable, que tiene todas las tareas e ir generando nuevas tablas con un dataview para separarlos por modulos.
            unModulo = new Entidad.Modulo();
            unModulo.nombreModulo = "Titulo de un modulo";
            unModulo.tablaTareas = obtenerTareas();
            listaDeModulos.Add(unModulo);

            unModulo = new Entidad.Modulo();
            unModulo.nombreModulo = "Titulo de otro modulo";
            unModulo.tablaTareas = obtenerTareas();
            listaDeModulos.Add(unModulo);


            return listaDeModulos;
        }
        void presentarContenidoProyecto() {
            //Prodeo.Entidad.Modulo unModulo = new Prodeo.Entidad.Modulo();
            List<Entidad.Modulo> listaDeModulos;
            listaDeModulos = new List<Entidad.Modulo>();
            listaDeModulos = obtenerListaModulos();
            
            foreach (Entidad.Modulo unModulo in listaDeModulos)
            {
                Literal h3 = new Literal();
                Literal divApertura = new Literal();
                Literal divCierre = new Literal();

                //creamos y agregamos el h3 que sera el titulo de la solapa accordion
                h3.Text = "<h3>" + unModulo.nombreModulo + "</h3>";
                contenedorAccordion.Controls.Add(h3);

                //Creamos la grilla que va a tener las tareas
                GridView grillaTareas = new GridView();
                grillaTareas.DataSource = unModulo.tablaTareas;
                grillaTareas.DataBind();

                //Creamos un div que va a ser el que tenga el contenido de lo que se va a mostrar al desplegar el accordion.
                //Dentro de este dev agregamos la grilla de tareas
                divApertura.Text = "<div>";
                divCierre.Text = "</div>";
                contenedorAccordion.Controls.Add(divApertura);
                contenedorAccordion.Controls.Add(grillaTareas);
                contenedorAccordion.Controls.Add(divCierre);

                //De aca para abajo eran pruebas, no va.

                ////AjaxControlToolkit.Accordion ac1;
                //AjaxControlToolkit.AccordionPane pane1;
                //pane1 = new AjaxControlToolkit.AccordionPane();
                //pane1.ID = "pan" + i;
                ////pane1.Header = Accordion1.HeaderTemplate;
                //Label c1 = new Label();
                //GridView c2 = new GridView();
                //c1.Text = unModulo.nombreModulo;
                //c2.DataSource = unModulo.tablaTareas;
                //c2.DataBind();
                //pane1.ContentContainer.Controls.Add(c1);
                //pane1.HeaderContainer.Controls.Add(c2);
                //pane1.HeaderContainer.ID = "hea" + i;
                //pane1.ContentContainer.ID = "cont" + i;
                //Accordion1.Panes.Add(pane1);
                //i = i + 1;
            }
        }
    }
}

