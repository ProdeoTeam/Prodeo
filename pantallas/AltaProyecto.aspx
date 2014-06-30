<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaProyecto.aspx.cs" Inherits="Prodeo.pantallas.AltaProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
    <link href="../Styles/formulariosInternos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">
    <section class="wrapper style3 container special">
				<div id="formInterno">
						<header class="major">
							<h2><strong>Alta de Proyecto</strong></h2>
						</header>
						
						<div class="row half no-collapse-1">
										<div class="6u">
											<input type="text" name="nombreProyecto" placeholder="Nombre">
										</div>
										<div class="6u">
											<input type="text" name="tipoProyecto" placeholder="Tipo">
										</div>
									</div>
									<div class="row half">
										<div class="12u">
											<input type="text" name="subject" placeholder="Subject">
										</div>
									</div>
									<div class="row half">
										<div class="12u">
											<textarea name="message" placeholder="Comentarios" rows="7"></textarea>
										</div>
									</div>
									<div class="row">
										<div class="12u">
											<ul class="buttons">
												<li><a href="#" class="button special">Alta</a></li>
											</ul>
										</div>
									</div>
                    </div>
                    </section>
        </article> 

</asp:Content>
