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
                alert("entro");
                yaSeGeneroAccordion = true;
            } else {
                $("#MainContent_contenedorAccordion").accordion({
                    collapsible: true,
                    heightStyle: "content"
                });
                alert("entro");
                yaSeGeneroAccordion = true;
            }


        });
        
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">
        <section class="wrapper style3 container special">
			<header class="major">
				<h2><strong>Proyecto PEPE</strong></h2>
                <input id="Button1" type="button" onclick="generarAccordion()" value="button" />
			</header>
            <h4><asp:HyperLink ID="HyperLink1" NavigateUrl="#" runat="server">Agregar Tarea</asp:HyperLink>&nbsp&nbsp<asp:HyperLink ID="HyperLink2" NavigateUrl="#" runat="server">Agregar Modulo</asp:HyperLink>&nbsp&nbsp<asp:HyperLink ID="HyperLink3" NavigateUrl="#" runat="server">Graficos Estadisticos</asp:HyperLink></h4>
				<asp:ScriptManager ID="asm" runat="server">
                                
                </asp:ScriptManager>
				<div id="contenedorAccordion" runat="server">

                </div>    
        	</section>
    </article>

</asp:Content>

