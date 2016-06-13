<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaModulo.aspx.cs" Inherits="Prodeo.AltaModulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
    <link href="../Styles/formulariosInternos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">
    <section class="wrapper style3 container special">
				<div id="formInterno">
						<header class="major">
							<h2><strong><asp:Label ID="LabelModulo" runat="server" Text="Label"></asp:Label></strong></h2>
						</header>
                        <footer>
					            <ul class="buttons">
						            <li id="btnEditarModulo" runat="server"><a class="button" onserverclick="editarModulo_Click" runat="server">Editar Modulo</a></li>
                                    <li id="btnCancelarEdicion" runat="server"><a class="button" onserverclick="cancelarModulo_Click" runat="server">Cancelar Edicion</a></li>
					            </ul>
			            </footer>
									<div class="row half">
										<div class="12u">
											<input type="text" name="nombreModulo" placeholder="Nombre" id="nombreModulo" runat="server">
                                            <asp:RequiredFieldValidator ID="ReqFieldValNombre" Display="Dynamic" ControlToValidate="nombreModulo" ValidationGroup ="valGroupModulos" runat="server" ErrorMessage="Debe ingresarle un nombre al m&oacute;dulo"></asp:RequiredFieldValidator>                                            
										</div>
									</div>
									<div class="row half">
										<div class="12u">
											<textarea name="descripcion" placeholder="Descripcion" rows="7" id="descripcion" runat="server"></textarea>
										</div>
									</div>
                                    <div class="row half no-collapse-1">
                                        <div class="6u">
                                            Fecha Inicio
                                            <input type="date" name="fechaInicio" id="fechaInicio" runat="server">
                                            <asp:CustomValidator ID="CustomValFechActual" Display="Dynamic" ControlToValidate="fechaInicio" ValidationGroup ="valGroupModulos" runat="server" OnServerValidate="validarFechaActual"></asp:CustomValidator>                           
										</div>                                        
									</div>
                                    <div class="row half no-collapse-1">
                                        <div class="6u">
                                            Fecha Vencimiento
                                            <input type="date" name="fechaVencimiento" id="fechaVencimiento" runat="server" placeholder = "DD/MM/AAAA">
                                            <asp:CustomValidator ID="CustomValVencValid" Display="Dynamic" ControlToValidate="fechaVencimiento" ValidationGroup ="valGroupModulos" runat="server" OnServerValidate="validarFechaVenc"></asp:CustomValidator>                          
										</div>                                        
									</div>
                          
									<div class="row">
										<div class="12u">
											<ul class="buttons">
												<li><a class="button special" id="btnAltaModulo" runat="server" onserverclick="altaModuloForm_Click" ValidationGroup ="valGroupModulos">Alta</a></li>
                                                <li><a class="button special" id="btnCancelarModulo" runat="server" onserverclick="cancelarModuloForm_Click">Cancelar</a></li>
                                                <li><a class="button special" id="btnVolverModulo" runat="server" onserverclick="cancelarModuloForm_Click">Volver</a></li>
											</ul>
										</div>
									</div>
                    </div>
                    </section>
        </article>
</asp:Content>
