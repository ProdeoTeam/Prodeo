using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Datos;
namespace Prodeo.pantallas
{
    public partial class VerProyecto : System.Web.UI.Page
    {
        public int idProyecto;
        public string permiso = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ProyectoLogica datosProyecto = new ProyectoLogica();
            idProyecto = Convert.ToInt32(Request.QueryString["idProyecto"]);
            permiso = Request.QueryString["p"];
            nombreProyecto.Text = datosProyecto.obtieneNombreProyecto(idProyecto);
            Session["idProyecto"] = idProyecto;
            Session["permiso"] = permiso;
            presentarContenidoProyecto(idProyecto, permiso);
            

        }
        /// <summary>
        /// Se devuelve un datatable con todos las tareas del proyecto.
        /// </summary>
        /// <returns></returns>
        System.Data.DataTable obtenerTareas(int idModulo)
        {
            ProyectoLogica proy = new ProyectoLogica();
            DataTable dtTareas = new DataTable();
            DataColumn unaColumna;
            //una de las columnas tiene que ser el modulo para agruparlas cuando las queremos presentar en accordion
            unaColumna = new DataColumn("Nombre Tarea");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("Descripcion");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("Prioridad");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("Asignada a");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("Fecha Limite");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("Estado");
            dtTareas.Columns.Add(unaColumna);
            List<DatosTarea> listaTareas = new List<DatosTarea>();
            if (Session["permiso"].ToString() == "A")
            {
                listaTareas = proy.obtieneListaTareas(idModulo);
            }
            else
            {
                listaTareas = proy.obtieneListaTareasUsusario(idModulo,Session["usuario"].ToString());
            }
            if(listaTareas.Count != 0)
            { 
                foreach(DatosTarea tarea in listaTareas)
                {
                        string prioridad = "";
                        DataRow dr = dtTareas.NewRow();
                        dr.SetField("Nombre Tarea",tarea.Nombre);
                        dr.SetField("Descripcion", tarea.Descripcion);
                         switch(tarea.Prioridad)
                         {
                             case "A":
                                 {
                                     prioridad = "Alta";
                                     break;
                                 }
                             case "M":
                                 {
                                     prioridad = "Media";
                                     break;
                                 }
                             case "B":
                                 {
                                     prioridad = "Baja";
                                     break;
                                 }
                             case "N":
                                 {
                                     prioridad = "Ninguna";
                                     break;
                                 }
                         }
                         dr.SetField("Prioridad", prioridad);
                         dr.SetField("Asignada a", tarea.Asignada);
                         dr.SetField("Fecha Limite", tarea.FechaLimite);
                         dr.SetField("Estado", tarea.Estado);
                        dtTareas.Rows.Add(dr);
                }
            }
            else
            {
                DataRow dr = dtTareas.NewRow();
                dr.SetField("Nombre Tarea", "No posee Tareas");
                dtTareas.Rows.Add(dr);
            }

            return dtTareas;
        }

        /// <summary>
        /// Se procesan las tareas, separandolas por modulos 
        /// y se devuelve una lista de objetos que cada uno tiene Titulo del modulo y un Datatable con las tareas.
        /// </summary>
        /// <returns></returns>
        List<DatosModulo> obtenerListaModulos(int idproyecto, string permiso)
        {
            List<DatosModulo> listaDeModulos;
            //Entidad.Modulo unModulo;
            listaDeModulos = new List<DatosModulo>();
            ProyectoLogica proy = new ProyectoLogica();
                listaDeModulos = proy.obtieneListaModulos(Session["usuario"].ToString(), idproyecto, permiso);
                //Aca se debería recorrer un datatable, que tiene todas las tareas e ir generando nuevas tablas con un dataview para separarlos por modulos.
                foreach (DatosModulo modulo in listaDeModulos)
                {
                    modulo.tablaTareas = obtenerTareas(modulo.IdModulo);
                }

            return listaDeModulos;
        }
        void presentarContenidoProyecto(int idproyecto, string permiso) {
            //Prodeo.Entidad.Modulo unModulo = new Prodeo.Entidad.Modulo();
            List<DatosModulo> listaDeModulos;
            listaDeModulos = new List<DatosModulo>();
            listaDeModulos = obtenerListaModulos(idproyecto, permiso);
            
            foreach (DatosModulo unModulo in listaDeModulos)
            {
                Literal h3 = new Literal();
                Literal divApertura = new Literal();
                Literal divCierre = new Literal();

                //creamos y agregamos el h3 que sera el titulo de la solapa accordion
                h3.Text = "<h3>" + unModulo.Nombre + "</h3>";
                contenedorAccordion.Controls.Add(h3);

                //Creamos la grilla que va a tener las tareas
                GridView grillaTareas = new GridView();
                grillaTareas.Attributes.Add("class", "default");
                grillaTareas.DataSource = unModulo.tablaTareas;
                grillaTareas.DataBind();

                //Creamos un div que va a ser el que tenga el contenido de lo que se va a mostrar al desplegar el accordion.
                //Dentro de este dev agregamos la grilla de tareas
                divApertura.Text = "<div>";
                divCierre.Text = "</div>";
                contenedorAccordion.Controls.Add(divApertura);
                contenedorAccordion.Controls.Add(grillaTareas);
                contenedorAccordion.Controls.Add(divCierre);

            }
        }
    }
}

