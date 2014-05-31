﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Prodeo.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
		<title>Twenty by HTML5 UP</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8" />
		<meta name="description" content="" />
		<meta name="keywords" content="" />
		<!--[if lte IE 8]><script src="css/ie/html5shiv.js"></script><![endif]-->
		<script src="js/jquery.min.js"></script>
		<script src="js/jquery.dropotron.min.js"></script>
        <link href="Styles/modal.css" rel="stylesheet" type="text/css" />
		<script src="js/skel.min.js"></script>
		<script src="js/skel-layers.min.js"></script>
		<script src="js/init.js"></script>
        <script src="js/jquery-1.9.1.min.js" type="text/javascript"></script>
        <script src="js/jquery.leanModal.min.js" type="text/javascript"></script>
		<noscript>
			<link rel="stylesheet" href="Styles/skel.css" />
			<link rel="stylesheet" href="Styles/style.css" />
			<link rel="stylesheet" href="Styles/style-noscript.css" />
		</noscript>
		<!--[if lte IE 8]><link rel="stylesheet" href="Styles/ie/v8.css" /><![endif]-->
		<!--[if lte IE 9]><link rel="stylesheet" href="Styles/ie/v9.css" /><![endif]-->
	</head>
	<body class="index loading">
	
		<!-- Header -->
			<header id="header" class="alt">
				<h1 id="logo"><a href="index.htm"><img src="images/logos/prodeo.gif" /></a></h1>
				<nav id="nav">
					<ul>
						<li class="current"><a href="index.htm">Welcome</a></li>
                        <li class="current"><a href="index.htm">Tutorial</a></li>
                        <li class="current"><a href="index.htm">Mobile</a></li>
						<li><a href="#container" class="button special" id="modaltrigger">Sign Up</a></li>
					</ul>
				</nav>
			</header>

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
		    
             <div class="container" id="container" style="display:none;">
	            <section id="content">
		            <form action="">
			            <h1>Login Form</h1>
			            <div>
				            <input type="text" placeholder="Username" required="" id="username" />
			            </div>
			            <div>
				            <input type="password" placeholder="Password" required="" id="password" />
			            </div>
			            <div>
				            <input type="submit" value="Log in" />
				            <a href="#">Lost your password?</a>
				            <a href="#">Register</a>
			            </div>
		            </form><!-- form -->
		            <div class="buttonModal">
			            <a href="#">Download source file</a>
		            </div><!-- button -->
	            </section><!-- content -->
            </div><!-- container -->
            <script type="text/javascript">
                $(function () {
                    $('#loginform').submit(function (e) {
                        return false;
                    });

                    $('#modaltrigger').leanModal({ top: 110, overlay: 0.45, closeButton: ".hidemodal" });
                });
            </script>

		<!-- Main -->
			<article id="main">

				<header class="special container">
					<span class="icon fa-bar-chart-o"></span>
					<h2>As this is my <strong>twentieth</strong> freebie for HTML5 UP<br />
					I decided to give it a really creative name.</h2>
					<p>Turns out <strong>Twenty</strong> was the best I could come up with. Anyway, lame name aside,<br />
					it's minimally designed, fully responsive, built on HTML5/CSS3/<strong>skel</strong>, 
					and, like all my stuff,<br />
					released for free under the <a href="http://html5up.net/license">Creative Commons Attribution 3.0</a> license. Have fun!</p>
				</header>
					
				<!-- One -->
					<section class="wrapper style2 container special-alt">
						<div class="row half">
							<div class="8u">
							
								<header>
									<h2>Behold the <strong>icons</strong> that visualize what you’re all about. or just take up space. your call bro.</h2>
								</header>
								<p>Sed tristique purus vitae volutpat ultrices. Aliquam eu elit eget arcu comteger ut fermentum lorem. Lorem ipsum dolor sit amet. Sed tristique purus vitae volutpat ultrices. eu elit eget commodo. Sed tristique purus vitae volutpat ultrices. Aliquam eu elit eget arcu commodo.</p>
								<footer>
									<ul class="buttons">
										<li><a href="#" class="button">Find Out More</a></li>
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
					<section class="wrapper style1 container special">
						<div class="row">
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>This is Something</h3>
									</header>
									<p>Sed tristique purus vitae volutpat ultrices. Aliquam eu elit eget arcu commodo suscipit dolor nec nibh. Proin a ullamcorper elit, et sagittis turpis. Integer ut fermentum.</p>
								</section>
							
							</div>
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>Also Something</h3>
									</header>
									<p>Sed tristique purus vitae volutpat ultrices. Aliquam eu elit eget arcu commodo suscipit dolor nec nibh. Proin a ullamcorper elit, et sagittis turpis. Integer ut fermentum.</p>
								</section>
							
							</div>
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>Probably Something</h3>
									</header>
									<p>Sed tristique purus vitae volutpat ultrices. Aliquam eu elit eget arcu commodo suscipit dolor nec nibh. Proin a ullamcorper elit, et sagittis turpis. Integer ut fermentum.</p>
								</section>
							
							</div>
						</div>

                        <div class="row">
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>This is Something</h3>
									</header>
									<p>Sed tristique purus vitae volutpat ultrices. Aliquam eu elit eget arcu commodo suscipit dolor nec nibh. Proin a ullamcorper elit, et sagittis turpis. Integer ut fermentum.</p>
								</section>
							
							</div>
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>Also Something</h3>
									</header>
									<p>Sed tristique purus vitae volutpat ultrices. Aliquam eu elit eget arcu commodo suscipit dolor nec nibh. Proin a ullamcorper elit, et sagittis turpis. Integer ut fermentum.</p>
								</section>
							
							</div>
							<div class="4u">
							
								<section>
									<span class="icon feature fa-check"></span>
									<header>
										<h3>Probably Something</h3>
									</header>
									<p>Sed tristique purus vitae volutpat ultrices. Aliquam eu elit eget arcu commodo suscipit dolor nec nibh. Proin a ullamcorper elit, et sagittis turpis. Integer ut fermentum.</p>
								</section>
							
							</div>
						</div>
					</section>
					
				<!-- Three -->
					<section class="wrapper style3 container special">
					
						<header class="major">
							<h2>Next look at this <strong>cool stuff</strong></h2>
						</header>
						
						<div class="row">
							<div class="6u">
							
								<section>
									<a href="#" class="image feature"><img src="images/pic01.jpg" alt="" /></a>
									<header>
										<h3>A Really Fast Train</h3>
									</header>
									<p>Sed tristique purus vitae volutpat commodo suscipit amet sed nibh. Proin a ullamcorper sed blandit. Sed tristique purus vitae volutpat commodo suscipit ullamcorper sed blandit lorem ipsum dolore.</p>
								</section>

							</div>
							<div class="6u">
							
								<section>
									<a href="#" class="image feature"><img src="images/pic02.jpg" alt="" /></a>
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
									<a href="#" class="image feature"><img src="images/pic03.jpg" alt="" /></a>
									<header>
										<h3>Hyperspace Travel</h3>
									</header>
									<p>Sed tristique purus vitae volutpat commodo suscipit amet sed nibh. Proin a ullamcorper sed blandit. Sed tristique purus vitae volutpat commodo suscipit ullamcorper sed blandit lorem ipsum dolore.</p>
								</section>

							</div>
							<div class="6u">
							
								<section>
									<a href="#" class="image feature"><img src="images/pic04.jpg" alt="" /></a>
									<header>
										<h3>And Another Train</h3>
									</header>
									<p>Sed tristique purus vitae volutpat commodo suscipit amet sed nibh. Proin a ullamcorper sed blandit. Sed tristique purus vitae volutpat commodo suscipit ullamcorper sed blandit lorem ipsum dolore.</p>
								</section>

							</div>
						</div>

						<footer class="major">
							<ul class="buttons">
								<li><a href="#" class="button">See More</a></li>
							</ul>
						</footer>
					
					</section>
					
			</article>

		<!-- CTA -->
			<section id="cta">
			
				<header>
					<h2>Ready to do <strong>something</strong>?</h2>
					<p>Proin a ullamcorper elit, et sagittis turpis integer ut fermentum.</p>
				</header>
				<footer>
					<ul class="buttons">
						<li><a href="#" class="button special">Take My Money</a></li>
						<li><a href="#" class="button">LOL Wut</a></li>
					</ul>
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

	</body>
</html>
