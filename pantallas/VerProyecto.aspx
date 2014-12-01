<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerProyecto.aspx.cs" Inherits="Prodeo.pantallas.VerProyecto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    
    
    <script type="text/javascript">
        //============== Con Login, accede primero a Login.aspx ==============

        var yaSeGeneroAccordion = false;
        $(function () {
            if (yaSeGeneroAccordion) {
                $("#MainContent_contenedorAccordion").accordion('refresh');
                //alert("entro");
                yaSeGeneroAccordion = true;
            } else {
                $("#MainContent_contenedorAccordion").accordion({
                    collapsible: true,
                    heightStyle: "content"
                });
                //alert("entro");
                yaSeGeneroAccordion = true;
            }


        });
        
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">
        <section class="wrapper style3 container special">
			<header class="major">
				<h2><strong>Proyecto </strong><asp:Label ID="nombreProyecto" runat="server" Text="" Font-Bold="True"></asp:Label></h2>
                <%--<input id="Button1" type="button" onclick="generarAccordion()" value="button" />--%>
			</header>
            <%--<h4><asp:HyperLink ID="HyperLink1" NavigateUrl="~/pantallas/AltaTarea.aspx" runat="server">Agregar Tarea</asp:HyperLink>&nbsp&nbsp<asp:HyperLink ID="HyperLink2" NavigateUrl="~/pantallas/AltaModulo.aspx" runat="server">Agregar Modulo</asp:HyperLink>&nbsp&nbsp<asp:HyperLink ID="HyperLink3" NavigateUrl="#" runat="server">Graficos Estadisticos</asp:HyperLink></h4>--%>
            <footer>
					<ul class="buttons">
						<li id="liTarea" runat="server"><a href="~/pantallas/AltaTarea.aspx" class="button" runat="server">Agregar Tarea</a></li>
						<li id="liModulo" runat="server"><a href="~/pantallas/AltaModulo.aspx" class="button" runat="server">Agregar Modulo</a></li>
                        <li id="liGraficos" runat="server"><a href="~/pantallas/Reportes.aspx" class="button" runat="server">Graficos Estadisticos</a></li>
					</ul>
			</footer>
				<asp:ScriptManager ID="asm" runat="server">
                                
                </asp:ScriptManager>
				<div id="contenedorAccordion" runat="server" class="default">

                </div>    
        	</section>
    </article>

</asp:Content>

