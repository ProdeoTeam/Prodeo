<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Prodeo.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="<%= ResolveClientUrl("~/js/init.js")%>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<!-- Banner -->		
			<section id="banner">				
				<!--
					".inner" is set up as an inline-block so it automatically expands
					in both directions to fit whatever's inside it. This means it won't
					automatically wrap lines, so be sure to use line breaks where
					appropriate (<br />).
				-->
				<div class="inner">					
					<header>
                        <img src="images/logos/ProdeoLogoNombre.gif" />
					</header>
					<p>Gestione sus <b>Proyectos</b><br />
					de manera f&aacute;cil e<br />
					intuitiva</p>
					<footer>
						<ul class="buttons vertical">
							<li><a href="#main" class="button fit scrolly">Caracter&iacute;sticas</a></li>
						</ul>
					</footer>				
				</div>				
			</section>
		                 

		<!-- Main -->
			<article id="main">

				<header class="special container">
					<span class="icon fa-bar-chart-o"></span>
					<h2>¿Necesita llevar un orden en sus <b>Proyectos</b> y no sabe c&oacute;mo?<br />
					En este peque&ntilde;o instructivo le contamos...</h2>
					<p><strong>Prodeo</strong> est&aacute; orientado a empresas con grupos que trabajen a distancia<br />
					y que quieran administrar sus actividades de forma ordenada, evitando retrasos, 
					solapamientos de tareas<br /> y problemas de comunicaci&oacute;n.<br />
					Tambi&eacute;n puede ser utilizado por particulares que quieran tener organizadas<br />
                        sus actividades a lo largo de la semana.
					</p>
				</header>

                <!-- CTA -->
			<section id="cta">
			
				<header>
					<h2>¿Desea recibir nuestro <strong>Newsletter</strong>?</h2>
					<p>¡Ingrese sus datos y le llegar&aacute;n nuestras novedades!</p>
				</header>
				<footer>
					<!-- Content -->
							<div id="contentNewsletter">
								<form>
									<div class="row 50%">
										<div class="6u 12u(mobile)">
											<input type="text" id="txtName" name="name" runat="server" placeholder="Nombre"  />
										</div>
										<div class="6u 12u(mobile)">
											<input type="email" id="txtEmail" name="email" runat="server" placeholder="Email" />
										</div>
									</div>
									<div class="row" ID="contenBtnEnviar" runat="server">
					    <div class="12u">
						    <ul class="buttons">							    
						        <li><asp:Button CssClass="special" ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" ValidationGroup ="valGroupContacto"></asp:Button></li>
                            </ul>
					    </div>
				    </div>
								</form>
							</div>

				</footer>
			
			</section>
					
				<!-- One -->
					<section class="wrapper style2 container special-alt">
						<div class="row half">
							<div class="8u">
							
								<header>
                                    
									<h2>Mantenga su proyecto controlado administrando los tiempos, recursos y personal.</h2>
								</header>
								<ul>
                                    <li>No necesita ingresar todo el tiempo para verificar si hay nuevos cambios, Prodeo le enviar&aacute; notificaciones por mail.</li>
                                    <li>Invite a usuarios a su proyecto y defina si van a ser Administradores junto a usted, o Colaboradores si no es necesario que editen y creen contenido.</li>
                                    <li>Todo el sitio est&aacute; &iacute;ntegramente desarrollado en espa&ntilde;ol. La navegaci&oacute;n es sencilla y con opciones claras.</li>
								</ul>
                                <iframe id="tutorial" width="640" height="360" src="https://www.youtube.com/embed/_NLZvDWKpA8?controls=0&rel=0&showinfo=0" frameborder="0" allowfullscreen></iframe>                                
								<footer>
									<ul class="buttons">
										<li><a href="#section2" class="button fit scrolly">M&aacute;s Caracter&iacute;sticas</a></li>
									</ul>
								</footer>
							
							</div>
							<div class="4u skel-cell-important">
							
								<ul class="feature-icons">
									<li><span class="icon fa-clock-o"><span class="label">Feature 1</span></span></li>
									<li><span class="icon fa-volume-up"><span class="label">Feature 2</span></span></li>
									<li><span class="icon fa-laptop"><span class="label">Feature 3</span></span></li>
									<li><span class="icon fa-inbox"><span class="label">Feature 4</span></span></li>
									<li><span class="icon fa-lock"><span class="label">Feature 5</span></span></li>
									<li><span class="icon fa-cog"><span class="label">Feature 6</span></span></li>
								</ul>
							
							</div>				
						</div>
					</section>
					
				<!-- Two -->
					<section id="section2" class="wrapper style1 container special">
						<div class="row">
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>Privacidad</h3>
									</header>
									<p>Todos sus proyectos y datos de registro son privados y no se publican en ning&uacute;n lugar.</p>
								</section>
							
							</div>
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>Colaboraci&oacute;n</h3>
									</header>
									<p>Trabaje en equipo y organice el trabajo para ser mas eficiente.</p>
								</section>
							
							</div>
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>Portabilidad</h3>
									</header>
									<p>No nocesita descargar ni instalar nada, s&oacute;lo disponer de conexi&oacute;n a Internet.</p>
								</section>
							
							</div>
						</div>

                        <div class="row">
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>Seguimiento</h3>
									</header>
									<p>Podr&aacute; disponer de gr&aacute;ficos de progreso para visualizar r&aacute;pidamente el estado del proyecto.</p>
								</section>
							
							</div>
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>Organizado</h3>
									</header>
									<p>Cree tareas, defina su finalizaci&oacute;n y asigne prioridades para completarlas ordenadamente.</p>
								</section>
							
							</div>
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>Gratuito</h3>
									</header>
									<p>No necesita pagar nada con su tarjeta, ni usarlo con funciones limitadas. ¡S&oacute;lo reg&iacute;strese y comience!</p>
								</section>
							
							</div>
						</div>
					</section>
					
				<!-- Three -->
					<section class="wrapper style3 container special" id="ContenedorImgGraficos">
					
						<header class="major">
							<h2>Gr&aacute;ficos para una r&aacute;pida visualizaci&oacute;n de sus proyectos</h2>
						</header>
						
						<div class="row">
							<div class="6u">							
								<section>
									<a href="#" class="image feature"><asp:Image ID="Image1" ImageUrl="~/images/GraficoTorta.png" runat="server"></asp:Image>  </a>
									<header>
										<h3>Gr&aacute;fico de prioridad</h3>
									</header>
									<p>Tenga presente en todo momento la criticidad del proyecto en funci&oacute;n de las prioridades de las tareas.</p>
								</section>

							</div>
							<div class="6u">							
								<section>
									<a href="#" class="image feature"><asp:Image ID="Image2" ImageUrl="~/images/GraficoBarra.png" runat="server"></asp:Image></a>
									<header>
										<h3>Gr&aacute;fico de asignaci&oacute;n</h3>
									</header>
									<p>Verifique la cantidad de tareas que tiene asignadas cada participante para controlar la carga y distribuci&oacute;n de trabajo.</p>
								</section>

							</div>
						</div>
						
						<%--<footer class="major">
							<ul class="buttons">
								<li><a href="#banner" class="button fit scrolly">See More</a></li>
							</ul>
						</footer>--%>
					
					</section>
					
			</article>

		<!-- Footer -->
			<footer id="footer">
			
				<ul class="icons">
					<li><a href="https://twitter.com/proyectosprodeo" class="icon circle fa-twitter"><span class="label">Twitter</span></a></li>
					<li><a href="https://www.facebook.com/pages/Prodeo/1567642463469507" class="icon circle fa-facebook"><span class="label">Facebook</span></a></li>
					<%--<li><a href="#" class="icon circle fa-google-plus"><span class="label">Google+</span></a></li>
					<li><a href="#" class="icon circle fa-github"><span class="label">Github</span></a></li>
					<li><a href="#" class="icon circle fa-dribbble"><span class="label">Dribbble</span></a></li>--%>
				</ul>
				
				<span class="copyright">&copy; PRODEO. Todos los derechos reservados.</span>
			
			</footer>


</asp:Content>

