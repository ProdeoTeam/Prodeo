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
        function agregarUsuario() {
            var e = document.getElementById("MainContent_selectPermisos");
            var permiso = e.options[e.selectedIndex].value;
            var mail = document.getElementById("MainContent_txtUsuarioAjax").value;
            //Prodeo.pantallas.AltaProyecto.agregarUsuario_asp(mail, permiso);
            var fila = Prodeo.pantallas.AltaProyecto.agregarUsuario_html(mail, permiso);
            var tabla = document.getElementById("MainContent_tablaUsuariosGrilla");
            tabla.innerHTML += fila.value;
        }

        //function agregarUsuario(mail,permiso) {
        //    var fila = Prodeo.pantallas.AltaProyecto.agregarUsuario_html(mail, permiso);
        //    var tabla = document.getElementById("MainContent_tablaUsuariosGrilla");
        //    tabla.innerHTML += fila.value;
        //}

        function quitarUsuario(idFila) {
            //Prodeo.pantallas.AltaProyecto.agregarUsuario_asp(mail, permiso);

            var fila = document.getElementById(idFila);
            var mail = fila.cells[0].innerText;
            var tabla = fila.parentNode;
            tabla.removeChild(fila);
            Prodeo.pantallas.AltaProyecto.quitarUsuario_html(mail);

        }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <article id="main">
    <section class="wrapper style3 container special">
				<div id="formInterno">
						<header class="major">
							<h2><strong><asp:Label ID="LabelProyectos" runat="server" Text="Label"></asp:Label></strong></h2>
						</header>
                        <footer>
					            <ul class="buttons">
						            <li id="btnEditarProyecto" runat="server"><a class="button" onserverclick="editarProyecto_Click" runat="server">Editar Proyecto</a></li>
                                    <li id="btnCancelarEdicion" runat="server"><a class="button" onserverclick="cancelarProyecto_Click" runat="server">Cancelar Edicion</a></li>
                                    <li id="btnEliminarProyecto" runat="server"><a class="button" onserverclick="eliminarProyecto_Click" runat="server">Eliminar Proyecto</a></li>
					            </ul>
			            </footer>
									<div class="row half">
										<div class="12u">
											<input type="text" name="nombreProyecto" placeholder="Nombre" id="nombreProyecto" runat="server">
                                            <asp:RequiredFieldValidator ID="ReqFieldValNombre" Display="Dynamic" ControlToValidate="nombreProyecto" ValidationGroup ="valGroupProyectos" runat="server" ErrorMessage="Debe ingresarle un nombre al proyecto"></asp:RequiredFieldValidator>
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
                                            <input type="date" name="fechaVencimiento" id="fechaVencimiento" runat="server"/>  
                                            <asp:RequiredFieldValidator ID="ReqFieldValFechaVencimiento" Display="Dynamic" ControlToValidate="fechaVencimiento" ValidationGroup ="valGroupProyectos" runat="server" ErrorMessage="Debe ingresarle una fecha de vencimiento"></asp:RequiredFieldValidator>                                          
                                            <asp:CustomValidator ID="CustomValFechActual" Display="Dynamic" ControlToValidate="fechaVencimiento" ValidationGroup ="valGroupProyectos" runat="server" OnServerValidate="validarFechaActual"></asp:CustomValidator>
                            
										</div>
										<div class="6u">
                                            &nbsp;
                                            Seleccione Avisos
                                            <select name="avisoVencimientos" id="avisoVencimientos" runat="server">                                              
                                              <option value="h-0">Nunca</option>
                                              <option value="h-1">1 hora antes</option>
                                              <option value="d-1">1 dia antes</option>
                                              <option value="d-2">2 dias antes</option>
                                              <option value="d-7">1 semana antes</option>
                                              <option value="m-1">1 mes antes</option>
                                            </select>
										</div>
                                        
									</div>
                                    <div class="row half">
										<div class="12u">
                                            <div runat="server" id="divTablaUsuarios">
                                                
                                                <input type="text" id="txtUsuarioAjax" runat="server"/>
                                                    <select id="selectPermisos" runat="server">
                                                        <option value="A">Administrador</option>
                                                        <option value="C">Colaborador</option>
                                                    </select>
                                               <input id="btnAgregarUsuario" onclick="agregarUsuario()" type="button" value="Agregar Usuario" runat="server" />
                                                
                                                <table runat="server" id="tablaUsuariosGrilla">
                                                    <tr>
                                                        <td>
                                                            Usuario
                                                        </td>
                                                        <td>
                                                            Permisos
                                                        </td>
                                                        <td>
                                                            #
                                                        </td>
                                                    </tr>
                                                </table>
										</div>
                                            <div class="row">
										<div class="12u">
											<ul class="buttons">
												<li><a class="button special" id="btnAltaProyecto" runat="server" onserverclick="altaProyForm_Click" ValidationGroup = "valGroupProyectos">Alta</a></li>
                                                <li><a class="button special" id="btnActualizaProyecto" runat="server" onserverclick="actualizaProyForm_Click">Guardar</a></li>
                                                <li><a class="button special" id="btnCancelarProyecto" runat="server" onserverclick="cancelarProyForm_Click">Cancelar</a></li>
                                                <li><a class="button special" id="btnVolverProyecto" runat="server" onserverclick="cancelarProyForm_Click">Volver</a></li>
											</ul>
										</div>
									</div>
									</div>
                                        
									
                    </div>
                    </section>
        </article>

</asp:Content>