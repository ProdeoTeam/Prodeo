<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Prodeo.pantallas.AltaProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
    <link href="../Styles/formulariosInternos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">
    <section class="wrapper style3 container special">
				<div id="formInterno">
						<header class="major">
							<h2><strong>Registro</strong></h2>
						</header>
									<div class="row half">
										<div class="12u">
											<input type="text" name="nombreProyecto" placeholder="Nombre">
										</div>
									</div>
									<div class="row half">
										<div class="12u">
											<textarea name="descripcion" placeholder="Descripcion" rows="7"></textarea>
										</div>
									</div>
                                    <div class="row half no-collapse-1">
										<div class="6u">
                                            <input type="date" name="fechaFinal">
										</div>
									</div>
                                    <div class="row half no-collapse-1">
										<div class="6u">
											<input type="text" name="participantes" placeholder="Participantes">
										</div>
										<div class="6u">
                                            <select name="privilegio">
                                              <option value="seleccione" selected>Seleccione privilegio</option>
                                              <option value="admin">Administrador</option>
                                              <option value="col">Colaborador</option>
                                            </select>
										</div>
									</div>
                                    <div class="row half no-collapse-1">
										<div class="6u">
                                            <select name="avisoVencimientos">
                                              <option value="seleccione" selected>Seleccione avisos</option>
                                              <option value="nunca">Nunca</option>
                                              <option value="1hora">1 hora antes</option>
                                              <option value="1dia">1 dia antes</option>
                                              <option value="2dia">2 dias antes</option>
                                              <option value="1semana">1 semana antes</option>
                                              <option value="1mes">1 mes antes</option>
                                            </select>
										</div>
									</div>
									<div class="row">
										<div class="12u">
											<ul class="buttons">
												<li><a href="ListaProyectos.aspx" class="button special">Registrarse</a></li>
											</ul>
										</div>
									</div>
                    </div>
                    </section>
        </article> 

</asp:Content>
