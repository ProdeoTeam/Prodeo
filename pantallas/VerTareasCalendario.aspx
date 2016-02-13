<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerTareasCalendario.aspx.cs" Inherits="Prodeo.pantallas.VerTareasCalendario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

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



        function cargarTareas() {
            tareas = oCalendario.obtenerTareas();
            tareas = tareas.value;
            for (var i = 0; i < tareas.length; i++) {
                var unaTarea = [];
                var unEvento = {};
                unaTarea = tareas[i];
                unEvento.title = unaTarea[0];
                unEvento.start = unaTarea[1];
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
