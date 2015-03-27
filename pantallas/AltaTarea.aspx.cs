﻿using System;
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
                ProyectoLogica proy = new ProyectoLogica();
                int proyecto = Convert.ToInt32(Session["idProyecto"]);
                string usuario = Session["usuario"].ToString();
                string permiso = proy.obtienePermisoUsuario(usuario, proyecto);
                AccesoLogica user = new AccesoLogica();
                listaModulos.DataSource = proy.obtieneListaModulos(usuario, proyecto, permiso);
                listaModulos.DataValueField = "IdModulo";
                listaModulos.DataTextField = "Nombre";
                listaModulos.DataBind();
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
                    }
                    else
                    {
                        btnEditarTarea.Visible = false;
                        btnEditarComentario.Visible = true;
                        btnCancelarEdicion.Visible = false;
                    }
                    LabelTareas.Text = "Ver Tarea";
                    GridViewRow row;
                    row = (GridViewRow) Session["datosTarea"];
                    Session["idTarea"] = row.Cells[1].Text;
                    nombreTarea.Value = row.Cells[3].Text;
                    nombreTarea.Disabled = true;
                    descripcion.Value = row.Cells[4].Text;
                    descripcion.Disabled = true;
                    comentario.Value = row.Cells[5].Text;
                    comentario.Disabled = true;
                    for (int i=0; i<=listaModulos.Items.Count - 1; i++)
                        {
                            if (listaModulos.Items[i].Value == row.Cells[2].Text)
                            {
                                listaModulos.Items[i].Selected = true;
                            }
                        }
                    listaModulos.Disabled = true;
                    for (int i = 0; i <= listaPrioridad.Items.Count - 1; i++)
                    {
                        if (listaPrioridad.Items[i].Text == row.Cells[6].Text)
                        {
                            listaPrioridad.Items[i].Selected = true;
                        }
                    }
                    listaPrioridad.Disabled = true;
                    for (int i = 0; i <= avisoVencimientos.Items.Count - 1; i++)
                    {
                        if (avisoVencimientos.Items[i].Value == row.Cells[7].Text)
                        {
                            avisoVencimientos.Items[i].Selected = true;
                        }
                    }
                    avisoVencimientos.Disabled = true;
                    for (int i = 0; i <= usuariosLista.Items.Count - 1; i++)
                    {
                        if (usuariosLista.Items[i].Text == row.Cells[8].Text)
                        {
                            usuariosLista.Items[i].Selected = true;
                        }
                    }
                    usuariosLista.Disabled = true;
                    fechaVencimiento.Value = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(row.Cells[9].Text));
                    fechaVencimiento.Disabled = true;
                    if (row.Cells[10].Text != "&nbsp;")
                    {
                        fechaFinalizacion.Value = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(row.Cells[10].Text));
                    }
                    fechaFinalizacion.Disabled = true;
                    Session["datosTarea"] = null;
                }
            }
        }

        protected void altaTareaForm_Click(object sender, EventArgs e)
        {
            bool altaExitosa = false;
            int proyecto = Convert.ToInt32(Session["idProyecto"]);
            string usuario = Session["usuario"].ToString();
            //Session["permiso"] = "A";
            ProyectoLogica agregaTarea = new ProyectoLogica();
            GridViewRow row =  (GridViewRow)Session["datosTarea"];
            if (Session["idTarea"] != null)
            {
                altaExitosa = agregaTarea.ActualizaTarea(Session["idTarea"].ToString(), listaModulos.Value, nombreTarea.Value, descripcion.Value, comentario.Value, DateTime.Now, Convert.ToDateTime(fechaVencimiento.Value), Convert.ToDateTime(fechaFinalizacion.Value), proyecto, usuario, avisoVencimientos.Value, listaPrioridad.Value, usuariosLista.Value);
                Session["idTarea"] = null;
            }
            else
            {
                altaExitosa = agregaTarea.insertaTarea(listaModulos.Value, nombreTarea.Value, descripcion.Value, comentario.Value, DateTime.Now, Convert.ToDateTime(fechaVencimiento.Value), Convert.ToDateTime(fechaFinalizacion.Value), proyecto, usuario, avisoVencimientos.Value, listaPrioridad.Value, usuariosLista.Value);
            }
            
            if (altaExitosa)
            {
                if(Session["permiso"]!=null)
                {
                    Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto + "&p=" + Session["permiso"]);
                }
                else
                {
                    Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto + "&p=A");
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
            listaModulos.Disabled = false;
            listaPrioridad.Disabled = false;
            fechaVencimiento.Disabled = false;
            fechaFinalizacion.Disabled = false;
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
            listaModulos.Disabled = true;
            listaPrioridad.Disabled = true;
            fechaVencimiento.Disabled = true;
            fechaFinalizacion.Disabled = false;
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
            listaModulos.Disabled = true;
            listaPrioridad.Disabled = true;
            fechaVencimiento.Disabled = true;
            fechaFinalizacion.Disabled = true;
            avisoVencimientos.Disabled = true;
            usuariosLista.Disabled = true;

            btnAltaTarea.Visible = false;

        }
    }
}