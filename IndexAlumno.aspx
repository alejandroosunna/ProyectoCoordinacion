<%@ Page Title="IndexAlumno" MasterPageFile="~/Alumno.master" Language="C#" AutoEventWireup="true" CodeFile="IndexAlumno.aspx.cs" Inherits="IndexAlumno" EnableEventValidation="false" %>
<asp:Content ID="Content" ContentPlaceHolderID="CPHBody" runat="server">

    

   
<%--    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
     
    <link rel="stylesheet" href="material.min.css"/>
    <link href="materialize/css/materialize.css" rel="stylesheet" media="screen"/>
      <!--Let browser know website is optimized for mobile-->
      <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
	<!-- Materialize CSS -->
       
  
    


    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script type="text/javascript" src="materialize/js/materialize.min.js"></script>
    <script type="text/javascript" language="javascript">// <![CDATA[
        $(document).ready(function(){
           
            $('.button-collapse').sideNav({
                menuWidth: 300, // Default is 240
                edge: 'right', // Choose the horizontal origin
                closeOnClick: true // Closes side-nav on <a> clicks, useful for Angular/Meteor
            }
 );
        });
 
   </script>--%>
  
        <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
        <link rel="stylesheet" href="material.min.css">
        <link href="materialize/css/materialize.css" rel="stylesheet" media="screen"/>
        <link href="materialize/css/EstiloAlumno.css" rel="stylesheet" media="screen"/>
      <!--Let browser know website is optimized for mobile-->
      <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <!-- Materialize CSS -->
   
	<!-- Preloader -->

	<div id="preloader">
		<div id="status"></div>
	</div>


	<!-- Navigation end -->

    <!-- Resumen -->
 
<%--	<section id="Resumen" class="pfblock pfblock-gray">
	    <div class="container">
			<div class="row">

				<div class="col-sm-6 col-sm-offset-3">
                    
					<div class="pfblock-header wow fadeInUp">
						<h2 class="pfblock-title">Usuario</h2>
						<div class="pfblock-line"></div>
						<div class="pfblock-subtitle">
                            
						</div>
                    <div class="card-action">
                        <a href="#">This is a link</a>
                        <a href="#">This is a link</a>
					</div>
				</div>
			</div>

	
                <div class="row">
                <div class="col s3 m6">
                    <div class="card blue-grey darken-1">
                    <div class="card-content white-text">
                        <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                        <br />
                                <asp:Button ID="btnEliminarCita" runat="server" Text="Eliminar" Visible="false" OnClick="btnEliminarCita_Click"/>
                    </div>
                    <div class="card-action center-align">
                        <a href="#" class="btn orange white-text center-align">Configuración</a>
                        
                    </div>
                    </div>
                </div>
                </div>
                  
               
		</div>
	    </div>
		
	</section>--%>
     <section id="Resumen"style="height: 550px; margin-top: 5%;">
                    <div class="row">

                    <div class="formholder" >
                            <div class="mdl-cell mdl-cell--10-col"style="padding-left: 13%;max-width: 85%;">
                                <div class="card green darken-1">
                                <div class="card-content white-text">
                                    <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lblNumControl" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="card-action">
                                    <a href="#">This is a link</a>
                                    <a href="#">This is a link</a>
                                </div>
                                </div>
                            </div>
                            <div class="mdl-cell mdl-cell--10-col"style="padding-left: 13%;max-width: 85%;">
                                <div class="card green darken-1">
                                <div class="card-content white-text">
                                <span class="fa fa-calendar"></span>
                                     <asp:Label ID="lblPDiaCita" runat="server" Text=""></asp:Label>
                                            <br />
                                            <asp:Label ID="lblPHoraCita" runat="server" Text=""></asp:Label>
                                            <br />
                                            <asp:Button ID="btnEliminarCita" runat="server" Text="Eliminar" Visible="false" OnClick="btnEliminarCita_Click"/>
                                </div>
                                <div class="card-action">
                                    <a href="#">This is a link</a>
                                    <a href="#">This is a link</a>
                                </div>
                                </div>
                            </div>
                    </div>
                        </div>
                  </section>

	<!-- Resumen end -->
	<!-- Citas start -->

	<section id="Citas" class="pfblock">
            
            <div class="row">
				<div class="col-sm-6 col-sm-offset-3 fa-align-center">
					<div class="pfblock-header wow fadeInUp ajax-response pre-scrollable">
						
                        <div class="row center-align centered center-block">
                            <asp:DropDownList runat="server" ID="DropDListMotivos" DataSourceID="SqlDataDropDListMotivos" DataValueField="IdMotivo" DataTextField="Motivo" CssClass="materialboxed input-field orange white-text"></asp:DropDownList>
                        </div>
                        <div class="scrolling-table-container row">

					<div class="pfblock-header wow fadeInUp ajax-response">
						<h2 class="pfblock-title">Citas</h2>

                        <asp:GridView ID="GridViewCitas" runat="server" DataKeyNames="NumeroCita" AutoGenerateColumns="false" CssClass="table media-list fa-border table-bordered table-responsive table-condensed caption ajax-response wow bounce" BorderStyle="None" OnSelectedIndexChanged="GridViewCitas_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="true" ButtonType="Link" HeaderText="Seleccionar" />
                                <asp:BoundField DataField="NumeroCita" HeaderText="NumeroCita" ReadOnly="True" 
                                    SortExpression="NumeroCita" />
                                <asp:BoundField DataField="Hora" HeaderText="Hora" 
                                    SortExpression="Hora" />
                                <asp:BoundField DataField="Dia" HeaderText="Dia" 
                                    SortExpression="Dia" />
                            </Columns>
                        </asp:GridView>

						
					</div>
                           
  </div>


                 
		</div><!-- .row -->
            <div class="container">
	</section>

         
         
    
	<!-- Citas end -->


	<!-- Contacto start -->
     <section id="Contacto" class="pfblock">

        <div class="formholder">
        <div class="randompad">
           <fieldset>
               <div class="col-sm-6">
                    <form id="contact-form" role="form">
                        <div class="ajax-hidden">
                            <div class="form-group wow fadeInUp">
<%--                                <label class="sr-only" for="c_name">Name</label>--%>
                                <asp:TextBox ID="txtName" placeholder = "Nombre" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                            </div>
                            <div class="form-group wow fadeInUp" data-wow-delay=".1s">
<%--                                <label class="sr-only" for="c_email">Email</label>--%>
                                <asp:TextBox ID="txtEmail" placeholder = "E-mail" CssClass="form-control" runat="server" Width="100%" ></asp:TextBox>
                            </div>
                            <div class="form-group wow fadeInUp" data-wow-delay=".2s">
                                <asp:TextBox ID="txtMesg" placeholder = "Mensaje" CssClass="form-control" runat="server" Rows="10" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </div>
                            <asp:Button id="btnSend" type="submit" CssClass="btn btn-lg btn-block wow fadeIn mdl-color-green" data-wow-delay=".3s" runat="server" Text="Enviar Mensaje" OnClick="btnSend_Click"></asp:Button>
                        </div>
                        <div class="ajax-response"></div>
                    </form>
                </div>
 
           </fieldset>
        </div>
      </div>
            </section>
<%--	<section id="Contacto" class="center-align">
		<div class="container">
			<div class="row center-align">

				<div class="center-align">

				<div class="col-sm-6 col-sm-offset-3">

					<div class="pfblock-header">
						<h2 class="pfblock-title">Contactanos</h2>
						<div class="pfblock-line"></div>
						<div class="pfblock-subtitle">
                            Preguntanos lo que quieras..<br />
                            Nosotros respondemos ;D
						</div>
					</div>

				</div>

			</div><!-- .row -->

			<div class="container">

				<div class="col s6 m6 l6">--%>

					<%--	<div class="ajax-hidden">
							<div class="input-field col s6">
								<label class="sr-only" for="c_name">Name</label>
                                <asp:TextBox ID="txtName" placeholder = "Nombre" CssClass="form-control" runat="server" Width="550px"></asp:TextBox>
							</div>

							<div class="input-field col s6" data-wow-delay=".1s">
								<label class="sr-only" for="c_email">Email</label>
                                <asp:TextBox ID="txtEmail" placeholder = "E-mail" CssClass="form-control" runat="server" Width="550px" ></asp:TextBox>
							</div>

							<div class="input-field col s6" data-wow-delay=".2s">
                                <asp:TextBox ID="txtMesg" placeholder = "Mensaje" CssClass="materialize-textarea" runat="server" Rows="10" TextMode="MultiLine" Width="288px"></asp:TextBox>
							</div>
                            <asp:Button id="btnSend" type="submit" CssClass="btn btn-lg btn-block wow fadeIn" data-wow-delay=".3s" runat="server" Text="Enviar Mensaje" OnClick="btnSend_Click"></asp:Button>
						</div>
						<div class="ajax-response"></div>

				</div>

			</div><!-- .row -->
		</div><!-- .container -->
        </div>
	</section>--%>

	<!-- Contacto end -->

	<!-- Footer start -->

	<footer id="footer">
		<div class="container">
			<div class="row">

				<div class="col-sm-12">

					<ul class="social-links">
						<li><a href="index.html#" class="wow fadeInUp"><i class="fa fa-facebook"></i></a></li>
						<li><a href="index.html#" class="wow fadeInUp" data-wow-delay=".1s"><i class="fa fa-twitter"></i></a></li>
						<li><a href="index.html#" class="wow fadeInUp" data-wow-delay=".2s"><i class="fa fa-google-plus"></i></a></li>
						<li><a href="index.html#" class="wow fadeInUp" data-wow-delay=".4s"><i class="fa fa-pinterest"></i></a></li>
						<li><a href="index.html#" class="wow fadeInUp" data-wow-delay=".5s"><i class="fa fa-envelope"></i></a></li>
					</ul>

					<p class="heart">
                        <span class="fa fa-thumbs-o-up fa-3x animated tada"style="color:#e81d1d;"></span> 
                    </p>                <%--Modificado--%>
                    <p class="copyright"">
                        © 2015  <a href="ith.mx"style="color:#e81d1d;">ITH</a>
					</p>            <%--Modificado--%>

				</div>

			</div><!-- .row -->
		</div><!-- .container -->
	</footer>


	<!-- Scroll to top -->

	
    <div>
             <asp:SqlDataSource ID="SqlDataDropDListMotivos" runat="server" ConnectionString="<%$ ConnectionStrings:dbProyectoCoordinacion %>" SelectCommand="SELECT * FROM [tbMotivos] WHERE ([IdCarrera] = @IdCarrera)">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="IdCarrera" SessionField="IdCarrera" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
	</div>
    
</asp:Content>
