<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<!DOCTYPE html>
<html>
<head>

    <title>SIAC</title>
    <link href="ithicon.ico" rel="shortcut icon" type="image/png">
    <!-- CSS  -->
    <link rel="stylesheet" href="materialize/css/materialize.css"/>
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
</head>
<body>
<header>
    <!--Navigation-->
    <nav>
        <div class="nav-wrapper orange white-text">
            <a href="#!" class="brand-logo center">SIAC</a>
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
    </div><br />
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
    <!--  Final de Scripts-->

</body>
</html>
