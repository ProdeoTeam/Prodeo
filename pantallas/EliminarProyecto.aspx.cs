﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Datos;

namespace Prodeo.pantallas
{
    public partial class EliminarProyecto : System.Web.UI.Page
    {
        public int proyecto;
        public Proyectos datosPro;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("~/index.aspx");
            }
            else
            {
                ProyectoLogica proy = new ProyectoLogica();
                proyecto = Convert.ToInt32(Session["idProyecto"]);
                string usuario = Session["usuario"].ToString();
                string permiso = proy.obtienePermisoUsuario(usuario, proyecto);
                AccesoLogica user = new AccesoLogica();
                datosPro = proy.obtieneDatosProyecto(Session["idProyecto"].ToString());
                LabelElimTareas.Text = "Se va a eliminar el proyecto " + datosPro.Nombre + ", ¿desea continuar?";
            }
            
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            int proyecto = Convert.ToInt32(Session["idProyecto"]);
            Response.Redirect("~/pantallas/VerProyecto.aspx?idProyecto=" + proyecto + "&p=" + Session["permiso"]);
        }

        protected void eliminarProyecto_Click(object sender, EventArgs e)
        {
            ProyectoLogica proy = new ProyectoLogica();
            bool respuesta = proy.EliminaProyecto(proyecto);
            if (respuesta)
            {
                Response.Redirect("~/pantallas/ListaProyectos.aspx");
            }
            else
            {
                LabelElimTareas.Text = "No se pudo realizar la baja del proyecto " + datosPro.Nombre + ", el mismo posee modulos asociados!";
            }

        }   
    }
}