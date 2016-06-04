<%@ Page Language="C#" MasterPageFile="~/SAdminMaster.master" AutoEventWireup="true" CodeFile="Coordinador.aspx.cs" Inherits="Coordinador"  EnableEventValidation="false"%>

<asp:Content ID="CNTResumen" ContentPlaceHolderID="CPHPrincipal" runat="server"> 
    <div class="panel-heading section scrollspy">
                          Agregar Coordinador
                        </div>
                        <br />
                        Nombre(s): <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        <br />
                        Apellidos: <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>
                        <br />
                        Carrera: 
                            <div class="row container">
                                <div class="input-field col s12">
                                    <select id="carreraDrop" runat="server">
                                    </select>
                                    <label>Selecciona Carrera</label>
                                  </div>
                            </div>                    
    <br />
                        Numero Control: <asp:TextBox ID="txtNumControl" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnAgregar" CssClass="waves-effect waves-light btn orange" runat="server" Text="Agregar" OnClick="btnAgregar_Click"/>

    <br />
    <br />

    Coordinadores:
    <br />
                        <%--<asp:Button ID="btnBuscar" class="waves-effect waves-light btn orange" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/>--%>
                        <div class="panel-body scrolling-table-container">                           
                                <asp:GridView ID="GridView_Coordinadores" class="table striped responsive-table" runat="server" AutoGenerateColumns="False" DataKeyNames="IdUsuario" OnRowCommand="GridView_Coordinadores_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" InsertVisible="False" ReadOnly="True" SortExpression="IdUsuario" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" InsertVisible="false" ReadOnly="true" SortExpression="Nombre"/>
                                        <asp:BoundField DataField="Carrera" HeaderText="Carrera" SortExpression="Carrera" />
                                        <asp:BoundField DataField="Contraseña" HeaderText="Contraseña" SortExpression="Contraseña" />
                                        
                                        <asp:ButtonField CommandName="Editar" HeaderText="Editar" Text="Editar" />
                                        <asp:ButtonField CommandName="Eliminar" HeaderText="Eliminar" Text="Eliminar" />
                                    </Columns>
                                </asp:GridView>
                       
                        </div>

    <div>
             <asp:SqlDataSource ID="SqlDataDropDListCarrera" runat="server" ConnectionString="<%$ ConnectionStrings:dbProyectoCoordinacion %>" SelectCommand="SELECT * FROM [tbCarreras]">
                            <%--<SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="IdCarrera" SessionField="IdCarrera" Type="Int32" />
                            </SelectParameters>--%>
                </asp:SqlDataSource>
	</div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('select').material_select();
        });
    </script>
</asp:Content>