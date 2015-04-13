<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Prodeo.pantallas.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
    <link href="../Styles/formulariosInternos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">
        <section class="wrapper style3 container special">
		    <div id="formInterno">
				<header class="major">
					<h2 id = "h2Titulo" runat = "server"><strong>Registro</strong></h2>
				</header>

                <asp:ScriptManager ID="ScriptManagReg" runat="server"></asp:ScriptManager>
				<asp:UpdatePanel ID="UpdatePanelReg" runat="server">
                    <ContentTemplate>
                    
                    <div class="row half">
					    <div class="12u">
                            <asp:CustomValidator ID="CustomValUsuarioRep" Display="Dynamic" ControlToValidate="txtUsuario" ValidationGroup ="valGroupRegistro" runat="server" ErrorMessage="Ya existe un usuario registrado con ese nombre" OnServerValidate="validarUsuarioRep"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="ReqFieldValUsuario" Display="Dynamic" ControlToValidate="txtUsuario" ValidationGroup ="valGroupRegistro" runat="server" ErrorMessage="Debe ingresar un nombre de usuario"></asp:RequiredFieldValidator>
						    <input type="text" id="txtUsuario" name="usuario" runat="server" placeholder="Usuario"/>                            
					    </div>
				    </div>
									
                    <div class="row half">
					    <div class="12u">
                            <asp:RequiredFieldValidator ID="ReqFieldValPass_Reg" Display="Dynamic" ControlToValidate="txtPass" ValidationGroup ="valGroupRegistro" runat="server" ErrorMessage="Debe ingresar una contrase&ntilde;a"></asp:RequiredFieldValidator>                            
						    <input type="password" id="txtPass" name="pass" runat="server" placeholder="Contrase&ntilde;a"/>
					    </div>
				    </div>
                                    
                    <div class="row half">
					    <div class="12u">
                            <asp:RequiredFieldValidator ID="ReqFieldValRepPass_Reg" Display="Dynamic" ControlToValidate="txtRepetirPass" ValidationGroup ="valGroupRegistro" runat="server" ErrorMessage="Debe repetir la contrase&ntilde;a"></asp:RequiredFieldValidator>
						    <asp:CompareValidator ID="CompareValPass_Reg" Display="Dynamic" ControlToCompare="txtPass" ControlToValidate="txtRepetirPass" ValidationGroup ="valGroupRegistro" runat="server"  ErrorMessage="Las contrase&ntilde;as no coinciden"></asp:CompareValidator>                                                        
                            <input type="password" id="txtRepetirPass" name="repetirPass" runat="server" placeholder="Repetir Contrase&ntilde;a"/>
					    </div>
				    </div>
                                    
                    <div class="row half">
					    <div class="12u">
                            <asp:CustomValidator ID="CustomValEmailRep" Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup ="valGroupRegistro" runat="server" ErrorMessage="Ya existe un usuario registrado con ese email" OnServerValidate="validarEmailRep"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="ReqFieldValEmail" Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup ="valGroupRegistro" runat="server" ErrorMessage="Debe ingresar un email"></asp:RequiredFieldValidator>
						    <asp:RegularExpressionValidator ID="RegExpresValEmail" Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup ="valGroupRegistro" runat="server" ErrorMessage="Formato de email inv&aacute;lido" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$"></asp:RegularExpressionValidator>
                            <input type="text" id="txtEmail" name="email" runat="server" placeholder="Email"/>
					    </div>
				    </div>
                                    
				    <div class="row" ID="contenBtnReg" runat="server">
					    <div class="12u">
						    <ul class="buttons">
                                <li><asp:Button CssClass="button special" ID="btnRegistro" runat="server" Text="Registrarse" OnClick="registroForm_Click" ValidationGroup ="valGroupRegistro"></asp:Button></li>
							    <%--<li><a class="button special" id="btnRegistro" runat="server" onserverclick="registroForm_Click">Registrarse</a></li>--%>
						    </ul>
					    </div>
				    </div>

                    <div class="row" ID="contenBtnModif" runat="server">
					    <div class="12u">
						    <ul class="buttons">
							    <%--<li><a class="button special" id="btnModifDatos" runat="server" onserverclick="modifDatos_Click">Modificar</a></li> --%>
						        <li><asp:Button CssClass="button special" ID="btnModifDatos" runat="server" Text="Modificar" OnClick="modifDatos_Click" ValidationGroup ="valGroupRegistro"></asp:Button></li>
                            </ul>
					    </div>
				    </div>

                    <div class="row">
					    <div class="12u" id="divEstadoMail">
						    <asp:Label ID="lblEstadoOperacion" runat="server" Text=""></asp:Label>
                            <!--<ul class="buttons">
							    <li><a class="button special" id="btnEstadoMail" runat="server">Aceptar</a></li>                            
						    </ul>-->
					    </div>
				    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </section>
    </article> 
</asp:Content>