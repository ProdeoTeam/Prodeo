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
					<h2><strong>Registro</strong></h2>
				</header>

                <asp:ScriptManager ID="ScriptManagReg" runat="server"></asp:ScriptManager>
				<asp:UpdatePanel ID="UpdatePanelReg" runat="server">
                    <ContentTemplate>
                    
                    <div class="row half">
					    <div class="12u">
                            <asp:CustomValidator ID="CustomValUsuarioRep" Display="Dynamic" ControlToValidate="usuario" runat="server" ErrorMessage="Ya existe un usuario registrado con ese nombre" OnServerValidate="validarUsuarioRep"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="ReqFieldValUsuario" Display="Dynamic" ControlToValidate="usuario" runat="server" ErrorMessage="Debe ingresar un nombre de usuario"></asp:RequiredFieldValidator>
						    <input type="text" id="usuario" name="usuario" runat="server" placeholder="Usuario">                            
					    </div>
				    </div>
									
                    <div class="row half">
					    <div class="12u">
                            <asp:RequiredFieldValidator ID="ReqFieldValPass" Display="Dynamic" ControlToValidate="pass" runat="server" ErrorMessage="Debe ingresar una contrase&ntilde;a"></asp:RequiredFieldValidator>
						    <input type="password" id="pass" name="pass" runat="server" placeholder="Contrase&ntilde;a">
					    </div>
				    </div>
                                    
                    <div class="row half">
					    <div class="12u">
                            <asp:RequiredFieldValidator ID="ReqFieldValRepPass" Display="Dynamic" ControlToValidate="repetirPass" runat="server" ErrorMessage="Debe repetir la contrase&ntilde;a"></asp:RequiredFieldValidator>
						    <asp:CompareValidator ID="CompareValPass" Display="Dynamic" ControlToCompare="pass" ControlToValidate="repetirPass" runat="server" ErrorMessage="Las contrase&ntilde;as no coinciden"></asp:CompareValidator>
                            <input type="password" id="repetirPass" name="repetirPass" runat="server" placeholder="Repetir Contrase&ntilde;a">
					    </div>
				    </div>
                                    
                    <div class="row half">
					    <div class="12u">
                            <asp:CustomValidator ID="CustomValEmailRep" Display="Dynamic" ControlToValidate="email" runat="server" ErrorMessage="Ya existe un usuario registrado con ese email" OnServerValidate="validarEmailRep"></asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="ReqFieldValEmail" Display="Dynamic" ControlToValidate="email" runat="server" ErrorMessage="Debe ingresar un email"></asp:RequiredFieldValidator>
						    <asp:RegularExpressionValidator ID="RegExpresValEmail" Display="Dynamic" ControlToValidate="email" runat="server" ErrorMessage="Formato de email inv&aacute;lido" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$"></asp:RegularExpressionValidator>
                            <input type="text" id="email" name="email" runat="server" placeholder="Email">
					    </div>
				    </div>
                                    
				    <div class="row">
					    <div class="12u">
						    <ul class="buttons">
							    <li><a class="button special" id="btnRegistro" runat="server" onserverclick="registroForm_Click">Registrarse</a></li>                            
						    </ul>
					    </div>
				    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </section>
    </article> 
</asp:Content>


