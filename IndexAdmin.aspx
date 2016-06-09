<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="IndexAdmin.aspx.cs" Inherits="IndexAdmin"  EnableEventValidation="false"%>
      

<asp:Content ID="CNTResumen" ContentPlaceHolderID="CPHPrincipal" runat="server"> 
<<<<<<< HEAD
                        <div class="panel-heading section scrollspy">
                          Listado de citas pendientes
                        </div>
                        <br />
                        <input id="date-range-predefined" name="Fecha" type="date" class="h5a-input form-control"/>
=======
            
                     
                       
    <div id="fullcalendar"></div>
    <br />
     Numero Control Alumno: <asp:TextBox ID="txtNumControl" runat="server"></asp:TextBox>
>>>>>>> refs/remotes/origin/master
                        <br />
                        <asp:Button ID="btnBuscar" class="waves-effect waves-light btn orange" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/>
                        <div class="panel-body scrolling-table-container">                           
                                <asp:GridView ID="GridView_Citas" class="table striped responsive-table" runat="server" AutoGenerateColumns="False" DataKeyNames="IdCita" OnRowCommand="GridView_Citas_RowCommand" OnSelectedIndexChanged="GridView_Citas_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="IdCita" HeaderText="IdCita" InsertVisible="False" ReadOnly="True" SortExpression="IdCita" />
                                        <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" SortExpression="IdUsuario" />
                                        <asp:BoundField DataField="FechaDisponible" HeaderText="FechaDisponible" SortExpression="FechaDisponible" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                       
<<<<<<< HEAD
                                        <asp:CommandField ShowEditButton="True" />
=======
                                        <%--<asp:CommandField ShowSelectButton="true" ButtonType="Link" HeaderText="Asistio" />
                                        <asp:CommandField ShowSelectButton="true" ButtonType="Link" HeaderText="Falto" />--%>
                                        <asp:ButtonField CommandName="Asistio" HeaderText="Asistio" Text="Asistio" />
                                        <asp:ButtonField CommandName="Falto" HeaderText="Falto" Text="Falto" />
>>>>>>> refs/remotes/origin/master
                                    </Columns>
                                </asp:GridView>
                                <%--<asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:dbProyectoCoordinacion %>" SelectCommand="SELECT [IdCita], [IdUsuario], [FechaAgendada], [FechaDisponible], [Estado], [Comentario] FROM [tbCitas] WHERE (([IdUsuario] IS NOT NULL) AND ([Estado] = @Estado))">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="1" Name="Estado" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>--%>
                       
                        </div>
<<<<<<< HEAD
=======
    
    
    
    <style>
        #flotante
        {
	        position: absolute;
	        display:none;
	        font-family:Arial;
	        font-size:0.8em;
	        border:1px solid #808080;
	        background-color:#f1f1f1;
        }
    </style>
    
    <script type="text/javascript">
                $(document).ready(function () {
                   

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
                        eventClick: function (calEvent, jsEvent, view, date) {
                            
                            Update(calEvent.id, calEvent.title, calEvent.start);
                        },
                        eventMouseover(event, jsEvent, view) {
                            $("#flotante").html($(this).attr(event.title));

                            // Posicionamos el div flotante y mo lostramos

                            $("#flotante").css({ left: event.pageX + 5, top: event.pageY + 5, display: "block" });
                        }


                    });
                });
                function Update(id, numControl, date) {
                    var formattedDate = new Date(date);
                    var d = formattedDate.getDate();
                    var m = formattedDate.getMonth();
                    m += 1;  // JavaScript months are 0-11
                    var y = formattedDate.getFullYear();
                    var h = formattedDate.getHours();
                    var m = formattedDate.getMinutes();
                    var btn = "button";
                    
                    var xaccion = "";
                    swal({
                        title: "Cita del alumno " + numControl + " fecha: " + d + "-" + m + "-" + y +" hora: " + (h+7)+":"+m,
                        text: '<button type="' + btn + '" id="btnA" class="waves-effect light-green accent-4">Asistio</button> ' +
                              '<button type="' + btn + '" id="btnB" class="waves-effect orange darken-3">Falto</button> ' +
                              '<button type="' + btn + '" id="btnC" class="waves-effect waves-light">Exit</button>',
                        html: true,
                        showConfirmButton: false
                       
                    });
               
                        $(document).on('click', "#btnA", function() {
                            xaccion = "Asistio";
                            Actualiza();
                        });

                        $(document).on('click', "#btnB", function () {
                            xaccion = "Falto";
                            Actualiza();
                        });

                        $(document).on('click', "#btnC", function () {
                            xaccion = "Cancelar";
                        });
                       
                        
                        function Actualiza() {
                            var dataRow = {
                                'IdCita': id,
                                'Accion': xaccion
                            }
                            $.ajax({
                                type: 'POST',
                                url: "ActualizarCita.ashx",
                                data: dataRow,
                                dataType: "json",
                                success: function (response) {
                                    if (response == "1") {
                                        swal("Correcto!", "Se actualizo la cita", "success", location.reload());
                                        
                                    } else {
                                        swal("OPSSS!", "no se pudo actualizar la cita "+ dataRow.Accion + response , "error");
                                    }

                                },
                                error: function (response) {
                                    swal("OPSSS!", "Sucedio un error, intentalo de nuevo", "error");
                                }
                            });
                        }
                       


                }
             </script>
>>>>>>> refs/remotes/origin/master
    <div class="row">
        <div class="col s12 m4 l4 center center-align">
            <br />
        <asp:Button class="waves-effect waves-light btn orange"  ID="btnNuevaCita" runat="server" Text="Nueva Cita" OnClick="btnNuevaCita_Click"/>
        </div>
        <div class="col s12 m4 l4 center center-align">
            <br />
<<<<<<< HEAD
        <asp:Button class="waves-effect waves-light btn orange"  ID="btnElinarCitas" runat="server" Text="Eliminar" OnClick="btnElinarCitas_Click"/>                   
=======
        <%--<asp:Button class="waves-effect waves-light btn orange"  ID="btnElinarCitas" runat="server" Text="Eliminar" OnClick="btnElinarCitas_Click"/>--%>                   
>>>>>>> refs/remotes/origin/master
        </div>
    </div>
                        </asp:Content>
          
                



