<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Prodeo.pantallas.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
    <link href="../Styles/formulariosInternos.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">
        <section class="wrapper style3 container special">
		    <div id="formInterno">
				<header class="major">
					<h2 id = "h2Titulo" runat = "server"><strong>Contacto</strong></h2>
				</header>

                <asp:ScriptManager ID="ScriptManagReg" runat="server"></asp:ScriptManager>
				<asp:UpdatePanel ID="UpdatePanelReg" runat="server">
                    <ContentTemplate>
                    
                    <div class="row half">
					    <div class="12u">                            
                            <asp:RequiredFieldValidator ID="ReqFieldValNombre" Display="Dynamic" ControlToValidate="txtNombre" ValidationGroup ="valGroupContacto" runat="server" ErrorMessage="Debe ingresar su nombre"></asp:RequiredFieldValidator>
						    <input type="text" id="txtNombre" name="nombre" runat="server" placeholder="Nombre"/>                            
					    </div>
				    </div>
									                                    
                    <div class="row half">
					    <div class="12u">                            
                            <asp:RequiredFieldValidator ID="ReqFieldValEmail" Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup ="valGroupContacto" runat="server" ErrorMessage="Debe ingresar su email"></asp:RequiredFieldValidator>
						    <asp:RegularExpressionValidator ID="RegExpresValEmail" Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup ="valGroupContacto" runat="server" ErrorMessage="Formato de email inv&aacute;lido" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$"></asp:RegularExpressionValidator>
                            <input type="text" id="txtEmail" name="email" runat="server" placeholder="Email"/>
					    </div>
				    </div>
                                    
				    <div class="row half">
					    <div class="12u">                            
                            <asp:RequiredFieldValidator ID="ReqFieldValAsunto" Display="Dynamic" ControlToValidate="txtAsunto" ValidationGroup ="valGroupContacto" runat="server" ErrorMessage="Debe ingresar el asunto"></asp:RequiredFieldValidator>
						    <input type="text" id="txtAsunto" name="asunto" runat="server" placeholder="Asunto"/>                            
					    </div>
				    </div>

                    <div class="row half">
					    <div class="12u">                            
                            <asp:RequiredFieldValidator ID="ReqFieldValMensaje" Display="Dynamic" ControlToValidate="txtAreaMensaje" ValidationGroup ="valGroupContacto" runat="server" ErrorMessage="Debe ingresar el mensaje"></asp:RequiredFieldValidator>
						    <textarea id="txtAreaMensaje" name="mensaje" runat="server" placeholder="Mensaje" rows="5" cols="20"></textarea>
					    </div>
				    </div>
                    
                    <div class="row" ID="contenBtnEnviar" runat="server">
					    <div class="12u">
						    <ul class="buttons">							    
						        <li><asp:Button CssClass="button special" ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" ValidationGroup ="valGroupContacto"></asp:Button></li>
                            </ul>
					    </div>
				    </div>                        
                    
                    <div class="row">
					    <div class="12u" id="divEstadoMail">
						    <asp:Label ID="lblEstadoOperacion" runat="server" Text=""></asp:Label>                            
					    </div>
				    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </section>
    </article> 
</asp:Content>