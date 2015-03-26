<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Prodeo.index" %>
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
					<p>Gestiona tus <b>Proyectos</b><br />
					de manera facil e<br />
					intuitiva</p>
					<footer>
						<ul class="buttons vertical">
							<li><a href="#main" class="button fit scrolly">Caracteristicas</a></li>
						</ul>
					</footer>
				
				</div>
				
			</section>
		    
             
            

		<!-- Main -->
			<article id="main">

				<header class="special container">
					<span class="icon fa-bar-chart-o"></span>
					<h2>Necesitas llevar un orden en tus <b>Proyectos</b> y no sabes como?<br />
					En este peque&ntilde;o instructivo te contamos como...</h2>
					<p><strong>Prodeo</strong> esta orientado a empresas con grupos que trabajen a distancia<br />
					y que quieran administrar sus actividades de forma ordenada, evitando retrasos, 
					solapamientos de tareas<br /> y problemas de comunicaci&oacute;n.<br />
					Tambien puede ser utilizado por particulares que quieran tener organizadas<br />
                        sus actividades a lo largo de la semana.
					</p>
				</header>
					
				<!-- One -->
					<section class="wrapper style2 container special-alt">
						<div class="row half">
							<div class="8u">
							
								<header>
									<h2>Administra tiempo, recursos, personas y la seguridad de tener tu <strong>Proyecto</strong> controlado!</h2>
								</header>
								<p>Sed tristique purus vitae volutpat ultrices. Aliquam eu elit eget arcu comteger ut fermentum lorem. Lorem ipsum dolor sit amet. Sed tristique purus vitae volutpat ultrices. eu elit eget commodo. Sed tristique purus vitae volutpat ultrices. Aliquam eu elit eget arcu commodo.</p>
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
									<p>Todos tus proyectos y datos de registro son privados y no se publican en ningun lugar.</p>
								</section>
							
							</div>
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>Colaboraci&oacute;n</h3>
									</header>
									<p>Trabaja en equipo y organiza el trabajo para ser mas eficiente.</p>
								</section>
							
							</div>
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>Portabilidad</h3>
									</header>
									<p>No nocesitas descargar ni instalar nada, solo disponer de conexi&oacute;n a internet.</p>
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
									<p>Podras disponer de graficos de progreso para visualizar rapidamente el estado del proyecto.</p>
								</section>
							
							</div>
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>Organizado</h3>
									</header>
									<p>Crea tareas, define su finalizacion y asigna prioridades para hacerlas ordenadamente.</p>
								</section>
							
							</div>
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>Gratuito</h3>
									</header>
									<p>No nocesitas pagar nada con tu tarjeta, ni usarlo con funciones limitadas. Solo registrate y comienza!</p>
								</section>
							
							</div>
						</div>
					</section>
					
				<!-- Three -->
					<section class="wrapper style3 container special" id="tutorial">
					
						<header class="major">
							<h2>Next look at this <strong>cool stuff</strong></h2>
						</header>
						
						<div class="row">
							<div class="6u">
							
								<section>
									<a href="#" class="image feature"><asp:Image ID="Image1" ImageUrl="~/images/muestra1.jpg" runat="server"></asp:Image>  </a>
									<header>
										<h3>A Really Fast Train</h3>
									</header>
									<p>Sed tristique purus vitae volutpat commodo suscipit amet sed nibh. Proin a ullamcorper sed blandit. Sed tristique purus vitae volutpat commodo suscipit ullamcorper sed blandit lorem ipsum dolore.</p>
								</section>

							</div>
							<div class="6u">
							
								<section>
									<a href="#" class="image feature"><asp:Image ID="Image2" ImageUrl="~/images/muestra2.jpg" runat="server"></asp:Image></a>
									<header>
										<h3>An Airport Terminal</h3>
									</header>
									<p>Sed tristique purus vitae volutpat commodo suscipit amet sed nibh. Proin a ullamcorper sed blandit. Sed tristique purus vitae volutpat commodo suscipit ullamcorper sed blandit lorem ipsum dolore.</p>
								</section>

							</div>
						</div>
						<div class="row">
							<div class="6u">
							
								<section>
									<a href="#" class="image feature"><asp:Image ID="Image3" ImageUrl="~/images/muestra3.jpg" runat="server"></asp:Image></a>
									<header>
										<h3>Hyperspace Travel</h3>
									</header>
									<p>Sed tristique purus vitae volutpat commodo suscipit amet sed nibh. Proin a ullamcorper sed blandit. Sed tristique purus vitae volutpat commodo suscipit ullamcorper sed blandit lorem ipsum dolore.</p>
								</section>

							</div>
							<div class="6u">
							
								<section>
									<a href="#" class="image feature"><asp:Image ID="Image4" ImageUrl="~/images/muestra4.jpg" runat="server"></asp:Image></a>
									<header>
										<h3>And Another Train</h3>
									</header>
									<p>Sed tristique purus vitae volutpat commodo suscipit amet sed nibh. Proin a ullamcorper sed blandit. Sed tristique purus vitae volutpat commodo suscipit ullamcorper sed blandit lorem ipsum dolore.</p>
								</section>

							</div>
						</div>

						<footer class="major">
							<ul class="buttons">
								<li><a href="#banner" class="button fit scrolly">See More</a></li>
							</ul>
						</footer>
					
					</section>
					
			</article>

		<!-- CTA -->
			<section id="cta">
			
				<header>
					<h2>Queres recibir nuestro <strong>Newsletter</strong>?</h2>
					<p>Ingresa tus datos y te llegar&aacute;n nuestras novedades!</p>
				</header>
				<footer>
					<!-- Content -->
							<div id="contentNewsletter">
								<form>
									<div class="row 50%">
										<div class="6u 12u(mobile)">
											<input type="text" name="name" placeholder="Name" />
										</div>
										<div class="6u 12u(mobile)">
											<input type="text" name="email" placeholder="Email" />
										</div>
									</div>
									<div class="row">
										<div class="12u">
											<ul class="buttons">
												<li><input type="submit" class="special" value="Enviar" /></li>
											</ul>
										</div>
									</div>
								</form>
							</div>

				</footer>
			
			</section>

		<!-- Footer -->
			<footer id="footer">
			
				<ul class="icons">
					<li><a href="#" class="icon circle fa-twitter"><span class="label">Twitter</span></a></li>
					<li><a href="#" class="icon circle fa-facebook"><span class="label">Facebook</span></a></li>
					<li><a href="#" class="icon circle fa-google-plus"><span class="label">Google+</span></a></li>
					<li><a href="#" class="icon circle fa-github"><span class="label">Github</span></a></li>
					<li><a href="#" class="icon circle fa-dribbble"><span class="label">Dribbble</span></a></li>
				</ul>
				
				<span class="copyright">&copy; Untitled. All rights reserved. Design: <a href="http://html5up.net">HTML5 UP</a>.</span>
			
			</footer>


</asp:Content>

