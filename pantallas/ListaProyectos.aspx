<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaProyectos.aspx.cs" Inherits="Prodeo.pantallas.AltaProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
    <link href="../Styles/formulariosInternos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">
    <section class="wrapper style3 container special">
				<div id="formInterno">
						<header class="major">
							<h2><strong>Lista de Proyectos</strong></h2>
						</header>
									<section class="wrapper styleListaProy">
						            <div>
							            		<a href="ProyectoPrincipal.aspx">Proyecto 1</a>	
						            </div>
					            </section>
                    <section class="wrapper styleListaProy">
						            <div>
							            		Proyecto 1	
						            </div>
					            </section>
                    <section class="wrapper styleListaProy">
						            <div>
							            		Proyecto 1	
						            </div>
					            </section>
                    </div>
                    </section>
        </article> 

</asp:Content>
