using System;
using System.Collections.Generic;
using System.Linq;
using Negocio;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Datos;
using System.Web.UI.HtmlControls;

namespace Prodeo.pantallas
{
    public partial class AltaProyecto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AjaxPro.Utility.RegisterTypeForAjax(typeof(AltaProyecto));
                AjaxPro.Utility.RegisterTypeForAjax(typeof(GridView));
                DataTable dt = new DataTable();

                dt.Columns.Add("mail", typeof(string));
                dt.Columns.Add("permisos", typeof(string));

                //GridView1.DataSource = dt;
                //GridView1.DataBind();
                Session["tabla"] = dt;
                ProyectoLogica proy = new ProyectoLogica();
                int Numproyecto = Convert.ToInt32(Session["idProyecto"]);
                string usuario = Session["usuario"].ToString();
                string permiso = "";
                if(Numproyecto != 0)
                {
                    permiso = proy.obtienePermisoUsuario(usuario, Numproyecto);
                }
                if(Session["idProyecto"] == null)
                {
                    LabelProyectos.Text = "Alta de Proyecto";
                    Session["permiso"] = "A";
                    btnEditarProyecto.Visible = false;
                    btnCancelarEdicion.Visible = false;
                    btnAltaProyecto.Visible = true;
                    btnActualizaProyecto.Visible = false;
                    btnCancelarProyecto.Visible = true;
                    btnVolverProyecto.Visible = false;
                    btnEliminarProyecto.Visible = false;
                }
                else
                {
                    nombreProyecto.Disabled = true;
                    descripcion.Disabled = true;
                    fechaVencimiento.Disabled = true;
                    avisoVencimientos.Disabled = true;
                    selectPermisos.Disabled = true;
                    btnAgregarUsuario.Disabled = true;
                    txtUsuarioAjax.Disabled = false;
                    LabelProyectos.Text = "Ver Proyecto";
                    btnEditarProyecto.Visible = true;
                    btnCancelarEdicion.Visible = false;
                    btnAltaProyecto.Visible = false;
                    btnCancelarProyecto.Visible = false;
                    btnActualizaProyecto.Visible = false;
                    btnVolverProyecto.Visible = true;
                    if (permiso == "A")
                    {
                        btnEditarProyecto.Visible = true;
                        btnCancelarEdicion.Visible = false;
                        int cantidadModulos = proy.obtieneCantidadModulos(Numproyecto);
                        if(cantidadModulos == 0)
                        {
                            btnEliminarProyecto.Visible = true;
                        }
                        else
                        {
                            btnEliminarProyecto.Visible = false;
                        }
                        
                    }
                    else
                    {
                        btnEditarProyecto.Visible = false;
                        btnCancelarEdicion.Visible = false;
                        btnEliminarProyecto.Visible = false;
                    }
                    Proyectos proyecto = proy.obtieneDatosProyecto(Session["idProyecto"].ToString());
                    List<DatosParticipantesProyecto> partProy = proy.obtieneParticipantes(Session["idProyecto"].ToString());
                    nombreProyecto.Value = proyecto.Nombre;
                    nombreProyecto.Disabled = true;
                    descripcion.Value = proyecto.Descripcion;
                    descripcion.Disabled = true;
                    fechaVencimiento.Value = String.Format("{0:yyyy-MM-dd}", proyecto.FechaVencimiento);
                    fechaVencimiento.Disabled = true;
                    for (int i = 0; i <= avisoVencimientos.Items.Count - 1; i++)
                    {
                        if (avisoVencimientos.Items[i].Value == proyecto.AlertaPrevia)
                        {
                            avisoVencimientos.Items[i].Selected = true;
                        }
                    }
                    fechaVencimiento.Disabled = true;
                    txtUsuarioAjax.Disabled = true;
                    foreach (DatosParticipantesProyecto dp in partProy)
                    {
                       HtmlTableRow rowTablaUsuarios =  this.agregarUsuario_html(dp.nombreUsuario, dp.permiso);
                       tablaUsuariosGrilla.Controls.Add(rowTablaUsuarios);
                    }
                }

            }


        }

        protected void altaProyForm_Click(object sender, EventArgs e)
        {


            DataTable dt = Session["tabla"] as DataTable;
            string usuario = Session["usuario"].ToString();
            Session["permiso"] = "A";
            List<string> usuariosAsignados = new List<string>();
            foreach(DataRow row in dt.Rows)
            {
                usuariosAsignados.Add(row.ItemArray[0] + "-" + row.ItemArray[1]);
            }

            ProyectoLogica agregaProyecto = new ProyectoLogica();
            bool altaExitosa = agregaProyecto.insertaProyecto(nombreProyecto.Value, descripcion.Value, DateTime.Now, Convert.ToDateTime(fechaVencimiento.Value), avisoVencimientos.Value, usuario, usuariosAsignados);
            if (altaExitosa)
            {

                Response.Redirect("~/pantallas/ListaProyectos.aspx");
            }
        }

        protected void actualizaProyForm_Click(object sender, EventArgs e)
        {


            DataTable dt = Session["tabla"] as DataTable;
            string usuario = Session["usuario"].ToString();
            Session["permiso"] = "A";
            List<string> usuariosAsignados = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                usuariosAsignados.Add(row.ItemArray[0] + "-" + row.ItemArray[1]);
            }

            ProyectoLogica agregaProyecto = new ProyectoLogica();
            bool altaExitosa = agregaProyecto.actualizaProyecto(nombreProyecto.Value, descripcion.Value, DateTime.Now, Convert.ToDateTime(fechaVencimiento.Value), avisoVencimientos.Value, usuario, usuariosAsignados, Session["idProyecto"].ToString());
            if (altaExitosa)
            {

                Response.Redirect("~/pantallas/ListaProyectos.aspx");
            }
        }

        protected void cancelarProyForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pantallas/seleccion.aspx");
        }

        //protected void agregoUserProy_Click(object sender, EventArgs e)
        //{
        //    ProyectoLogica verificoUser = new ProyectoLogica();
        //    //bool existe = verificoUser.verificaUsuarioRegistrado(usuarioMail.Value);
        //    //if(!existe)
        //    //{
        //    //    errorUser.Text = "(Ususario no registrado en el sistema!)";
        //    //}
        //    //else
        //    //{
        //    //    errorUser.Text = "";
        //    //    DataTable dt = new DataTable();
        //    //    dt.Clear();
        //    //    dt.Columns.Add("Usuario");
        //    //    dt.Columns.Add("Permiso");
        //    //    DataRow user = dt.NewRow();
        //    //    user["Usuario"] = usuarioMail.Value;
        //    //    user["Permiso"] = permisoUsuario.Value;
        //    //    dt.Rows.Add(user);

        //    //    grillaUsuarios.DataSource = dt;
        //    //    grillaUsuarios.DataBind();
        //    //}

        //}

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public void quitarUsuario_html(string email)
        {

            DataTable dtViejo = Session["tabla"] as DataTable;
            DataTable dtNuevo = dtViejo.Clone();
            foreach (DataRow row in dtViejo.Rows)
            {
                if ((string)row["mail"] != email)
                {
                    DataRow nuevaFila = dtNuevo.NewRow();
                    nuevaFila["mail"] = row["mail"];
                    nuevaFila["permisos"] = row["permisos"];
                    dtNuevo.Rows.Add(nuevaFila);
                }
            }
            Session["tabla"] = dtNuevo;
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public System.Web.UI.HtmlControls.HtmlTableRow agregarUsuario_html(string email, string permisos)
        {
            ProyectoLogica validar = new ProyectoLogica();
            bool usuarioValido = validar.verificaUsuarioRegistrado(email);
            
                DataTable dt = Session["tabla"] as DataTable;


                //System.Web.UI.HtmlControls.HtmlTable tabla = new System.Web.UI.HtmlControls.HtmlTable();
                System.Web.UI.HtmlControls.HtmlTableRow tr = new System.Web.UI.HtmlControls.HtmlTableRow();
                System.Web.UI.HtmlControls.HtmlTableCell td = new System.Web.UI.HtmlControls.HtmlTableCell();
                System.Web.UI.HtmlControls.HtmlInputButton botonEliminar = new System.Web.UI.HtmlControls.HtmlInputButton();

                if (usuarioValido)
                {
                    //creamos una fila
                    tr = new System.Web.UI.HtmlControls.HtmlTableRow();
                    tr.ID = "fila_" + dt.Rows.Count + 1;
                    //agregamos mail
                    td = new System.Web.UI.HtmlControls.HtmlTableCell();
                    td.InnerText = email;
                    tr.Controls.Add(td);
                    //agregamos permisos
                    td = new System.Web.UI.HtmlControls.HtmlTableCell();
                    td.InnerText = permisos;
                    tr.Controls.Add(td);
                    //agregamos boton eliminar
                    botonEliminar.Attributes.Add("onclick", "quitarUsuario('" + tr.ID + "')");
                    botonEliminar.Attributes.Add("value", "Eliminar");
                    botonEliminar.Attributes.Add("type", "button");
                    td = new System.Web.UI.HtmlControls.HtmlTableCell();
                    td.Controls.Add(botonEliminar);
                    tr.Controls.Add(td);
                    //Agregamos la fila a la tabla
                    //tablaUsuariosGrilla.Controls.Add(tr);


                    DataRow row = dt.NewRow();
                    row["mail"] = email;
                    row["permisos"] = permisos;
                    dt.Rows.Add(row);
                    dt.AcceptChanges();
                    Session["tabla"] = dt;
                }
                else
                { 
                    
                }
            return tr;




            //divTablaUsuariosGrilla.Controls.Add()
        }



        //[AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        //public void agregarUsuario_asp(string email, string permisos)
        //{
        //    DataTable dt = Session["tabla"] as DataTable;
        //    DataRow row = dt.NewRow();
        //    GridView gr = new GridView();
        //    gr.ID = "GridView1";
        //    gr.AutoGenerateDeleteButton = true;
        //    gr.DeleteMethod = "GridView1_RowDeleting";
        //    gr.AutoGenerateColumns = true;


        //    row["mail"] = dt.Rows.Count + 1;
        //    row["permisos"] = email;
        //    dt.Rows.Add(row);
        //    dt.AcceptChanges();
        //    gr.DataSource = dt;
        //    //gr.DataBind();
        //    Session["tabla"] = dt;
        //    //tablaDatos.Controls.Clear();
        //    //tablaDatos.Controls.Add(gr);

        //    //divTablaUsuariosGrilla.Controls.Add()
        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = Session["tabla"] as DataTable;
        //    DataRow row = dt.NewRow();
        //    row["mail"] = this.GridView1.Rows.Count + 1;
        //    row["permisos"] = txtUsuario.Text;
        //    dt.Rows.Add(row);
        //    dt.AcceptChanges();
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
        //    Session["tabla"] = dt;
        //}

        //protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        //{
        //    string a = "";
        //}

        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    string a = "";
        //    TableCell cell = GridView1.Rows[e.RowIndex].Cells[1];

        //    DataTable dtViejo = Session["tabla"] as DataTable;
        //    DataTable dtNuevo = dtViejo.Clone();
        //    foreach (DataRow row in dtViejo.Rows)
        //    {
        //        if (row["mail"] != cell.Text)
        //        {
        //            dtNuevo.Rows.Add(row);
        //        }
        //    }
        //    Session["tabla"] = dtNuevo;

        //}

        protected void editarProyecto_Click(object sender, EventArgs e)
        {
            LabelProyectos.Text = "Editar Proyecto";
            btnEditarProyecto.Visible = false;
            btnCancelarEdicion.Visible = true;
            nombreProyecto.Disabled = false;
            descripcion.Disabled = false;
            fechaVencimiento.Disabled = false;
            avisoVencimientos.Disabled = false;
            selectPermisos.Disabled = false;
            btnAgregarUsuario.Disabled = false;
            txtUsuarioAjax.Disabled = false;

            btnAltaProyecto.Visible = false;
            btnCancelarProyecto.Visible = false;
            btnVolverProyecto.Visible = false;
            btnActualizaProyecto.Visible = true;
        }

        protected void eliminarProyecto_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/pantallas/EliminarProyecto.aspx");

        }

        protected void cancelarProyecto_Click(object sender, EventArgs e)
        {
            LabelProyectos.Text = "Ver Proyecto";
            btnEditarProyecto.Visible = true;
            btnCancelarEdicion.Visible = false;
            nombreProyecto.Disabled = true;
            descripcion.Disabled = true;
            fechaVencimiento.Disabled = true;
            avisoVencimientos.Disabled = true;
            selectPermisos.Disabled = true;
            btnAgregarUsuario.Disabled = true;
            txtUsuarioAjax.Disabled = true;

            btnAltaProyecto.Visible = false;
            btnCancelarProyecto.Visible = false;
            btnActualizaProyecto.Visible = false;
            btnVolverProyecto.Visible = true;
        }

    }
}