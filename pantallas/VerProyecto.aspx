<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerProyecto.aspx.cs" Inherits="Prodeo.pantallas.VerProyecto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta name="viewport" content="width = device-width, initial-scale = 1.0, minimum-scale = 1.0, maximum-scale = 1.0, user-scalable = no" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/formulariosInternos.css" rel="stylesheet" type="text/css"/>    
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
                    active: false,
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
                <input id="btnVerProyecto" type="button" onserverclick="btnVerProyecto_Click" value="Ver Proyecto" runat="server"/>
			</header>
            
            <footer>
					<ul class="buttons">
						<li id="liTarea" runat="server"><a id="linkAgregarTarea" href="~/pantallas/AltaTarea.aspx" class="button" runat="server">Agregar Tarea</a></li>
						<li id="liModulo" runat="server"><a href="~/pantallas/AltaModulo.aspx" class="button" runat="server">Agregar Módulo</a></li>
                        <li id="liGraficos" runat="server"><a href="~/pantallas/Reportes.aspx" class="button" runat="server">Gráficos Estadísticos</a></li>
					</ul>
			</footer>
			
            <asp:ScriptManager ID="asm" runat="server">                    
            </asp:ScriptManager>

            <script src="../js/footable.min.js" type="text/javascript"></script>
            <script type="text/javascript">
                //============== función del plugin footable ==============
                $(function () {
                    $('[Id*=GridView1]').footable();
                });
            </script>
            <br />
            <asp:Panel ID="Panel1" runat="server" groupingtext="Listado de Módulos" BorderColor="Gray" BorderWidth="2px">
                <div id="contenedorAccordion" runat="server" class="default">                
                </div>
            </asp:Panel>                               
        </section>            
    </article>
</asp:Content>

