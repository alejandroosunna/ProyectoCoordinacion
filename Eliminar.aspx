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
<<<<<<< HEAD
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
=======
                                        <asp:CommandField ShowDeleteButton="True" />
                                        <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" ReadOnly="True" SortExpression="IdUsuario" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                        <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
                                        <asp:BoundField DataField="IdCarrera" HeaderText="IdCarrera" SortExpression="IdCarrera" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:dbProyectoCoordinacion %>" SelectCommand="SELECT [IdUsuario], [Nombre], [Apellidos], [IdCarrera] FROM [tbUsuarios] WHERE (([IdCarrera] = @IdCarrera) AND ([IdRol] = @IdRol))" DeleteCommand="DELETE FROM [tbUsuarios] WHERE [IdUsuario] = @IdUsuario" InsertCommand="INSERT INTO [tbUsuarios] ([IdUsuario], [Nombre], [Apellidos], [IdCarrera]) VALUES (@IdUsuario, @Nombre, @Apellidos, @IdCarrera)" UpdateCommand="UPDATE [tbUsuarios] SET [Nombre] = @Nombre, [Apellidos] = @Apellidos, [IdCarrera] = @IdCarrera WHERE [IdUsuario] = @IdUsuario">
                                    <DeleteParameters>
                                        <asp:Parameter Name="IdUsuario" Type="Int32" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="IdUsuario" Type="Int32" />
                                        <asp:Parameter Name="Nombre" Type="String" />
                                        <asp:Parameter Name="Apellidos" Type="String" />
                                        <asp:Parameter Name="IdCarrera" Type="Int32" />
                                    </InsertParameters>
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="IdCarrera" SessionField="IdCarrera" Type="Int32" />
                                        <asp:Parameter DefaultValue="2" Name="IdRol" Type="Int32" />
                                    </SelectParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="Nombre" Type="String" />
                                        <asp:Parameter Name="Apellidos" Type="String" />
                                        <asp:Parameter Name="IdCarrera" Type="Int32" />
                                        <asp:Parameter Name="IdUsuario" Type="Int32" />
                                    </UpdateParameters>
>>>>>>> refs/remotes/origin/master
                                </asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
<<<<<<< HEAD
=======
                    <asp:Button ID="EliminaT" runat="server" OnClick="EliminaT_Click" class="waves-effect waves-light btn orange white-text" Text="Eliminar todos" />
>>>>>>> refs/remotes/origin/master
          </asp:Content>
    