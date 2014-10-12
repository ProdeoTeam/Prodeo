<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Prodeo.pantallas.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
   
           
    <script type="text/javascript">
        //-------------------------------------------------------------------------------------
        // Creacion de chart ResultadoIntervenciones
        function crearTareasPorUsuario() {
            var datosReporte = AjaxReportes.obtenerTareasPorUsuario();
            var usuarios = [];
            var PendientesVencidas = [];
            var PendientesNoVencidas = [];
            var Finalizadas = [];
            datosReporte = datosReporte.value;
            for (var i = 0; i < datosReporte.length ; i++) {
                var aux = {};
                aux = datosReporte[i];
                usuarios.push(aux.Nombre);
                PendientesVencidas.push(aux.TareasPendientesVencidas);
                PendientesNoVencidas.push(aux.TareasPendientesNoVencidas);
                Finalizadas.push(aux.TareasFinalizadas);
            }
            $('#containerReporte').highcharts({

                chart: {
                    type: 'column',
                    options3d: {
                        enabled: true,
                        alpha: 15,
                        beta: 15,
                        viewDistance: 25,
                        depth: 40
                    },
                    marginTop: 80,
                    marginRight: 40
                },

                title: {
                    text: 'Total de tareas agrupadas por estado'
                },

                xAxis: {
                    categories: usuarios
                },

                yAxis: {
                    allowDecimals: false,
                    min: 0,
                    title: {
                        text: 'Cantidad de Tareas'
                    }
                },

                tooltip: {
                    headerFormat: '<b>{point.key}</b><br>',
                    pointFormat: '<span style="color:{series.color}">\u25CF</span> {series.name}: {point.y} / {point.stackTotal}'
                },

                plotOptions: {
                    column: {
                        stacking: 'normal',
                        depth: 40
                    }
                },

                series: [{
                    name: 'Pendientes',
                    //tiene que tener tantas posiciones como usuarios, cada una indica el valor en cada barras de usuario
                    data: PendientesNoVencidas,
                    stack: 'pend'
                }, {
                    name: 'Pendientes Vencidas',
                    data: PendientesVencidas,
                    stack: 'pend'
                }, {
                    name: 'Finalizadas Vencidas',
                    data: Finalizadas,
                    stack: 'fin'
                }]
            });
        }


        //-------------------------------------------------------------------------------------
        // Creacion de chart Tareas Por Modulo
        function crearTareasPorModulo() {
            var datosReporte = AjaxReportes.obtenerTareasPorModulo();
            var modulos = [];
            var PendientesVencidas = [];
            var PendientesNoVencidas = [];
            var Finalizadas = [];
            datosReporte = datosReporte.value;
            for (var i = 0; i < datosReporte.length ; i++) {
                var aux = {};
                aux = datosReporte[i];
                modulos.push(aux.Nombre);
                PendientesVencidas.push(aux.TareasPendientesVencidas);
                PendientesNoVencidas.push(aux.TareasPendientesNoVencidas);
                Finalizadas.push(aux.TareasFinalizadas);
            }
            $('#containerReporte').highcharts({

                chart: {
                    type: 'column',
                    options3d: {
                        enabled: true,
                        alpha: 15,
                        beta: 15,
                        viewDistance: 25,
                        depth: 40
                    },
                    marginTop: 80,
                    marginRight: 40
                },

                title: {
                    text: 'Total de tareas agrupadas por estado'
                },

                xAxis: {
                    categories: modulos
                },

                yAxis: {
                    allowDecimals: false,
                    min: 0,
                    title: {
                        text: 'Cantidad de Tareas'
                    }
                },

                tooltip: {
                    headerFormat: '<b>{point.key}</b><br>',
                    pointFormat: '<span style="color:{series.color}">\u25CF</span> {series.name}: {point.y} / {point.stackTotal}'
                },

                plotOptions: {
                    column: {
                        stacking: 'percent'
                    }
                },

                series: [{
                    name: 'Pendientes',
                    //tiene que tener tantas posiciones como usuarios, cada una indica el valor en cada barras de usuario
                    data: PendientesNoVencidas
                }, {
                    name: 'Pendientes Vencidas',
                    data: PendientesVencidas
                }, {
                    name: 'Finalizadas Vencidas',
                    data: Finalizadas
                }]
            });
        }

    </script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../js/highcharts.js"></script>
        <script type="text/javascript" src="../js/highcharts-3d.js"></script>
    <script type="text/javascript" src="../js/modules/exporting.js"></script>
    <%--<section id="banner">
        </section>--%>
        <article id="main">
            <section class="wrapper style3 container special">
					
						<header class="major">
							<h2><strong>Sección Reportes</strong></h2>
						</header>
						<div class="row">
                            <input type="button" onclick="crearTareasPorUsuario()" value="Reporte Tareas por usuario"/>
                            <input type="button"  onclick="crearTareasPorModulo()" value="Reporte Tareas por modulo"/>
                            <input type="button" value="Reporte3"/>
                        </div>
						<div class="row">
						<div id="containerReporte" style="width: 400px;">

						</div>

						</div>

						<footer class="major">
							<ul class="buttons">
								<li><a href="#" class="button">Ayuda</a></li>
							</ul>
						</footer>
					
		    </section>
        </article>

</asp:Content>
