<%@ Page Language="C#" MasterPageFile="~/SAdminMaster.master" AutoEventWireup="true" CodeFile="IndexSAdmin.aspx.cs" Inherits="IndexSAdmin" %>

<asp:Content ID="CNTResumen" ContentPlaceHolderID="CPHPrincipal" runat="server"> 
    <div class="panel-heading section scrollspy">
                          Listado de citas pendientes
                        </div>
                        <br />
                        <input id="date-range-predefined" name="Fecha" type="date" class="h5a-input form-control"/>
                        Numero Control Coordinador: <asp:TextBox ID="txtNumControl" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnBuscar" class="waves-effect waves-light btn orange" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/>
                        <div class="panel-body scrolling-table-container">                           
                                <asp:GridView ID="GridView_Citas" class="table striped responsive-table" runat="server" AutoGenerateColumns="False" DataKeyNames="IdCita" OnRowCommand="GridView_Citas_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="IdCita" HeaderText="IdCita" InsertVisible="False" ReadOnly="True" SortExpression="IdCita" />
                                        <asp:BoundField DataField="Carrera" HeaderText="Carrera" InsertVisible="false" ReadOnly="true" SortExpression="Carrera"/>
                                        <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" SortExpression="IdUsuario" />
                                        <asp:BoundField DataField="FechaDisponible" HeaderText="FechaDisponible" SortExpression="FechaDisponible" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                       
                                        <%--<asp:CommandField ShowSelectButton="true" ButtonType="Link" HeaderText="Asistio" />
                                        <asp:CommandField ShowSelectButton="true" ButtonType="Link" HeaderText="Falto" />--%>
                                        <%--<asp:ButtonField CommandName="Asistio" HeaderText="Asistio" Text="Asistio" />
                                        <asp:ButtonField CommandName="Falto" HeaderText="Falto" Text="Falto" />--%>
                                    </Columns>
                                </asp:GridView>
                                <%--<asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:dbProyectoCoordinacion %>" SelectCommand="SELECT [IdCita], [IdUsuario], [FechaAgendada], [FechaDisponible], [Estado], [Comentario] FROM [tbCitas] WHERE (([IdUsuario] IS NOT NULL) AND ([Estado] = @Estado))">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="1" Name="Estado" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>--%>
                       
                        </div>

                        <div class="panel-body scrolling-table-container">                           
                                <asp:GridView ID="GridView_CountCitas" class="table striped responsive-table" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="Carrera" HeaderText="Carrera" InsertVisible="false" ReadOnly="true" SortExpression="Carrera"/>
                                        <asp:BoundField DataField="Numero de Citas" HeaderText="Numero de Citas" SortExpression="Numero de Citas" />
                                       
                                        <%--<asp:CommandField ShowSelectButton="true" ButtonType="Link" HeaderText="Asistio" />
                                        <asp:CommandField ShowSelectButton="true" ButtonType="Link" HeaderText="Falto" />--%>
                                        <%--<asp:ButtonField CommandName="Asistio" HeaderText="Asistio" Text="Asistio" />
                                        <asp:ButtonField CommandName="Falto" HeaderText="Falto" Text="Falto" />--%>
                                    </Columns>
                                </asp:GridView>
                                <%--<asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:dbProyectoCoordinacion %>" SelectCommand="SELECT [IdCita], [IdUsuario], [FechaAgendada], [FechaDisponible], [Estado], [Comentario] FROM [tbCitas] WHERE (([IdUsuario] IS NOT NULL) AND ([Estado] = @Estado))">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="1" Name="Estado" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>--%>
                       
                    </div>
</asp:Content>
