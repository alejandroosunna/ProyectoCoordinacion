<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<!DOCTYPE html>
<html>
<head>

    <title>SIAC</title>
    <link href="ithicon.ico" rel="shortcut icon" type="image/png">
    <!-- CSS  -->
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
                    </div>
                </li>

                <li>
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
                    </div>
                </li>
            </ul>
        </div>
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
            <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/js/materialize.min.js"></script>
            <script src="js/JavaSesion.js"></script>

</body>
</html>
