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
					<h2>Proyecto 1 : descripcion...</h2>
					<a href="#" class="button">Administrador</a>
				</section><br />
                <section id="vistaProyecto">
					<h2>Proyecto 2 : descripcion...</h2>
					<a href="#" class="button">Administrador</a>
				</section><br />
                <section id="vistaProyecto">
					<h2>Proyecto 3 : descripcion...</h2>
					<a href="#" class="button">Colaborador</a>
				</section><br />

            </section>
    </article> 

</asp:Content>
