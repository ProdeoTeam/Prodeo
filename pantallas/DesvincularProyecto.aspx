<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DesvincularProyecto.aspx.cs" Inherits="Prodeo.pantallas.DesvincularProyecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
    <link href="../Styles/formulariosInternos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">
        <section class="wrapper style3 container special"> 
			<div id="formInterno">
			    <header class="major">
				    <h2><strong><asp:Label ID="LabelElimTareas" runat="server" Text="Label"></asp:Label></strong></h2>
			    </header>
                <footer>
					<ul class="buttons">
						<li id="btnDesvincularProyecto" runat="server"><a class="button" onserverclick="desvincularProyecto_Click" runat="server">Desvincular Proyecto</a></li>
                        <li id="btnCancelar" runat="server"><a class="button" onserverclick="cancelar_Click" runat="server">Cancelar</a></li>        
					</ul>
			    </footer>                                    
            </div>
        </section>
    </article> 
</asp:Content>