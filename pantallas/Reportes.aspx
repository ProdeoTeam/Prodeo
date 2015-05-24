<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Prodeo.pantallas.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
   
           
    <script type="text/javascript">
        //-------------------------------------------------------------------------------------
        // Creacion de chart ResultadoIntervenciones
        function crearTareasPorUsuario() {
            var ddlProyecto = document.getElementById("MainContent_proyectosLista");
            var idProyecto = ddlProyecto.options[ddlProyecto.selectedIndex].value;
            var datosReporte = AjaxReportes.obtenerTareasPorUsuario(idProyecto);

            datosReporte = datosReporte.value;

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
                    categories: datosReporte.Categorias
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
                    name: datosReporte.Series[0].Nombre,
                    //tiene que tener tantas posiciones como usuarios, cada una indica el valor en cada barras de usuario
                    data: datosReporte.Series[0].Datos,
                    stack: datosReporte.Series[0].Stack
                }, {
                    name: datosReporte.Series[1].Nombre,
                    //tiene que tener tantas posiciones como usuarios, cada una indica el valor en cada barras de usuario
                    data: datosReporte.Series[1].Datos,
                    stack: datosReporte.Series[1].Stack
                }, {
                    name: datosReporte.Series[2].Nombre,
                    //tiene que tener tantas posiciones como usuarios, cada una indica el valor en cada barras de usuario
                    data: datosReporte.Series[2].Datos,
                    stack: datosReporte.Series[2].Stack
                }]
            });
        }


        //-------------------------------------------------------------------------------------
        // Creacion de chart Tareas Por Modulo
        function crearTareasPorModulo() {
            var ddlProyecto = document.getElementById("MainContent_proyectosLista");
            var idProyecto = ddlProyecto.options[ddlProyecto.selectedIndex].value;
            var datosReporte = AjaxReportes.obtenerTareasPorModulos(idProyecto);

            datosReporte = datosReporte.value;

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
                    categories: datosReporte.Categorias
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
                    name: datosReporte.Series[0].Nombre,
                    //tiene que tener tantas posiciones como usuarios, cada una indica el valor en cada barras de usuario
                    data: datosReporte.Series[0].Datos,
                    stack: datosReporte.Series[0].Stack
                }, {
                    name: datosReporte.Series[1].Nombre,
                    //tiene que tener tantas posiciones como usuarios, cada una indica el valor en cada barras de usuario
                    data: datosReporte.Series[1].Datos,
                    stack: datosReporte.Series[1].Stack
                }, {
                    name: datosReporte.Series[2].Nombre,
                    //tiene que tener tantas posiciones como usuarios, cada una indica el valor en cada barras de usuario
                    data: datosReporte.Series[2].Datos,
                    stack: datosReporte.Series[2].Stack
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
                        <ul class="buttons">
						    
                            <li><select name="proyectosLista" id="proyectosLista" runat="server">
                                              <option value="seleccione" selected>Seleccione Proyecto</option>
                                              
                                            </select></li>
                            <li><a href="#" class="button" onclick="crearTareasPorUsuario()" runat="server">Reporte Tareas por usuario</a></li>
						    <li><a href="#" class="button" onclick="crearTareasPorModulo()" runat="server">Reporte Tareas por modulo</a></li>
                            <li><a href="#" class="button" runat="server">Reporte3</a></li>
					    </ul>
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
