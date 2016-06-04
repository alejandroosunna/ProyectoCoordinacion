<%@ Page Title="IndexAlumno" MasterPageFile="~/Alumno.master" Language="C#" AutoEventWireup="true" CodeFile="IndexAlumno.aspx.cs" Inherits="IndexAlumno" EnableEventValidation="false" %>
<asp:Content ID="Content" ContentPlaceHolderID="CPHBody" runat="server">

<!--Let browser know website is optimized for mobile-->
      <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <!-- Materialize CSS -->
    <br /><br />
    <section id="Resumen" class="container z-depth-2 green">        
        <div class="row center center-align">
            <br />
            <h5 class="mdl-typography--font-bold white-text">Status Alumno:</h5>
        </div>
         <div class="row">
             <div class="col s10 m10 l6 offset-l3 offset-m1 offset-s1 center center-align">
                                <div class="card orange darken-2">
                                <div class="card-content white-text">
                                    <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                                    <br />
                                    <asp:Label ID="lblNumControl" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="card-action">
                                </div>
                                </div>
                            </div>
                            <div class="col s10 m10 l6 offset-l3 offset-m1 offset-s1 center center-align">
                                <div class="card orange darken-2">
                                <div class="card-content white-text">
                                <span class="fa fa-calendar"></span>
                                     <asp:Label ID="lblPDiaCita" runat="server" Text=""></asp:Label>
                                            <br />
                                            <asp:Label ID="lblPHoraCita" runat="server" Text=""></asp:Label>
                                            <br />
                                            
                                </div>
                                <div class="card-action center center-align">
                                    <div class="col s12 m12 l6 offset-l3">
                                        <asp:Button ID="btnEliminarCita" runat="server" Text="Eliminar" Visible="false" OnClick="btnEliminarCita_Click" CssClass="btn white-text green darken-2"/>
                                    </div>
                                </div>
                                </div>
                            </div>
         </div>
    </section>

	<!-- Resumen end -->
    <div id="fullcalendar" class="container"></div>


	<!-- Citas start -->

<%--	<section id="Citas" class="container">
        <div class="row center center-align">
				<div class="col s12 m10 l10 offset-l1 offset-m1 center center-align">
                    <h5 class="pfblock-title mdl-typography--font-bold">Citas</h5>
                    <div class="section scrolling-table-container z-depth-1-half">
                        <asp:GridView ID="GridViewCitas" runat="server" DataKeyNames="NumeroCita" AutoGenerateColumns="false" CssClass="" BorderStyle="None" OnSelectedIndexChanged="GridViewCitas_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="true" ButtonType="Link" HeaderText="Seleccionar" />
                                <asp:BoundField DataField="NumeroCita" HeaderText="NumeroCita" ReadOnly="True" SortExpression="NumeroCita" />
                                <asp:BoundField DataField="Hora" HeaderText="Hora" SortExpression="Hora" />
                                <asp:BoundField DataField="Dia" HeaderText="Dia" SortExpression="Dia" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
    </section>--%>

         
         
    
	<!-- Citas end -->


	<!-- Contacto start -->
     <section id="Contacto" class="container">
         <div class="row center center-align">
            <br />
            <h5 class="mdl-typography--font-bold blue-grey-text">Contacto:</h5>
        </div>
         <div class="row center center-align">
             <div class="col s12 m12 l8 offset-l2 center center-align">
                     <div class="form-group wow fadeInUp">
                         <asp:TextBox ID="txtName" placeholder = "Nombre" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                     </div>
                     <div class="form-group wow fadeInUp" data-wow-delay=".1s">
                         <asp:TextBox ID="txtEmail" placeholder = "E-mail" CssClass="form-control" runat="server" Width="100%" ></asp:TextBox>
                     </div>
                     <div class="form-group wow fadeInUp" data-wow-delay=".2s">
                         <asp:TextBox ID="txtMesg" placeholder = "Mensaje" CssClass="form-control" runat="server" Rows="10" TextMode="MultiLine" Width="100%"></asp:TextBox>
                     </div>
                 <br />
                     <asp:Button id="btnSend" type="submit" CssClass="btn green darken-2" data-wow-delay=".3s" runat="server" Text="Enviar Mensaje" OnClick="btnSend_Click"></asp:Button><br /><br />
                 <div class="ajax-response"></div>
             </div>
         </div>
     </section>
    <!-- Contacto end -->
	<!-- Scroll to top -->

	
    <div>
             <asp:SqlDataSource ID="SqlDataDropDListMotivos" runat="server" ConnectionString="<%$ ConnectionStrings:dbProyectoCoordinacion %>" SelectCommand="SELECT * FROM [tbMotivos] WHERE ([IdCarrera] = @IdCarrera)">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="IdCarrera" SessionField="IdCarrera" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
	</div>
    
    <script>
    $(document).ready(function () {   
        calendario();     
    });
    function calendario() {
        $('#fullcalendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'agendaDay,week,month'
            },
            defaultView: 'agendaDay',
            editable: true,
            allDaySlot: false,
            selectable: true,
            slotMinutes: 15,
            events: '/getCitas.ashx',
            eventClick: function (calEvent, jsEvent, view) {
              
                Save(calEvent.id, calEvent.date);
            }


        });
    }

    function Save(id, date) {
       
        var dataRow = {
            'IdCita': id
        }

        swal({
            title: "Quieres seleccionar esta cita?",
            text: "Seleccionaras la cita" + id + "!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Seleccionar!",
            closeOnConfirm: false
        },
        function () {
            $.ajax({
                type: 'POST',
                url: "GuardarCita.ashx",
                data: dataRow,
                dataType: "json",
                success: function (response) {              
                    if (response == "1") {
                       
                        swal("Correcto!", "Seleccionaste la cita :" + id + " con fecha " + date, "success");
                        location.reload();
                    }else{
                        swal("OPSSS!", "no se pudo seleccionar la cita", "error");
                    }
                        
                },
                error: function (response) {
                    swal("OPSSS!", "Sucedio un error, intentalo de nuevo", "error");
                }
            });

        });

    }
   

</script>

</asp:Content>
