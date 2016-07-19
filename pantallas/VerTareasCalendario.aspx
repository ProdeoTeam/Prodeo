<%@ Page Title="" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="VerTareasCalendario.aspx.cs" Inherits="Prodeo.pantallas.VerTareasCalendario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent2" runat="server">
    <script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
    <link href="../Styles/formulariosInternos.css" rel="stylesheet" />
    <link rel='stylesheet' href='../Styles/jquery-ui.min.css' />
    <link href='../Styles/fullcalendar.css' rel='stylesheet' />
    <link href='../Styles/fullcalendar.print.css' rel='stylesheet' media='print' />
    <script type="text/javascript" src='../js/moment.min.js'></script>
    <!--
        -->
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>    
    
    <script type="text/javascript" src="../js/fullcalendar.min.js"></script>
    <script type="text/javascript" src="../js/lang-all.js"></script>
        <script type="text/javascript">
            var tareas = [];
            var eventos = [];
            var eventosActualizados = [];
            var hoy;
            function obtenerFechaHoy() {
                var today = new Date();
                var dd = today.getDate();
                var mm = today.getMonth() + 1;
                var yyyy = today.getFullYear();
                if (mm < 10) {
                    mm = '0' + mm
                }
                if (dd < 10) {
                    dd = '0' + dd
                }
                hoy = yyyy + '-' + mm + '-' + dd;
                return hoy;

            }

            function getUrlParameter(sParam) {
                var sPageURL = decodeURIComponent(window.location.search.substring(1)),
                    sURLVariables = sPageURL.split('&'),
                    sParameterName,
                    i;

                for (i = 0; i < sURLVariables.length; i++) {
                    sParameterName = sURLVariables[i].split('=');

                    if (sParameterName[0] === sParam) {
                        return sParameterName[1] === undefined ? true : sParameterName[1];
                    }
                }
            };
            function GuardarModificaciones() {
                if (eventosActualizados.length > 0) {
                    var rta = AjaxReportes.ActualizarFechasTarea(eventosActualizados);
                    if (rta) {
                        eventosActualizados = [];
                        alert("Se actualizaron con exito las fechas");
                    } else {
                        alert("No se pudieron actualizar las fechas");
                    }
                }
            }
            function cargarTareas() {
                var idModulo = getUrlParameter('idModulo'); //1015
                var idProy = getUrlParameter('idProyecto'); //1026
                tareas = AjaxReportes.obtenerTareasCalendario(idProy, idModulo);
                tareas = tareas.value;
                for (var i = 0; i < tareas.length; i++) {
                    var unEvento = {};
                    unEvento = tareas[i];
                    eventos.push(unEvento);
                }
            }

            $(document).ready(function () {
                cargarTareas();
                obtenerFechaHoy();
                $('#MainContent_calendar').fullCalendar({
                    theme: true,
                    defaultDate: hoy,
                    lang: 'es',
                    allDay: false,
                    editable: true,
                    eventLimit: true, // allow "more" link when too many events
                    events: eventos,
                    eventDrop: function (event, delta, revertFunc, jsEvent, ui, view) {
                        var estaEnArrayActualizado = false;
                        var desde = event.start.format('DD/MM/YYYY');
                        var fin = event.end.format('DD/MM/YYYY');
                        for (var i = 0; i < eventosActualizados.length; i++) {
                            if (eventosActualizados[i][0] == event.idTarea) {
                                estaEnArrayActualizado = true;
                                eventosActualizados[i][1] = desde;
                                eventosActualizados[i][2] = fin;
                            }
                        }
                        if (!estaEnArrayActualizado) {
                            var nuevoEvento = [];
                            nuevoEvento.push(event.idTarea);
                            //nuevoEvento.push(event.start);
                            //nuevoEvento.push(event.end);
                            nuevoEvento.push(desde);
                            nuevoEvento.push(fin);
                            eventosActualizados.push(nuevoEvento);
                        }
                    }
                });

            });
    </script>
    <style>
        body {
            margin: 40px 10px;
            padding: 0;
            font-family: "Lucida Grande",Helvetica,Arial,Verdana,sans-serif;
            font-size: 14px;
        }

        #calendar {
            max-width: 900px;
            margin: 0 auto;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <article id="main">
        <section class="wrapper style3 container special">
                    <div id="calendar" runat="server">
                    </div>
            
            <div style="width: 100%; text-align: center;">
                <input type="button" style="text-align: center; margin: 0 auto;" onclick="GuardarModificaciones()" value="Guardar Modificaciones" />
            </div>
       </section>
    </article>
</asp:Content>
