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
            if(permiso == "C")
            {
                liTarea.Style["display"] = "none";
                liModulo.Style["display"] = "none";
            }
            else
            {
                liTarea.Style["display"] = "inline-block";
                liModulo.Style["display"] = "inline-block";
            }
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
            unaColumna = new DataColumn("Id Tarea");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("Id Modulo");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("Nombre Tarea");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("Descripcion");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("Comentario");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("Prioridad");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("Avisos");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("Asignada a");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("Fecha Limite");
            dtTareas.Columns.Add(unaColumna);
            unaColumna = new DataColumn("Fecha Inicio");
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
                Button newButton = new Button();
                newButton.Text = "Ver";
                foreach(DatosTarea tarea in listaTareas)
                {
                        string prioridad = "";
                        newButton.ID = "btnTarea"+tarea.IdTarea;
                        DataRow dr = dtTareas.NewRow();
                        dr.SetField("Id Tarea", tarea.IdTarea);
                        dr.SetField("Id Modulo", tarea.IdModulo);
                        dr.SetField("Nombre Tarea",tarea.Nombre);
                        dr.SetField("Descripcion", tarea.Descripcion);
                        dr.SetField("Comentario", tarea.Comentario);
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
                         dr.SetField("Avisos", tarea.Avisos);
                         dr.SetField("Asignada a", tarea.Asignada);
                         dr.SetField("Fecha Limite", tarea.FechaLimite);
                         dr.SetField("Fecha Inicio", tarea.FechaInicio);
                         //dr.SetField("Fecha Vencimiento", tarea.FechaFinalizacion);
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
            int anchoBarraProgreso = 150;
            foreach (DatosModulo unModulo in listaDeModulos)
            {
                GridView grillaTareas = new GridView();
                grillaTareas.CssClass = "footable";
                Literal h3 = new Literal();
                Literal divApertura = new Literal();
                Literal divCierre = new Literal();
                Literal linkModulo = new Literal();
                Literal linkTarea = new Literal();
                Literal linkCalendarioTareas = new Literal();
                Literal linkEliminarModulo = new Literal();
                int totalTareas;
                int tareasFinalizadas = 0;
                Double porcentajeAvance = 0;
                
                totalTareas = unModulo.tablaTareas.Rows.Count;
                foreach (DataRow item in unModulo.tablaTareas.Rows)
                {
                    if("Finalizada" == Convert.ToString(item["Estado"])){
                        tareasFinalizadas = tareasFinalizadas + 1;
                    }
                }

                porcentajeAvance = ((tareasFinalizadas * 100) / totalTareas);

                //creamos y agregamos el h3 que sera el titulo de la solapa accordion
                h3.Text = "<h3>" + unModulo.Nombre;

                h3.Text += "<div id='barraProgreso' style='width:";
                h3.Text += anchoBarraProgreso.ToString() + "px; height:20px;position:absolute;margin-left:75%;margin-top:-25px; border-style:solid; border-color:black; border-width:2px;'>";
                h3.Text += "<div style='background-color:#12587B;width:";
                h3.Text += Math.Round(porcentajeAvance);
                h3.Text += "%;";
                
                h3.Text += "height:16px;'>";
                h3.Text += "</div>";
                h3.Text += "</h3>";
                contenedorAccordion.Controls.Add(h3);

                //Creamos la grilla que va a tener las tareas
                //GridView grillaTareas = new GridView();
                foreach (DataColumn column in unModulo.tablaTareas.Columns)
                {
                    BoundField field = new BoundField();
                    field.DataField = column.ColumnName;
                    field.HeaderText = column.ColumnName;
                    grillaTareas.Columns.Add(field);
                }
                grillaTareas.ID = "GridView"+unModulo.IdModulo;
                grillaTareas.AutoGenerateColumns = false;
                grillaTareas.SelectedIndexChanged += new EventHandler(GridView_SelectedIndexChanged);
                grillaTareas.AutoGenerateSelectButton = true;
                if (Session["permiso"].ToString() == "A")
                {
                    grillaTareas.RowDeleting += new GridViewDeleteEventHandler(GridView_RowDeleting);
                    grillaTareas.AutoGenerateDeleteButton = true;
                }
                grillaTareas.RowDataBound += new GridViewRowEventHandler(GridView_RowDataBound);
                grillaTareas.Attributes.Add("class", "default");

                //Filtramos las tareas finalizadas para que no se presenten en pantalla.
                DataView dvTareas = new DataView(unModulo.tablaTareas);
                dvTareas.RowFilter = "Estado <> 'Finalizada'";
                grillaTareas.DataSource = dvTareas.ToTable();
                //grillaTareas.DataSource = unModulo.tablaTareas;
                grillaTareas.DataBind();
                grillaTareas.Columns[0].Visible = false;
                grillaTareas.Columns[1].Visible = false;
                grillaTareas.Columns[4].Visible = false;
                grillaTareas.Columns[6].Visible = false;
                grillaTareas.Columns[9].Visible = false;

                //------------------------------------------------------------------
                //ESTABLECE LAS COLUMNAS QUE SE VAN A MOSTRAR U OCULTAR A MEDIDA QUE VA CERRANDO EL NAVEGADOR
                //DOCUMENTACION PLUGIN: http://fooplugins.com/plugins/footable-jquery/

                //Attribute to show the Plus Minus Button.
                grillaTareas.HeaderRow.Cells[0].Attributes["data-class"] = "expand";//posicion 0 comandos seleccionar y eliminar
                

                //Attribute to hide column in Phone.
                grillaTareas.HeaderRow.Cells[4].Attributes["data-hide"] = "phone"; //Descripcion 
                grillaTareas.HeaderRow.Cells[6].Attributes["data-hide"] = "phone"; //Prioridad
                grillaTareas.HeaderRow.Cells[8].Attributes["data-hide"] = "phone"; //Asignada
                grillaTareas.HeaderRow.Cells[9].Attributes["data-hide"] = "phone"; //Fecha limite
                grillaTareas.HeaderRow.Cells[11].Attributes["data-hide"] = "phone"; //Estado

                
                
                //Adds THEAD and TBODY to GridView.
                grillaTareas.HeaderRow.TableSection = TableRowSection.TableHeader;

                //------------------------------------------------------------------

                //Creamos un div que va a ser el que tenga el contenido de lo que se va a mostrar al desplegar el accordion.
                //Dentro de este dev agregamos la grilla de tareas
                divApertura.Text = "<div>";
                divCierre.Text = "</div>";
                linkModulo.Text = "<a class='button' href='AltaModulo.aspx?idModulo=" + unModulo.IdModulo + "'>VER MÓDULO</a>&nbsp&nbsp";
                linkTarea.Text = "<a class='button' href='AltaTarea.aspx?idModulo=" + unModulo.IdModulo + "'>ALTA TAREA</a>&nbsp&nbsp";
                linkCalendarioTareas.Text = "<a class='button' href='VerTareasCalendario.aspx?idModulo=" + unModulo.IdModulo + "&idProyecto=" + idproyecto + "'>ADMINISTRAR PLAN</a>&nbsp&nbsp";
                linkEliminarModulo.Text = "<a href='EliminarModulo.aspx?idModulo=" + unModulo.IdModulo + "'>Eliminar</a>"; ;
                contenedorAccordion.Controls.Add(divApertura);
                contenedorAccordion.Controls.Add(grillaTareas);
                contenedorAccordion.Controls.Add(linkModulo);
                contenedorAccordion.Controls.Add(linkTarea);
                contenedorAccordion.Controls.Add(linkCalendarioTareas);
                if (Session["permiso"].ToString() == "A" && grillaTareas.Rows.Count == 0)
                {
                    contenedorAccordion.Controls.Add(linkEliminarModulo);
                }
                
                contenedorAccordion.Controls.Add(divCierre);

            }
        }

        protected void GridView_SelectedIndexChanged(Object sender, EventArgs e)
        {
            GridView dv = sender as GridView;
            GridViewRow row = dv.SelectedRow;
            Session["datosTarea"] = row;
            
            Response.Redirect("~/pantallas/AltaTarea.aspx");

        }

        protected void GridView_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            ProyectoLogica proy = new ProyectoLogica();
            GridView dv = sender as GridView;
            GridViewRow row = dv.Rows[e.RowIndex];
            Response.Redirect("~/pantallas/EliminarTarea.aspx?idTarea=" + row.Cells[1].Text + "");
            //bool correcto = proy.EliminaTarea(row.Cells[1].Text, Session["usuario"].ToString());
            //if(correcto)
            //{
            //    Response.Redirect(Request.Url.AbsoluteUri);
            //}
            

        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // To check condition on integer value
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Estado")) == "Vencido")
            {
                e.Row.BackColor = System.Drawing.Color.OrangeRed;
            }
        }

        protected void btnVerProyecto_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pantallas/AltaProyecto.aspx");
        }
    }
}

