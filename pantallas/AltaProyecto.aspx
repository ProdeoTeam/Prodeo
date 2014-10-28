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
											<asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" ShowFooter="True">
                                                <Columns>
                                                    <asp:BoundField DataField="RowNumber" HeaderText="Nro" ReadOnly="True" SortExpression="RowNumber"></asp:BoundField>
                                                    <asp:TemplateField HeaderText="Usuario">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtAddUser" runat="server" MaxLength="50"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Email">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtUserMail" runat="server" MaxLength="50"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Permisos">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlPermisos" runat="server">
                                                                <asp:ListItem>Seleccione</asp:ListItem>
                                                                <asp:ListItem Value="A">Administrador</asp:ListItem>
                                                                <asp:ListItem Value="C">Colaborador</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <FooterTemplate>
                                                            <asp:Button ID="btnAgregarUsuario" runat="server" Text="Nuevo usuario" OnClick="btnAgregarUsuario_Click" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowDeleteButton="True" />
                                                </Columns>
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#EFF3FB" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
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
