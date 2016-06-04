<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="IndexAdmin.aspx.cs" Inherits="IndexAdmin"  EnableEventValidation="false"%>
      

<asp:Content ID="CNTResumen" ContentPlaceHolderID="CPHPrincipal" runat="server"> 
            
                     
                       
    <div id="fullcalendar"></div>
    <br />
     Numero Control Alumno: <asp:TextBox ID="txtNumControl" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnBuscar" class="waves-effect waves-light btn orange" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/>
                        <div class="panel-body scrolling-table-container">                           
                                <asp:GridView ID="GridView_Citas" class="table striped responsive-table" runat="server" AutoGenerateColumns="False" DataKeyNames="IdCita" OnRowCommand="GridView_Citas_RowCommand" OnSelectedIndexChanged="GridView_Citas_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="IdCita" HeaderText="IdCita" InsertVisible="False" ReadOnly="True" SortExpression="IdCita" />
                                        <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" SortExpression="IdUsuario" />
                                        <asp:BoundField DataField="FechaDisponible" HeaderText="FechaDisponible" SortExpression="FechaDisponible" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                       
                                        <%--<asp:CommandField ShowSelectButton="true" ButtonType="Link" HeaderText="Asistio" />
                                        <asp:CommandField ShowSelectButton="true" ButtonType="Link" HeaderText="Falto" />--%>
                                        <asp:ButtonField CommandName="Asistio" HeaderText="Asistio" Text="Asistio" />
                                        <asp:ButtonField CommandName="Falto" HeaderText="Falto" Text="Falto" />
                                    </Columns>
                                </asp:GridView>
                                <%--<asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:dbProyectoCoordinacion %>" SelectCommand="SELECT [IdCita], [IdUsuario], [FechaAgendada], [FechaDisponible], [Estado], [Comentario] FROM [tbCitas] WHERE (([IdUsuario] IS NOT NULL) AND ([Estado] = @Estado))">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="1" Name="Estado" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>--%>
                       
                        </div>
    
    
    
    
    
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
                        eventClick: function (calEvent, jsEvent, view) {
                            Update(calEvent.id, calEvent.date);
                        }


                    });
                });
                function Update(id, date) {

                    
                    var xaccion = "";
                    swal({
                        title: "Quieres seleccionar esta cita?",
                        text: "Seleccionaras la cita" + id + "!",
                        type: "warning",
                        showCancelButton: true,
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: "Seleccionar!",
                        closeOnConfirm: false,
                        closeOnCancel: false
                    },
                    function (isConfirm) {
                        if (isConfirm) {
                            xaccion = "Asistio";
                        } else {
                            xaccion = "Falto";
                        }
                        var dataRow = {
                            'IdCita': id,
                            'Accion': xaccion
                        }
                      
                        $.ajax({
                            type: 'POST',
                            url: "GuardarCita.ashx",
                            data: dataRow,
                            dataType: "json",
                            success: function (response) {
                                if (response == "true") {
                                    swal("Correcto!", "Se actualizo la cita", "success");
                                    location.reload();
                                } else {
                                    
                                    swal("OPSSS!", "no se pudo actualizar la cita "+ id + xaccion, "error");
                                }

                            },
                            error: function (response) {
                                swal("OPSSS!", "Sucedio un error, intentalo de nuevo", "error");
                            }
                        });

                    });

                }
             </script>
    <div class="row">
        <div class="col s12 m4 l4 center center-align">
            <br />
        <asp:Button class="waves-effect waves-light btn orange"  ID="btnNuevaCita" runat="server" Text="Nueva Cita" OnClick="btnNuevaCita_Click"/>
        </div>
        <div class="col s12 m4 l4 center center-align">
            <br />
        <%--<asp:Button class="waves-effect waves-light btn orange"  ID="btnElinarCitas" runat="server" Text="Eliminar" OnClick="btnElinarCitas_Click"/>--%>                   
        </div>
    </div>
                        </asp:Content>
          
                



