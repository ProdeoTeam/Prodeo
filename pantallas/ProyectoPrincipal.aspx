<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProyectoPrincipal.aspx.cs" Inherits="Prodeo.pantallas.ProyectoPrincipal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">
    <section class="wrapper style3 container special">
						<header class="major">
							<h2><strong>Proyecto PEPE</strong></h2>
						</header>
                    <h4><asp:HyperLink ID="HyperLink1" NavigateUrl="#" runat="server">Agregar Tarea</asp:HyperLink>&nbsp&nbsp<asp:HyperLink ID="HyperLink2" NavigateUrl="#" runat="server">Agregar Modulo</asp:HyperLink>&nbsp&nbsp<asp:HyperLink ID="HyperLink3" NavigateUrl="#" runat="server">Graficos Estadisticos</asp:HyperLink></h4>
							<asp:ScriptManager ID="asm" runat="server">
                                
                                </asp:ScriptManager>
                            <asp:Accordion id="Accordion1" runat="server" Width="100%" SuppressHeaderPostbacks="true" OnItemDataBound="Accordion1_ItemDataBound" > 

                                <HeaderTemplate> 
                                <asp:Label runat="server" Id="lbHeaderId" Text='<%#Eval("Cus_Type") %>'> </asp:Label> 
                                </HeaderTemplate> 

                                <ContentTemplate> 

                                <asp:HiddenField runat="server" id="hidCusType" value='<%#Eval("Cus_Type") %>'> </asp:HiddenField> 

                                <asp:GridView runat="server" id="GridView1" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="Cus_Type,Cus_Code" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" RowStyle-ForeColor="#6666FF" HeaderStyle-BackColor="#DADFE3"> 

                                <Columns> 

                                <asp:TemplateField HeaderText="Name" SortExpression="Cus_Name"> 
                                <EditItemTemplate> 
                                <asp:TextBox ID="TxCusName" runat="server" Text='<%# Bind("Cus_Name") %>' CssClass="InputFieldLogin"></asp:TextBox> 
                                </EditItemTemplate> 
                                <ItemTemplate> 
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Cus_Name") %>' ></asp:Label> 
                                </ItemTemplate> 
                                </asp:TemplateField> 

                                <asp:TemplateField HeaderText="Gender"> 
                                <EditItemTemplate> 
                                <asp:TextBox ID="TxCusGender" runat="server" Text='<%# Bind("Cus_Gender") %>' CssClass="InputFieldLogin" width="50px"></asp:TextBox> 
                                </EditItemTemplate> 
                                <ItemTemplate> 
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Cus_Sex") %>'></asp:Label> 
                                </ItemTemplate> 
                                </asp:TemplateField> 

                                <asp:TemplateField HeaderText="City"> 
                                <EditItemTemplate> 
                                <asp:TextBox ID="TxCusCity" runat="server" Text='<%# Bind("Cus_City") %>' CssClass="InputFieldLogin"></asp:TextBox> 
                                </EditItemTemplate> 
                                <ItemTemplate> 
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Cus_City") %>'></asp:Label> 
                                </ItemTemplate> 
                                </asp:TemplateField> 

                                <asp:TemplateField HeaderText="State"> 
                                <EditItemTemplate> 
                                <asp:TextBox ID="TxCusState" runat="server" Text='<%# Bind("Cus_State") %>' CssClass="InputFieldLogin"></asp:TextBox> 
                                </EditItemTemplate> 
                                <ItemTemplate> 
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Cus_State") %>'></asp:Label> 
                                </ItemTemplate> 
                                </asp:TemplateField> 

                                <asp:CommandField HeaderText="Update" ShowEditButton="True"> </asp:CommandField> 

                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True"> 
                                </asp:CommandField> 

                                </Columns> 
                                <EmptyDataTemplate> 
                                <asp:Label ID="Label1" runat="server" CssClass="WarnBold" Text="No Records Found."></asp:Label> 
                                </EmptyDataTemplate> 
                                </asp:GridView> 
                                </ContentTemplate> 
                                </asp:Accordion>      

                    </section>
        </article> 

</asp:Content>
