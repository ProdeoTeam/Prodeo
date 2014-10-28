<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerificarEmail.aspx.cs" Inherits="Prodeo.pantallas.VerificarEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <article id="main">
        <section class="wrapper style3 container special">					
			<header class="major">
				<h2><strong>Verificaci&oacute;n de email</strong></h2>
			</header>
                    						
			<hr></hr>																	

            <asp:Label ID="lblMensaje" runat="server" Text="Pagina de verificacion de email"></asp:Label>
            <asp:LinkButton ID="linkIndex" runat="server" PostBackUrl="~/index.aspx">Ir al inicio</asp:LinkButton>
		</section>
    </article> 

</asp:Content>
