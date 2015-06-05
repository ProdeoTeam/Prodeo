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
    <article id="main">
            <section class="wrapper style3 container special" id="proyectosLista" runat="server">
				<h2>Lista de Proyectos:</h2>
                <div style="text-align:left;padding-left:20px;padding-bottom:20px;">
                    Buscar 
                    <input id="txtFiltro" type="text" onkeyup="filtrarProyecto(document.getElementById('txtFiltro').value)" />
                    <input type="button" value="Ir" onclick="filtrarProyecto(document.getElementById('txtFiltro').value)"/>  

                </div>

            </section>
    </article> 

</asp:Content>
