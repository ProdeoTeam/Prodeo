<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaProyectos.aspx.cs" Inherits="Prodeo.pantallas.ListaProyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
    <link href="../Styles/formulariosInternos.css" rel="stylesheet" />
    <script type="text/javascript">
        function filtrarProyecto(filtro) {
            //Article
            var contentSection = document.getElementById("main"); //Obtengo una referencia al "section"
            //Recorremos los section

            filtro = filtro.toUpperCase();
            for (var i = 5; i < contentSection.childNodes[1].childNodes.length ; i = i + 2) { //Gracias a contentSection.ELEMENTS debería recorrer todos los "article" que hay dentro del "section"
                // main ; Section-ProyectosLista ; section-vistaProyecto ; elemento-h2 ; innerText             // main ; Section-ProyectosLista ; section-vistaProyecto ; elemento-h3 ; innerText
                if (contentSection.childNodes[1].childNodes[i].childNodes[0].innerText.toUpperCase().indexOf(filtro) < 0 && contentSection.childNodes[1].childNodes[i].childNodes[1].innerText.toUpperCase().indexOf(filtro) < 0) {
                    contentSection.childNodes[1].childNodes[i].style.display = 'none'; //Si no es el que quiero mostrar, lo oculto cancelando su display
                }
                else {
                    contentSection.childNodes[1].childNodes[i].style.display = 'block'; //Si es el que quiero mostrar lo muestro cambiando el display
                }
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--Script para dar formato al boton de Twitter--%>
    <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script> 
    <%--Script para dar formato al boton de Facebook--%>
    <div id="fb-root"></div>
    <script>(function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/es_LA/sdk.js#xfbml=1&version=v2.0";
        fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));</script>
    <%------------------------------------------------%>
    <article id="main">
            <section class="wrapper style3 container special" id="proyectosLista" runat="server">
				<h2>Lista de Proyectos:</h2>
                <div style="text-align:left;padding-left:20px;padding-bottom:20px;">
                    Buscar 
                    <input id="txtFiltro" type="text" onkeyup="filtrarProyecto(document.getElementById('txtFiltro').value)" />
                    <input type="button" value="Ir" onclick="filtrarProyecto(document.getElementById('txtFiltro').value)"/>  
                    <div id="divRedesSoc">
                        <%--Boton de Facebook--%> 
                        <div id="divBtnFacebook">
                            <a 
                                class="fb-share-button" 
                                data-href="https://www.facebook.com/pages/Prodeo/1567642463469507?ref=hl"
                                data-layout="button">
                            </a>
                        </div>
                        <%--------------------%>
                    
                        <%--Boton de Twitter--%>
                        <div id="divBtnTwitter">
                            <a href="https://twitter.com/share" 
                                class="twitter-share-button"
                                data-url="http://localhost:8090/index.aspx" 
                                data-text="Yo manejo mis proyectos en Prodeo, vos podes crear los tuyos!" 
                                data-via="ProyectosProdeo" 
                                data-lang="es" 
                                data-size="small" 
                                data-related="ProyectosProdeo" 
                                data-hashtags="gestion,proyectos"
                                data-count="none">Twittear
                            </a> 
                        </div>                   
                    </div>
                </div>                
            </section>
    </article> 
</asp:Content>
