<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="seleccion.aspx.cs" Inherits="Prodeo.pantallas.seleccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">
    <section class="wrapper style3 container special">
					
						<header class="major">
							<h2><strong>Que desea hacer???</strong></h2>
						</header>
						
						<div class="row">
							<div class="6u">
							
								<section>
									<a href="#" class="image feature"> <asp:Image ID="Image1" ImageUrl="~/images/btnCrearProyecto.jpg" runat="server"></asp:Image> </a>
									<header>
										<h3>Crear un Proyecto</h3>
									</header>
									<p>Aqui puede dar de alta un proyecto a su medida que le va a ayudar a controlarlo de la forma mas adecuada.</p>
								</section>

							</div>
							<div class="6u">
							
								<section>
									<a href="#" class="image feature"><asp:Image ID="Image2" ImageUrl="~/images/btnVerProyecto.jpg" runat="server"></asp:Image></a>
									<header>
										<h3>Ver sus Proyectos</h3>
									</header>
									<p>Aqui podra hacer cambios y seguimientos de todos sus proyetos.</p>
								</section>

							</div>
						</div>

						<footer class="major">
							<ul class="buttons">
								<li><a href="#" class="button">Ayuda</a></li>
							</ul>
						</footer>
					
					</section>
        </article> 

</asp:Content>
