<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AgregarCita.aspx.cs" Inherits="AgregarCita" %>

              <asp:Content ID="Principal" ContentPlaceHolderID="CPHPrincipal" runat="server">

                  <script type="text/javascript">
                    $(document).ready(function () {
                        $('.datepicker').pickadate({
                            selectMonths: true, // Creates a dropdown to control month
                            selectYears: 15 // Creates a dropdown of 15 years to control year
                        });
                    });
                </script>

                 <div class="panel panel-default">
                        <div class="row left-align">
                         <h4>Agregar Cita</h4><br />
                        </div>
                        <div class="panel-body center center-align" style="margin-left:15%">
                            <div class="table-responsive">
                                <asp:TextBox ID="txtFecha" type="date" placeholder="Fecha Inicio" runat="server"></asp:TextBox>
                                <br />                                
                                 <div class="input-field col s6">
                                  <asp:TextBox ID="txtHora" runat="server" placeholder="Hora hh:mm" MaxLength="5" TextMode="Time"></asp:TextBox>
                                </div>
                                <br />

                                <asp:Button ID="btnAgregarCita" class="waves-effect waves-light btn orange" runat="server" Text="Agregar Cita" OnClick="btnAgregarCita_Click" />
                                <br />
                            </div>
                        </div>
                    </div>
                 <!-- /. ROW  -->
                <div class="container" >               
                    <div class="panel panel-default center center-align">
                        <div class="left-align row">
                            <br />
                            <h5>Generar Multiples Citas</h5>
                            <br />
                        </div>
                        <div class="panel-body center center-align" style="margin-left:15%">
                            <div class="table-responsive">
                                <div class="input-field col s6">
                                    <asp:Label ID="Label1" for="txtDias" runat="server">Dias</asp:Label>
                                    <asp:TextBox ID="txtDias" runat="server" TextMode="Number"></asp:TextBox>
                                    
                                </div>
                                
                            <div class="table-responsive">
                                <asp:Label ID="Label3" runat="server" Text="Hora Inicio"></asp:Label>
                                
                                <asp:TextBox ID="txtHora0" runat="server" placeholder="Hora hh:mm" MaxLength="5" TextMode="Time"></asp:TextBox>
                                
                                <asp:Label ID="Label4" runat="server" Text="Hora Fin"></asp:Label>
                                <asp:TextBox ID="txtHora1" runat="server" placeholder="Hora hh:mm" MaxLength="5" TextMode="Time" Type="time"></asp:TextBox>
                                <asp:Label ID="Label5" runat="server" Text="Intervalo"></asp:Label>
                                <asp:TextBox ID="txtIntervalo" runat="server" placeholder="Hora hh:mm" MaxLength="2" TextMode="Number">15</asp:TextBox>
                                
                                <asp:Button ID="btnGenerarCitas" class="waves-effect waves-light btn orange white-text" runat="server" Text="Generar Citas" OnClick="btnGenerarCitas_Click" />
                                <br />
                                
                            </div>
                            </div>
                        </div>
                        </div>
                     </div>
          </asp:Content>
       