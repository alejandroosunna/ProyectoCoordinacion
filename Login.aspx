<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<!DOCTYPE html>
<html>
<head>

    <title>SIAC</title>
    <link href="ithicon.ico" rel="shortcut icon" type="image/png">
    <!-- CSS  -->
<<<<<<< HEAD
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/css/materialize.min.css">
</head>
<body>

    <!--Navigation-->
    <nav class="top-nav green">
        <div class="container">
            <a class="waves-effect waves-orange btn modal-trigger" href="#modal1">Inicio de sesion</a>
            <span><img src="Ithlogo.png" style="float: right; margin-right: -12%;"></span>
        </div>
    </nav>

    <!-- Login -->
    <div id="modal1" class="modal">
        <div class="modal-content">
               <form class="navbar-form navbar-right" role="form" runat="server">
                    <div>
                            <div class="form-group">
                              <asp:TextBox id ="txtNumControl" runat ="server" placeholder="Numero de Control" type="Text" CssClass="form-control"></asp:TextBox>
                           
                            </div>
                            <div class="form-group">
                              <asp:TextBox id ="txtContraseña" runat ="server" placeholder="Password" type="password" CssClass="form-control"></asp:TextBox>
                             
                            </div>
                            
                     </div>               
        <div class="modal-footer">
             <asp:Button ID ="btnLogin" runat="server" Text="Sign In" CssClass="btn btn-success" OnClick="btnLogin_Click"></asp:Button> 
        </div>
           </form>
      </div>
       
    </div>
            <!--Noticias-->
            <div class="container">
        <div class="slider">
            <ul class="slides">
                <li>
                    <img src="img/alumnos.jpg"> <!-- random image -->
                    <div class="caption center-align">
                        <h3>Alumnos con todo!</h3>
                        <h5 class="light black-text text-lighten-3">;)</h5>
=======
    <link rel="stylesheet" href="materialize/css/materialize.css"/>
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
</head>
<body>
<header>
    <!--Navigation-->
    <nav>
        <div class="nav-wrapper orange white-text">
            <a href="#!" class="brand-logo center">Sistema Integral de Apartado de Citas</a>
            <img src="Ithlogo.png" class="circle small hide-on-med-and-down" />
            <a href="#" data-activates="mobile-demo" class="button-collapse"><i class="material-icons">menu</i></a>
            <ul class="right hide-on-med-and-down">
                <li>
                    <a class="waves-effect modal-trigger" href="#modal1">Inicio de Sesión</a>
                </li>
            </ul>
            <ul class="side-nav" id="mobile-demo">
                <li>
                    <a class="waves-effect modal-trigger" href="#modal1">Inicio de Sesión</a>
                </li>
            </ul>
        </div>
        <div id="modal1" class="modal center">
            <div class="modal-content center center-align">
                <form class="navbar-form center center-align" role="form" runat="server">
                    <div>
                        <div class="form-group">
                            <asp:TextBox id ="txtNumControl" runat ="server" placeholder="Numero de Control" type="Text" CssClass="form-control blue-grey-text"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox id ="txtContraseña" runat ="server" placeholder="Password" type="password" CssClass="form-control blue-grey-text"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer center center-align">
                        <asp:Button ID ="btnLogin" runat="server" Text="Iniciar" CssClass="btn orange white-text" OnClick="btnLogin_Click"></asp:Button>
                    </div>
                </form>
            </div>
        </div>
    </nav>
    <!-- Login -->
    </header>
    <main>
            <!--Noticias-->
            <div class="container">
                <br />
        <div class="slider">
            <ul class="slides" id="slides" runat="server">
                <li>
                    <img id="img1" src="img/alumnos.jpg" /> <!-- random image -->
                    <div class="caption center-align">
>>>>>>> refs/remotes/origin/master
                    </div>
                </li>

                <li>
<<<<<<< HEAD
                    <img src="img/ith.jpeg"> <!-- random image -->
                    <div class="caption right-align black-text">
                        <h3>Materias agregadas</h3>
                        <h5 class="light black-text text-lighten-3">:D</h5>
                    </div>
                </li>
                <li>
                    <img src="img/1_4278826.jpg"> <!-- random image -->
                    <div class="caption center-align black-text">
                        <h3>Nuevo ciclo!</h3>
                        <h5 class="light black-text text-lighten-3">:)</h5>
=======
                    <img src="img/ith.jpeg" /> <!-- random image -->
                    <div class="caption right-align black-text">

                    </div>
                </li>
                <li>
                    <img src="img/1_4278826.jpg" /> <!-- random image -->
                    <div class="caption center-align black-text">

>>>>>>> refs/remotes/origin/master
                    </div>
                </li>
            </ul>
        </div>
<<<<<<< HEAD
    </div>
            <div class="section scrollspy" id="work">
                <div class="container">
                    <div class="row">
                        <div class="col s12 m4 l4">
                            <div class="card medium">
                                <div class="card-image waves-effect waves-block waves-light">
                                    <img class="activator" src="img/alumnos.jpg">
                                </div>
                                <div class="card-content">
                                    <span class="card-title activator grey-text text-darken-4">Noticia 1 <i class="mdi-navigation-more-vert right"></i></span>
                                    <p><a href="#">Saber mas...</a></p>
                                </div>
                                <div class="card-reveal">
                                    <span class="card-title grey-text text-darken-4">Noticia 1 <i class="mdi-navigation-close right"></i></span>
                                    <p>Aqui encontraras informacion detallada acerca de la noticia en cuestion</p>
                                </div>
                            </div>
                        </div>
                        <div class="col s12 m4 l4">
                            <div class="card medium">
                                <div class="card-image waves-effect waves-block waves-light">
                                    <img class="activator" src="img/ith.jpeg">
                                </div>
                                <div class="card-content">
                                    <span class="card-title activator grey-text text-darken-4">Noticia 2 <i class="mdi-navigation-more-vert right"></i></span>
                                    <p><a href="#">Saber mas...</a></p>
                                </div>
                                <div class="card-reveal">
                                    <span class="card-title grey-text text-darken-4">Noticia 2 <i class="mdi-navigation-close right"></i></span>
                                    <p>Aqui encontraras informacion detallada acerca de la noticia en cuestion</p>
                                </div>
                            </div>
                        </div>
                        <div class="col s12 m4 l4">
                            <div class="card medium">
                                <div class="card-image waves-effect waves-block waves-light">
                                    <img class="activator" src="img/1_4278826.jpg">
                                </div>
                                <div class="card-content">
                                    <span class="card-title activator grey-text text-darken-4">Servicio <i class="mdi-navigation-more-vert right"></i></span>
                                    <p><a href="#">Saber mas...</a></p>
                                </div>
                                <div class="card-reveal">
                                    <span class="card-title grey-text text-darken-4">Servicio <i class="mdi-navigation-close right"></i></span>
                                    <p>Aqui encontraras informacion detallada acerca de la noticia en cuestion</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
=======
    </div><br />
        <div class="row center">
            <h4>Noticias</h4>
            <div class="col s12 m12 l8 offset-l2">
                <ul runat="server" id="noticias" class="collapsible popout" data-collapsible="accordion">

                </ul>
            </div>
        </div>
            <div class="row center-block center centered">
                <div class="valign-wrapper hide-on-large-only">
                    <div class="col s12 m12 l3 valign">
                            <div class="card">
                                <div class="card-image">
                                    <img src="Img/ith.jpeg" />
                                </div>
                                <div class="card-content green">
                                    <p class="black-text">Coordinacion ITH.</p>
                                </div>
                            </div>
                        </div>       
                        <div class="col s12 m12 l3 valign">
                            <div class="card">
                                <div class="card-image">
                                    <img src="Img/cartoon-1300224.svg" class="small" />
                                </div>
                                <div class="card-content green darken-3">
                                    <p class="black-text">Chatea con tu coordinador.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                <div class="valign-wrapper hide-on-large-only">
                        <div class="col s12 m12 l3 valign">
                        <div class="card">
                            <div class="card-image">
                                <img src="Img/address-book-1308358.jpg" class="small" />
                            </div>
                            <div class="card-content green lighten-2">
                                <p class="black-text">Agenda tu cita.</p>
                            </div>
                        </div>
                    </div>
                        <div class="col s12 m12 l3 valign">
                            <div class="card">
                                <div class="card-image">
                                    <img src="Img/android-1293981.svg" />
                                </div>
                                <div class="card-content green">
                                    <p class="black-text">Desde cualquier dispositivo.</p>
                                </div>
                            </div>
                        </div> 
                    </div>           
        </div>  
        <div class="row hide-on-med-and-down valign-wrapper center centered">
                    <div class="col s12 m12 l3 valign">
                            <div class="card">
                                <div class="card-image">
                                    <img src="Img/ith.jpeg" />
                                </div>
                                <div class="card-content green">
                                    <p class="black-text">Coordinacion ITH.</p>
                                </div>
                            </div>
                        </div>       
                        <div class="col s12 m12 l3 valign">
                            <div class="card">
                                <div class="card-image">
                                    <img src="Img/cartoon-1300224.svg" class="small" />
                                </div>
                                <div class="card-content green darken-3">
                                    <p class="black-text">Chatea con tu coordinador.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col s12 m12 l3 valign">
                        <div class="card">
                            <div class="card-image">
                                <img src="Img/address-book-1308358.jpg" class="small" />
                            </div>
                            <div class="card-content green lighten-2">
                                <p class="black-text">Agenda tu cita.</p>
                            </div>
                        </div>
                    </div>
                        <div class="col s12 m12 l3 valign">
                            <div class="card">
                                <div class="card-image">
                                    <img src="Img/android-1293981.svg" />
                                </div>
                                <div class="card-content green">
                                    <p class="black-text">Desde cualquier dispositivo.</p>
                                </div>
                            </div> 
                    </div> 
        </div>      
    </main>
>>>>>>> refs/remotes/origin/master
            <!--Footer-->
            <footer class="page-footer orange">
                <div class="footer-copyright">
                    <div class="container">
                        © 2016 ITH
                    </div>
                </div>
            </footer>
            <!--  Scripts-->
            <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
<<<<<<< HEAD
            <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/js/materialize.min.js"></script>
            <script src="js/JavaSesion.js"></script>

=======
    <script src="js/JavaSesion.js"></script>
    <script type="text/javascript" src="materialize/js/materialize.min.js"></script>
    <script type="text/javascript" lang="javascript">// <![CDATA[
        $(document).ready(function () {
            $('.button-collapse').sideNav({
                menuWidth: 300, // Default is 240
                edge: 'left', // Choose the horizontal origin
                closeOnClick: true // Closes side-nav on <a> clicks, useful for Angular/Meteor
            });
        });
        </script>
    <script type="text/javascript" lang="javascript">
        $(document).ready(function () {
            $('.parallax').parallax();
        });
    </script>
    <script>
        $(document).ready(function () {
            $('.collapsible').collapsible();
        });
    </script>
    <!--  Final de Scripts-->
>>>>>>> refs/remotes/origin/master
</body>
</html>
