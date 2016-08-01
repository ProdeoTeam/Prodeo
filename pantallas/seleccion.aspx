<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="seleccion.aspx.cs" Inherits="Prodeo.pantallas.seleccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<section id="banner">
        </section>--%>
    <article id="main">
    <section class="wrapper style3 container special">
					
						<header class="major">
							<h2><strong>¿Qué desea hacer?</strong></h2>
						</header>
						
						<div class="row">
							<div class="6u">
							
								<section>
									<a href="AltaProyecto.aspx" class="image feature"> <asp:Image ID="Image1" ImageUrl="~/images/btnCrearProyecto.jpg" runat="server"></asp:Image> </a>
									<header>
										<h3>Crear un Proyecto</h3>
									</header>
									<p>Aquí puede dar de alta un proyecto a su medida que le va a ayudar a controlarlo de la forma más adecuada.</p>
								</section>

							</div>
							<div class="6u">
							
								<section>
									<a href="ListaProyectos.aspx" class="image feature"><asp:Image ID="Image2" ImageUrl="~/images/btnVerProyecto.jpg" runat="server"></asp:Image></a>
									<header>
										<h3>Ver sus Proyectos</h3>
									</header>
									<p>Aquí podrá hacer cambios y seguimientos de todos sus proyectos.</p>
								</section>

							</div>
						</div>

						<%--<footer class="major">
							<ul class="buttons">
								<li><a href="#" class="button">Ayuda</a></li>
							</ul>
						</footer>--%>
					
					</section>
        </article> 

</asp:Content>
