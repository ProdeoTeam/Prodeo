<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaTarea.aspx.cs" Inherits="Prodeo.pantallas.AltaTarea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
    <link href="../Styles/formulariosInternos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">
    <section class="wrapper style3 container special">
				<div id="formInterno">
						<header class="major">
							<h2><strong>Alta de Tareas</strong></h2>
						</header>
									<div class="row half">
										<div class="12u">
											<input type="text" name="nombreTarea" placeholder="Nombre" id="nombreTarea" runat="server">
										</div>
									</div>
                                    <div class="row half">
										<div class="12u">
											<input type="text" name="descripcion" placeholder="Descripcion" id="descripcion" runat="server">
										</div>
									</div>
									<div class="row half">
										<div class="12u">
											<textarea name="comentario" placeholder="Comentario" rows="7" id="comentario" runat="server"></textarea>
										</div>
									</div>
                                    <div class="row half">
                                        <div class="6u">
                                            &nbsp;
                                            <select name="listaModulos" id="listaModulos" runat="server">
                                              <option value="seleccione" selected>Seleccione Modulo</option>
                                              
                                            </select>
										</div>
                                        <div class="6u">
                                            &nbsp;
                                            <select name="listaPrioridad" id="listaPrioridad" runat="server">
                                              <option value="seleccione" selected>Seleccione Prioridad</option>
                                              <option value="N">Ninguna</option>
                                              <option value="A">Alta</option>
                                              <option value="M">Media</option>
                                              <option value="B">Baja</option>
                                            </select>
										</div>
                                      </div>
                                    <div class="row half no-collapse-1">
                                        <div class="6u">
                                            Fecha Vencimiento
                                            <input type="date" name="fechaVencimiento" id="fechaVencimiento" runat="server">
										</div>
										<div class="6u">
                                            &nbsp;
                                            <select name="avisoVencimientos" id="avisoVencimientos" runat="server">
                                              <option value="seleccione" selected>Seleccione avisos</option>
                                              <option value="h-0">Nunca</option>
                                              <option value="h-1">1 hora antes</option>
                                              <option value="d-1">1 dia antes</option>
                                              <option value="d-2">2 dias antes</option>
                                              <option value="d-7">1 semana antes</option>
                                              <option value="m-1">1 mes antes</option>
                                            </select>
										</div>
                                        
									</div>
                                    <div class="row half no-collapse-1">
										<div class="6u">
                                            &nbsp;
                                            <select name="usuariosLista" id="usuariosLista" runat="server">
                                              <option value="seleccione" selected>Seleccione usuario</option>
                                              
                                            </select>
										</div>
                                        
									</div>
                          
									<div class="row">
										<div class="12u">
											<ul class="buttons">
												<li><a class="button special" id="btnAltaTarea" runat="server" onserverclick="altaTareaForm_Click">Alta</a></li>
                                                <li><a class="button special" id="btnCalcelarTarea" runat="server" onserverclick="cancelarTareaForm_Click">Cancelar</a></li>
											</ul>
										</div>
									</div>
                    </div>
                    </section>
        </article> 
</asp:Content>
