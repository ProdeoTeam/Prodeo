<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerTareasCalendario.aspx.cs" Inherits="Prodeo.pantallas.VerTareasCalendario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Styles/fullcalendar.css" rel="stylesheet" />
    <link href="../Styles/fullcalendar.print.css" rel="stylesheet" />
    <script type="text/javascript" src='../js/moment.min.js'></script>
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.js"></script>
    
    <script type="text/javascript"  src="../js/fullcalendar.min.js"></script>
    <script type="text/javascript" src="../js/lang-all.js"></script>
    <script type="text/javascript">
        var tareas = [];
        var eventos = [];
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

        function cargarTareas() {
            var idModulo = getUrlParameter('idModulo'); //1015
            var idProy = getUrlParameter('idProyecto'); //1026
            tareas = AjaxReportes.obtenerTareasCalendario(idProy,idModulo);
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
            $('#calendar').fullCalendar({
                defaultDate: hoy,
                lang: 'es',
                editable: false,
                eventLimit: true, // allow "more" link when too many events
                events: eventos
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="calendar" style="background-color: white" runat="server">
            </div>

        </div>
    </form>
</body>
</html>
