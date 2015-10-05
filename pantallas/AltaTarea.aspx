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
							<h2><strong><asp:Label ID="LabelTareas" runat="server" Text="Label"></asp:Label></strong></h2>
						</header>
                        <footer>
					            <ul class="buttons">
						            <li id="btnEditarTarea" runat="server"><a class="button" onserverclick="editarTarea_Click" runat="server">Editar Tarea</a></li>
                                    <li id="btnCancelarEdicion" runat="server"><a class="button" onserverclick="cancelarTarea_Click" runat="server">Cancelar Edicion</a></li>
                                    <li id="btnEditarComentario" runat="server"><a class="button" onserverclick="editarComentario_Click" runat="server">Editar Comentario</a></li>
					            </ul>
			            </footer>
									<div class="row half">
										<div class="12u">
											<input type="text" name="nombreTarea" placeholder="Nombre" id="nombreTarea" runat="server"/>
                                            <asp:RequiredFieldValidator ID="ReqFieldValNombre" Display="Dynamic" ControlToValidate="nombreTarea" ValidationGroup ="valGroupTareas" runat="server" ErrorMessage="Debe ingresarle un nombre a la tarea"></asp:RequiredFieldValidator>                                            
										</div>
									</div>
                                    <div class="row half">
										<div class="12u">
											<textarea name="descripcion" rows="3" placeholder="Descripcion" id="descripcion" runat="server"></textarea>
										</div>
									</div>
									<div class="row half">
										<div class="12u">
											<textarea name="comentario" placeholder="Comentario" rows="7" id="comentario" runat="server"></textarea>
										</div>
									</div>
                                    <div class="row half">
                                        <div class="6u">
                                            <label>M&oacute;dulo</label>
                                            &nbsp;

                                            
                                            <%--<select name="listaModulos" id="listaModulos" runat="server">                                              
                                                <option selected="selected" value ="none" >ninguno</option>
                                            </select>                                            
                                            --%>                                                                                       
                                            
                                            <asp:DropDownList ID="listaModulos" runat="server">
                                                <asp:ListItem>Seleccionar</asp:ListItem>
                                            </asp:DropDownList>
										    <asp:RequiredFieldValidator ID="ReqFieldModul" Display="Dynamic" ControlToValidate="listaModulos" ValidationGroup ="valGroupTareas" runat="server" ErrorMessage="Debe elegir el m&oacute;dulo. Si no tiene ninguno, debe crearlo previamente."  ></asp:RequiredFieldValidator>    
                                        </div>
                                        <div class="6u">
                                            &nbsp;                                                                                        
                                            <label>Prioridad</label>
                                            <select name="listaPrioridad" id="listaPrioridad" runat="server">                                              
                                              <option selected="selected" value="N">Ninguna</option>
                                              <option value="A">Alta</option>
                                              <option value="M">Media</option>
                                              <option value="B">Baja</option>
                                            </select>
										</div>
                                      </div>
                                    <div class="row half no-collapse-1">
                                        <div class="12u">
                                            <label>Fecha Vencimiento</label>                                                                                       
                                            <%--<asp:TextBox ID="fechaVencimiento" runat="server" ></asp:TextBox>--%>
                                            <input type="date" name="fechaVencimiento" id="fechaVencimiento" runat="server" placeholder="DD/MM/AAAA">                                            
                                            <asp:CustomValidator ID="CustomValVencValid" Display="Dynamic" ControlToValidate="fechaVencimiento" ValidationGroup ="valGroupTareas" runat="server" OnServerValidate="validarFechaVenc"></asp:CustomValidator>
                                            <asp:CustomValidator ID="CustomValFechActual" Display="Dynamic" ControlToValidate="fechaVencimiento" ValidationGroup ="valGroupTareas" runat="server" OnServerValidate="validarFechaActual"></asp:CustomValidator>
                                            <asp:RequiredFieldValidator ID="ReqFieldValVenc" Display="Dynamic" ControlToValidate="fechaVencimiento" ValidationGroup ="valGroupTareas" runat="server" ErrorMessage="Debe ingresar una fecha de vencimiento"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegExpresValFecha" Display="Dynamic" ControlToValidate="fechaVencimiento" ValidationGroup ="valGroupTareas" runat="server" ErrorMessage="Formato de fecha inv&aacute;lido o fecha incorrecta." 
                                                ValidationExpression="^(?:(?:0?[1-9]|1\d|2[0-8])(\/|-)(?:0?[1-9]|1[0-2]))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(?:(?:31(\/|-)(?:0?[13578]|1[02]))|(?:(?:29|30)(\/|-)(?:0?[1,3-9]|1[0-2])))(\/|-)(?:[1-9]\d\d\d|\d[1-9]\d\d|\d\d[1-9]\d|\d\d\d[1-9])$|^(29(\/|-)0?2)(\/|-)(?:(?:0[48]00|[13579][26]00|[2468][048]00)|(?:\d\d)?(?:0[48]|[2468][048]|[13579][26]))$"></asp:RegularExpressionValidator>                            
										</div>
										<%--<div class="6u">
                                            Fecha Finalizacion
                                            <input type="date" name="fechaFinalizacion" id="fechaFinalizacion" runat="server">
										</div>--%>
                                        
									</div>
                                    <div class="row half no-collapse-1">
										<div class="6u">                                            
                                            &nbsp;
                                            <label>Usuario asignado</label>
                                            <select name="usuariosLista" id="usuariosLista" runat="server">                                                                                            
                                            </select>
										</div>
                                        <div class="6u">
                                            &nbsp;
                                            <label>Alerta</label>
                                            <select name="avisoVencimientos" id="avisoVencimientos" runat="server">                                              
                                              <option selected="selected" value="h-0">Nunca</option>
                                              <option value="h-1">1 hora antes</option>
                                              <option value="d-1">1 dia antes</option>
                                              <option value="d-2">2 dias antes</option>
                                              <option value="d-7">1 semana antes</option>
                                              <option value="m-1">1 mes antes</option>
                                            </select>
										</div>
									</div>
                          
									<div class="row">
										<div class="12u">
											<ul class="buttons">
												<li><a class="button special" id="btnAltaTarea" runat="server" onserverclick="altaTareaForm_Click" ValidationGroup ="valGroupTareas">Alta</a></li>
                                                <li><a class="button special" id="btnCalcelarTarea" runat="server" onserverclick="cancelarTareaForm_Click">Cancelar</a></li>
                                                <li><a class="button special" id="btnVolverTarea" runat="server" onserverclick="cancelarTareaForm_Click">Volver</a></li>
											</ul>
										</div>
									</div>
                                    <div class="row half no-collapse-1">
                                        <div class="6u">
                                            <input type="number" name="horasTarea" placeholder="Horas" id="txtHoras" runat="server"/>
										</div>
										<div class="6u">
                                            <ul class="buttons">
												<li><a class="button special" id="btnFinalizarTarea" runat="server" onserverclick="finalizarTareaForm_Click">Finalizar</a></li>
											</ul>
										</div>                                        
									</div>
                    </div>
                    </section>
        </article> 
</asp:Content>
