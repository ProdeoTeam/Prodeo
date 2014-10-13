<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaProyecto.aspx.cs" Inherits="Prodeo.pantallas.AltaProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script src="<%= ResolveClientUrl("~/js/initPages.js")%>" type="text/javascript"></script>
    <link href="../Styles/formulariosInternos.css" rel="stylesheet" />
    <style type="text/css">
 
#tabla{	border: solid 1px #333;	width: 100%; }
#tabla tbody tr{ background: #ffffff; }
.fila-base{ display: none; } /* fila base oculta */
.eliminar{ cursor: pointer; color: #000; }
input[type="text"]{ width: 100px; } /* ancho a los elementos input="text" */
 
</style>
    <script type="text/javascript">
        var x = 0;
        $(function () {
            // Clona la fila oculta que tiene los campos base, y la agrega al final de la tabla
            $("#agregar").on('click', function () {
                $("#tabla tbody tr:eq(0)").clone().removeClass('fila-base').appendTo("#tabla tbody");
                //$(".nombre").attr("id", "usuarioMail" + x); 
                //$(".permiso").attr("id", "permisoUsuario" + x);
                //$("#usuarioMail" + x).removeClass("nombre");
                //$("#usuarioMail" + x).attr("class", "nombre" + x);
                //$("#permisoUsuario" + x).removeClass("permiso");
                //$("#permisoUsuario" + x).attr("class", "permiso" + x);
                //x++;
            });

            // Evento que selecciona la fila y la elimina 
            $(document).on("click", ".eliminar", function () {
                var parent = $(this).parents().get(0);
                $(parent).remove();
            });
        });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">
    <section class="wrapper style3 container special">
				<div id="formInterno">
						<header class="major">
							<h2><strong>Alta de Proyecto</strong></h2>
						</header>
									<div class="row half">
										<div class="12u">
											<input type="text" name="nombreProyecto" placeholder="Nombre" id="nombreProyecto" runat="server">
										</div>
									</div>
									<div class="row half">
										<div class="12u">
											<textarea name="descripcion" placeholder="Descripcion" rows="7" id="descripcion" runat="server"></textarea>
										</div>
									</div>
                                    <div class="row half no-collapse-1">
                                        <div class="6u">
                                            Fecha Vencimiento
                                            <input type="date" name="fechaVencimiento" id="fechaVencimiento" runat="server">
										</div>
										<div class="6u">
                                            &nbsp;
                                            <select name="avisoVencimientos" id="avisoVencimientos" runat="server">
                                              <option value="seleccione" selected>Seleccione avisos</option>
                                              <option value="h-0">Nunca</option>
                                              <option value="h-1">1 hora antes</option>
                                              <option value="d-1">1 dia antes</option>
                                              <option value="d-2">2 dias antes</option>
                                              <option value="d-7">1 semana antes</option>
                                              <option value="m-1">1 mes antes</option>
                                            </select>
										</div>
                                        
									</div>
                                    <%--<div class="row half no-collapse-1">
                                        <div class="6u">
                                            Usuario <asp:Label ID="errorUser" runat="server" Text="" ForeColor="Red"></asp:Label>
                                            <input type="text" name="usuarioMail" id="usuarioMail" runat="server">
										</div>
										<div class="6u">
                                            &nbsp;
                                            <select name="permisoUsuario" id="permisoUsuario" runat="server">
                                              <option value="seleccione" selected>Seleccione un permiso</option>
                                              <option value="A">Admisnistrador</option>
                                              <option value="C">Colaborador</option>
                                            </select>
										</div>
                                        
									</div>--%>
                                    <div class="row half">
										<div class="12u">
											<table id="tabla">
	                                            <!-- Cabecera de la tabla -->
	                                            <thead>
		                                            <tr>
			                                            <th>Email</th>
			                                            <th>Permiso</th>
			                                            <th>&nbsp;</th>
		                                            </tr>
	                                            </thead>
 
	                                            <!-- Cuerpo de la tabla con los campos -->
	                                            <tbody>
 
		                                            <!-- fila base para clonar y agregar al final -->
		                                            <tr class="fila-base">
			                                            <td><input type="text" class="nombre" runat="server"/></td>
			                                            <td>
				                                            <select name="permisoUsuario" class="permiso" runat="server">
                                                              <option value="seleccione" selected>Seleccione un permiso</option>
                                                              <option value="A">Admisnistrador</option>
                                                              <option value="C">Colaborador</option>
                                                            </select>
			                                            </td>
			                                            <td class="eliminar">Eliminar</td>
		                                            </tr>
		                                            <!-- fin de código: fila base -->
 
		                                            <!-- Fila de ejemplo -->
		                                            <%--<tr>
			                                            <td><input type="text" class="nombre" id="usuarioMail" /></td>
			                                            <td>
				                                            <select name="permisoUsuario" id="Select2" runat="server">
                                                              <option value="seleccione" selected>Seleccione un permiso</option>
                                                              <option value="A">Admisnistrador</option>
                                                              <option value="C">Colaborador</option>
                                                            </select>
			                                            </td>
			                                            <td class="eliminar">Eliminar</td>
		                                            </tr>--%>
		                                            <!-- fin de código: fila de ejemplo -->
 
	                                            </tbody>
                                            </table>
										</div>
									</div>
                                    <div class="row half no-collapse-1">
                                        <div class="6u">
                                            <ul class="buttons">
												<%--<li><a class="button special" id="agregar" value="Agregar fila" runat="server">Agregar usuario</a></li>--%>
                                                <input type="button" id="agregar" value="Agregar fila" />
											</ul>
										</div>
									</div>
									<div class="row">
										<div class="12u">
											<ul class="buttons">
												<li><a class="button special" id="btnAltaProyecto" runat="server" onserverclick="altaProyForm_Click">Alta</a></li>
											</ul>
										</div>
									</div>
                    </div>
                    </section>
        </article> 

</asp:Content>
