<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaProyectos.aspx.cs" Inherits="Prodeo.pantallas.AltaProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
    <link href="../Styles/formulariosInternos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">
            <section class="wrapper style3 container special">
				<h2>Lista de Proyectos:</h2>
                <section id="vistaProyecto">
					<h2>Proyecto 1 : Administrador</h2>
                    <h3>asdadasd asdads asdads asdasd asdasd asdasda</h3>
					<a href="ProyectoPrincipal.aspx" class="button">Ingresar</a>
				</section><br />
                <section id="vistaProyecto">
					<h2>Proyecto 2 : Administrador</h2>
                    <h3>asdadasd asdads asdads asdasd asdasd asdasda</h3>
					<a href="#" class="button">Ingresar</a>
				</section><br />
                <section id="vistaProyecto">
					<h2>Proyecto 3 : Colaborador</h2>
                    <h3>asdadasd asdads asdads asdasd asdasd asdasda</h3>
					<a href="#" class="button">Ingresar</a>
				</section><br />

            </section>
    </article> 

</asp:Content>
