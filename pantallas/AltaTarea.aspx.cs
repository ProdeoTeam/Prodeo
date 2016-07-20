using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Prodeo.pantallas
{
    public partial class AltaTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idModulo = 0;
                ProyectoLogica proy = new ProyectoLogica();
                int proyecto = Convert.ToInt32(Session["idProyecto"]);
                string usuario = Session["usuario"].ToString();
                string permiso = proy.obtienePermisoUsuario(usuario, proyecto);
                idModulo = Convert.ToInt32(Request.QueryString["idModulo"]);
                AccesoLogica user = new AccesoLogica();
                listaModulos.DataSource = proy.obtieneListaModulos(usuario, proyecto, permiso);
                listaModulos.DataValueField = "IdModulo";                
                listaModulos.DataTextField = "Nombre";
                listaModulos.DataBind();
                if (idModulo != 0)
                {
                    listaModulos.SelectedValue = idModulo.ToString();
                }
                usuariosLista.DataSource = user.obtieneListaUsuarios(proyecto);
                usuariosLista.DataValueField = "idUsuario";
                usuariosLista.DataTextField = "nombre";
                usuariosLista.DataBind();
                if (Session["datosTarea"] == null)
                {
                    Session["permiso"] = "A";
                    LabelTareas.Text = "Alta de Tarea";
                    btnAltaTarea.Visible = true;
                    btnCalcelarTarea.Visible = true;
                    btnVolverTarea.Visible = false;
                    btnEditarTarea.Visible = false;
                    btnCancelarEdicion.Visible = false;
                    btnEditarComentario.Visible = false;
                    txtHoras.Visible = false;
                    btnFinalizarTarea.Visible = false;
                    
                }
                else
                {
                    btnAltaTarea.Visible = false;
                    btnEditarTarea.Visible = false;
                    btnCalcelarTarea.Visible = false;
                    btnEditarComentario.Visible = false;
                    btnVolverTarea.Visible = true;
                    Session["permiso"] = permiso;
                    if(permiso == "A")
                    {
                        btnEditarTarea.Visible = true;
                        btnCancelarEdicion.Visible = false;
                        btnEditarComentario.Visible = false;
                        txtHoras.Visible = true;
                        btnFinalizarTarea.Visible = true;
                    }
                    else
                    {
                        btnEditarTarea.Visible = false;
                        btnEditarComentario.Visible = true;
                        btnCancelarEdicion.Visible = false;
                        txtHoras.Visible = true;
                        btnFinalizarTarea.Visible = true;
                    }
                    LabelTareas.Text = "Ver Tarea";
                    GridViewRow row;
                    row = (GridViewRow) Session["datosTarea"];
                    Session["idTarea"] = row.Cells[0].Text;
                    nombreTarea.Value = row.Cells[2].Text;
                    nombreTarea.Disabled = true;
                    descripcion.Value = row.Cells[3].Text;
                    descripcion.Disabled = true;
                    comentario.Value = row.Cells[4].Text;
                    comentario.Disabled = true;
                    for (int i=0; i<=listaModulos.Items.Count - 1; i++)
                        {
                            if (listaModulos.Items[i].Value == row.Cells[1].Text)
                            {
                                listaModulos.Items[i].Selected = true;
                            }
                            else
                            {
                                listaModulos.Items[i].Selected = false;
                            }
                        }
                    listaModulos.Enabled = false;
                    for (int i = 0; i <= listaPrioridad.Items.Count - 1; i++)
                    {
                        if (listaPrioridad.Items[i].Text == row.Cells[5].Text)
                        {
                            listaPrioridad.Items[i].Selected = true;
                        }
                        else
                        {
                            listaPrioridad.Items[i].Selected = false;
                        }

                    }
                    listaPrioridad.Disabled = true;
                    for (int i = 0; i <= avisoVencimientos.Items.Count - 1; i++)
                    {
                        if (avisoVencimientos.Items[i].Value == row.Cells[6].Text)
                        {
                            avisoVencimientos.Items[i].Selected = true;
                        }
                        else
                        {
                            avisoVencimientos.Items[i].Selected = false;
                        }
                    }
                    avisoVencimientos.Disabled = true;
                    for (int i = 0; i <= usuariosLista.Items.Count - 1; i++)
                    {
                        if (usuariosLista.Items[i].Text == row.Cells[7].Text)
                        {
                            usuariosLista.Items[i].Selected = true;
                        }
                        else
                        {
                            usuariosLista.Items[i].Selected = false;
                        }
                    }
                    usuariosLista.Disabled = true;
                    fechaVencimiento.Value = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(row.Cells[8].Text));
                    fechaVencimiento.Disabled = true;
                    fechaInicio.Value = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(row.Cells[9].Text));
                    fechaInicio.Disabled = true;
                    //if (row.Cells[10].Text != "&nbsp;")
                    //{
                    //    fechaFinalizacion.Value = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(row.Cells[10].Text));
                    //}
                    //fechaFinalizacion.Disabled = true;
                    Session["datosTarea"] = null;
                }
            }
        }

        protected void altaTareaForm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                bool altaExitosa = false;
                int proyecto = Convert.ToInt32(Session["idProyecto"]);
                string usuario = Session["usuario"].ToString();
                //Session["permiso"] = "A";
                ProyectoLogica agregaTarea = new ProyectoLogica();
                GridViewRow row = (GridViewRow)Session["datosTarea"];
                if (Session["idTarea"] != null)
                {
                    altaExitosa = agregaTarea.ActualizaTarea(Session["idTarea"].ToString(), listaModulos.SelectedValue, nombreTarea.Value, descripcion.Value, comentario.Value, DateTime.Now, Convert.ToDateTime(fechaVencimiento.Value), Convert.ToDateTime(fechaInicio.Value), proyecto, usuario, avisoVencimientos.Value, listaPrioridad.Value, usuariosLista.Value);
                    Session["idTarea"] = null;
                }
                else
                {
                    altaExitosa = agregaTarea.insertaTarea(listaModulos.SelectedValue, nombreTarea.Value, descripcion.Value, comentario.Value, DateTime.Now, Convert.ToDateTime(fechaVencimiento.Value), Convert.ToDateTime(fechaInicio.Value), proyecto, usuario, avisoVencimientos.Value, listaPrioridad.Value, usuariosLista.Value);
                }

                if (altaExitosa)
                {
                    if (Session["permiso"] != null)
                    {
                        Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto + "&p=" + Session["permiso"]);
                    }
                    else
                    {
                        Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto + "&p=A");
                    }

                }
            }
        }

        protected void cancelarTareaForm_Click(object sender, EventArgs e)
        {
            int proyecto = Convert.ToInt32(Session["idProyecto"]);
            Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto + "&p=" + Session["permiso"]);
        }

        protected void editarTarea_Click(object sender, EventArgs e)
        {
            btnEditarTarea.Visible = false;
            btnCancelarEdicion.Visible = true;
            nombreTarea.Disabled = false;
            descripcion.Disabled = false;
            comentario.Disabled = false;
            listaModulos.Enabled = true;
            listaPrioridad.Disabled = false;
            fechaVencimiento.Disabled = false;
            fechaInicio.Disabled = true;
            //fechaFinalizacion.Disabled = false;
            avisoVencimientos.Disabled = false;
            usuariosLista.Disabled = false;

            btnAltaTarea.Visible = true;
            btnAltaTarea.InnerText = "Guardar";

        }

        protected void editarComentario_Click(object sender, EventArgs e)
        {
            btnEditarTarea.Visible = false;
            btnEditarComentario.Visible = false;
            btnCancelarEdicion.Visible = true;
            nombreTarea.Disabled = true;
            descripcion.Disabled = true;
            comentario.Disabled = false;
            listaModulos.Enabled = false;
            listaPrioridad.Disabled = true;
            fechaVencimiento.Disabled = true;
            fechaInicio.Disabled = true;
            //fechaFinalizacion.Disabled = false;
            avisoVencimientos.Disabled = true;
            usuariosLista.Disabled = true;

            btnAltaTarea.Visible = true;
            btnAltaTarea.InnerText = "Guardar";

        }

        protected void cancelarTarea_Click(object sender, EventArgs e)
        {
            btnEditarTarea.Visible = true;
            btnCancelarEdicion.Visible = false;
            nombreTarea.Disabled = true;
            descripcion.Disabled = true;
            comentario.Disabled = true;
            listaModulos.Enabled = false;
            listaPrioridad.Disabled = true;
            fechaVencimiento.Disabled = true;
            fechaInicio.Disabled = true;
            //fechaFinalizacion.Disabled = true;
            avisoVencimientos.Disabled = true;
            usuariosLista.Disabled = true;

            btnAltaTarea.Visible = false;

        }

        protected void finalizarTareaForm_Click(object sender, EventArgs e)
        {
            int proyecto = Convert.ToInt32(Session["idProyecto"]);
            string usuario = Session["usuario"].ToString();
            ProyectoLogica finalizaTarea = new ProyectoLogica();
            bool finalizacion = finalizaTarea.finalizaTarea(Session["idTarea"].ToString(), usuario, comentario.Value, txtHoras.Value);

            if (finalizacion)
            {
                if (Session["permiso"] != null)
                {
                    Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto + "&p=" + Session["permiso"]);
                }
                else
                {
                    Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto + "&p=A");
                }

            }
        }

        protected void validarFechaVenc(object source, ServerValidateEventArgs args)
        {

            AccesoLogica logica = new AccesoLogica();
            DateTime fechaVenc = Convert.ToDateTime(fechaVencimiento.Value);
            int idModulo = Convert.ToInt32(listaModulos.SelectedValue);
            bool fechaValida = logica.esFechaTareaValida(fechaVenc, idModulo);
            if (fechaValida)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
                DateTime FechVencModulo = logica.obtieneVencModulo(idModulo);
                CustomValVencValid.ErrorMessage = "La fecha de vencimiento no puede ser mayor a la del modulo: " + FechVencModulo.ToShortDateString();
            }
        }

        protected void validarFechaIni(object source, ServerValidateEventArgs args)
        {

            AccesoLogica logica = new AccesoLogica();
            DateTime fechaIni = Convert.ToDateTime(fechaInicio.Value);
            int idModulo = Convert.ToInt32(listaModulos.SelectedValue);
            bool fechaValida = logica.esFechaInicioTareaValida(fechaIni, idModulo);
            if (fechaValida)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
                DateTime FechIniModulo = logica.obtieneIniModulo(idModulo);
                CustomValIniValid.ErrorMessage = "La fecha de Inicio no puede ser menor a la del modulo: " + FechIniModulo.ToShortDateString();
            }
        }

        //protected void validarFechaActual(object source, ServerValidateEventArgs args)
        //{
        //    AccesoLogica logica = new AccesoLogica();
        //    DateTime fechaVenc = Convert.ToDateTime(fechaVencimiento.Value);            
        //    bool fechaValida = logica.esFechaMayorActual(fechaVenc);
        //    string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
        //    if (fechaValida)
        //    {
        //        args.IsValid = true;
        //    }
        //    else
        //    {
        //        args.IsValid = false;
        //        //CustomValFechActual.ErrorMessage = "La fecha ingresada debe ser mayor o igual a la actual: " + fechaActual;
        //    }
        //}
    }
}