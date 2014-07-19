using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prodeo.pantallas
{
    public partial class ProyectoPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                BindAccordion();
            
        }

        private void BindAccordion() 
            { 
              string sql = "Select distinct Cus_Type from Customers";
              SqlConnection conn = new SqlConnection("Data Source=localhost;Integrated security=SSPI;Initial Catalog=Customers;");
              conn.Open();
              SqlDataAdapter da = new SqlDataAdapter(sql, conn); 
              DataTable dt = new DataTable(); 
              da.Fill(dt);

              Accordion1.DataSource = dt.DefaultView;
              Accordion1.DataBind();
              conn.Close();
            }

        protected void Accordion1_ItemDataBound(object sender, AjaxControlToolkit.AccordionItemEventArgs e) 
        { 
          if (e.ItemType == AccordionItemType.Content) 
          { 
            GridView GridView1 = (GridView)e.AccordionItem.FindControl("GridView1"); 
            HiddenField hidCusType = (HiddenField)e.AccordionItem.FindControl("hidCusType"); 
            BindGrid(GridView1, hidCusType.Value); 
          } 
        }

        private void BindGrid(GridView Grid, string lCustomerType) 
        { 
          string sql = "Select * from Customers Where Cus_Type=@CustomerType";
          SqlDataAdapter da = new SqlDataAdapter(sql, "Data Source=localhost;Integrated security=SSPI;Initial Catalog=Customers;"); 
          da.SelectCommand.Parameters.Add("@CustomerType", SqlDbType.VarChar, 20).Value = lCustomerType; 

          DataTable dt = new DataTable(); 
          da.Fill(dt); 

          Grid.DataSource = dt; 
          Grid.DataBind(); 
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e) 
        { 
          GridView GridView1 = (GridView)sender; 
          GridView1.EditIndex = e.NewEditIndex; 
          BindGrid(GridView1, GridView1.DataKeys[0].Value.ToString()); 
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) 
        { 
          GridView GridView1 = (GridView)sender; 
          GridView1.EditIndex = -1; 
          BindGrid(GridView1, GridView1.DataKeys[0].Value.ToString()); 
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e) 
        { 
          GridView GridView1 = (GridView)sender; 

          TextBox TxCusName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TxCusName"); 
          TextBox TxCusGender = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TxCusGender"); 
          TextBox TxCusCity = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TxCusCity"); 
          TextBox TxCusState = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TxCusState"); 

          string sql = "Update Customers Set Cus_Name=@CustomerName," 
        + "Cus_Gender=@CustomerGender, Cus_City=@CustomerCity, " 
        + " Cus_State=@CustomerState, Cus_Type=@CustomerType "
        + "Where Cus_Code=@CustomerCode";

          SqlConnection conn = new SqlConnection("Data Source=localhost;Integrated security=SSPI;Initial Catalog=Customers;"); 
          conn.Open(); 
          SqlCommand cmd = new SqlCommand(sql, conn); 
          cmd.Parameters.Add("@CustomerCode", SqlDbType.Int).Value = 
            GridView1.DataKeys[e.RowIndex].Values[1].ToString(); 
          cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar, 50).Value = TxCusName.Text; 
          cmd.Parameters.Add("@CustomerGender", SqlDbType.VarChar, 6).Value = TxCusGender.Text; 
          cmd.Parameters.Add("@CustomerCity", SqlDbType.VarChar, 50).Value = TxCusCity.Text; 
          cmd.Parameters.Add("@CustomerState", SqlDbType.VarChar, 50).Value = TxCusState.Text; 

          cmd.Prepare(); 
          cmd.ExecuteNonQuery(); 
          conn.Close(); 

          GridView1.EditIndex = -1; 
          BindGrid(GridView1, GridView1.DataKeys[e.RowIndex].Values[0].ToString()); 

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e) 
        { 
          GridView GridView1 = (GridView)sender; 
          string sql = "Delete From Customers Where Cus_Code=@CustomerCode";

          SqlConnection conn = new SqlConnection("Data Source=localhost;Integrated security=SSPI;Initial Catalog=Customers;"); 
          conn.Open(); 
          SqlCommand cmd = new SqlCommand(sql, conn); 
          cmd.Parameters.Add("@CustomerCode", SqlDbType.Int).Value = 
            GridView1.DataKeys[e.RowIndex].Values[1].ToString(); 
          cmd.Prepare(); 
          cmd.ExecuteNonQuery(); 
          conn.Close(); 
          BindGrid(GridView1, GridView1.DataKeys[e.RowIndex].Values[0].ToString()); 
        }

    }
}