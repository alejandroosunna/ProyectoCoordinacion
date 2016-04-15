<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Eliminar.aspx.cs" Inherits="Eliminar" %>

              
               <asp:Content ID="Principal" ContentPlaceHolderID="CPHPrincipal" runat="server">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                          Eliminar 
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">


                                <asp:GridView ID="GridView_Usuarios" runat="server" AutoGenerateColumns="False" DataKeyNames="IdUsuario" DataSourceID="SqlDataSource" OnRowCommand="GridView_Usuarios_RowCommand" OnSelectedIndexChanged="GridView_Usuarios_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" ReadOnly="True" SortExpression="IdUsuario" />
                                        <asp:BoundField DataField="IdCarrera" HeaderText="IdCarrera" SortExpression="IdCarrera" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                        <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
                                        <asp:BoundField DataField="Contraseña" HeaderText="Contraseña" SortExpression="Contraseña" />
                                        <asp:CommandField ShowSelectButton="true" ButtonType="Link" HeaderText="Eliminar" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:dbProyectoCoordinacion %>" SelectCommand="SELECT [IdUsuario], [IdCarrera], [Nombre], [Apellidos], [Contraseña] FROM [tbUsuarios] WHERE ([IdRol] = @IdRol)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="GridView_Usuarios" DefaultValue="2" Name="IdRol" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
          </asp:Content>
    