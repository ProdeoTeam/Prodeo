using System;
using System.Collections.Generic;
using System.Linq;
using Negocio;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Prodeo.pantallas
{
    public partial class AltaProyecto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FirstGridViewRow();
            }
        }

        private void FirstGridViewRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dt.Columns.Add(new DataColumn("Col3", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Col1"] = string.Empty;
            dr["Col2"] = string.Empty;
            dr["Col3"] = string.Empty;
            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;


            gvUsuarios.DataSource = dt;
            gvUsuarios.DataBind();


            TextBox txn = (TextBox)gvUsuarios.Rows[0].Cells[1].FindControl("txtAddUser");
            txn.Focus();
            Button btnAdd = (Button)gvUsuarios.FooterRow.Cells[4].FindControl("btnAgregarUsuario");
            Page.Form.DefaultFocus = btnAdd.ClientID;

        }

        protected void altaProyForm_Click(object sender, EventArgs e)
        {
            string usuario = Session["usuario"].ToString();
            ProyectoLogica agregaProyecto = new ProyectoLogica();
            bool altaExitosa = agregaProyecto.insertaProyecto(nombreProyecto.Value, descripcion.Value, DateTime.Now, Convert.ToDateTime(fechaVencimiento.Value), avisoVencimientos.Value,usuario);
            if (altaExitosa)
            {
                Response.Redirect("~/pantallas/ListaProyectos.aspx");
            }
        }

        protected void cancelarProyForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pantallas/ListaProyectos.aspx");
        }

        protected void agregoUserProy_Click(object sender, EventArgs e)
        {
            ProyectoLogica verificoUser = new ProyectoLogica();
            //bool existe = verificoUser.verificaUsuarioRegistrado(usuarioMail.Value);
            //if(!existe)
            //{
            //    errorUser.Text = "(Ususario no registrado en el sistema!)";
            //}
            //else
            //{
            //    errorUser.Text = "";
            //    DataTable dt = new DataTable();
            //    dt.Clear();
            //    dt.Columns.Add("Usuario");
            //    dt.Columns.Add("Permiso");
            //    DataRow user = dt.NewRow();
            //    user["Usuario"] = usuarioMail.Value;
            //    user["Permiso"] = permisoUsuario.Value;
            //    dt.Rows.Add(user);

            //    grillaUsuarios.DataSource = dt;
            //    grillaUsuarios.DataBind();
            //}

        }
        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}