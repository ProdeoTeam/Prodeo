using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Negocio;
using Datos;

namespace Prodeo.pantallas
{
    public partial class ListaProyectos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
             {
                 cargaListaProy(sender, e);  
             }                                 
        }
        
        protected void ddlFiltroProyChanged(object sender, EventArgs e)
        {
            cargaListaProy(sender, e);
        }

        protected void cargaListaProy(object sender, EventArgs e)
        {
            ProyectoLogica proy = new ProyectoLogica();

            int abiertoFinalizado = Convert.ToInt32(ddlFiltroProy.SelectedValue);

            List<DatosProyecto> dataProy = proy.obtieneListaProyecto(Session["usuario"].ToString(), abiertoFinalizado);
            
                Control control = FindHtmlControlByIdInControl(this, "proyectosLista");

                if (control != null)
                {
                    if (dataProy.Count > 0)
                    {
                        string permiso = "";
                       foreach (DatosProyecto dato in dataProy)
                        {
                            Literal literal;

                            literal = new Literal();
                            literal.Text = "<section id='vistaProyecto'>";
                            control.Controls.Add(literal);
                            switch(dato.Permisos)
                            {
                                case "A":
                                    {
                                        permiso = "Administrador";
                                        break;
                                    }
                                case "C":
                                    {
                                        permiso = "Colaborador";
                                        break;
                                    }
                            }
                            literal = new Literal();
                            literal.Text = "<h2>" + dato.Nombre + " : " + permiso + "</h2>";
                            control.Controls.Add(literal);

                            literal = new Literal();
                            literal.Text = "<h3>" + dato.Descripcion + "</h3>";
                            control.Controls.Add(literal);

                            literal = new Literal();                            
                            literal.Text = "<a href='VerProyecto.aspx?idProyecto=" + dato.Id + "&p=" + dato.Permisos + "' class='button'>Ingresar</a><a href='DesvincularProyecto.aspx?idProyecto=" + dato.Id + "&p=" + dato.Permisos + "' class='button'>Desvincular Proyecto</a>";
                            control.Controls.Add(literal);

                            if (permiso == "Administrador" && abiertoFinalizado == 0)
                            {
                                literal = new Literal();                            
                                literal.Text = "<a href='FinalizarProyecto.aspx?idProyecto=" + dato.Id + "&p=" + dato.Permisos + "' class='button'>Finalizar</a>";
                            }
                            else if (permiso == "Administrador" && abiertoFinalizado == 1)
                            {
                                literal = new Literal();
                                literal.Text = "<a href='ReabrirProyecto.aspx?idProyecto=" + dato.Id + "&p=" + dato.Permisos + "' class='button'>Reabrir</a>";
                            }
                            
                            control.Controls.Add(literal);

                            literal = new Literal();
                            literal.Text = "</section><br />";
                            control.Controls.Add(literal);
                        }
                    }
                    else
                    {
                        Literal literal;

                        literal = new Literal();
                        literal.Text = "<section id='vistaProyecto'>";
                        control.Controls.Add(literal);

                        literal = new Literal();
                        literal.Text = "<h2>No posee proyectos!</h2>";
                        control.Controls.Add(literal);

                        literal = new Literal();
                        literal.Text = "<h3>Vaya a la seccion alta de proyectos para comenzar.</h3>";                        
                        control.Controls.Add(literal);

                        literal = new Literal();
                        literal.Text = "<a href='AltaProyecto.aspx' class='button'>Alta de Proyectos</a>";
                        control.Controls.Add(literal);

                        literal = new Literal();
                        literal.Text = "</section><br />";
                        control.Controls.Add(literal);
                    }
            }
            

        }

        private Control FindHtmlControlByIdInControl(Control control, string id)
        {
            foreach (Control childControl in control.Controls)
            {
                if (childControl.ID != null && childControl.ID.Equals(id, StringComparison.OrdinalIgnoreCase) && childControl is Control)
                {
                    return (Control)childControl;
                }

                if (childControl.HasControls())
                {
                    Control result = FindHtmlControlByIdInControl(childControl, id);
                    if (result != null) return result;
                }
            }

            return null;
        }
    }
}