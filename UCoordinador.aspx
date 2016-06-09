<%@ Page Language="C#" MasterPageFile="~/SAdminMaster.master" AutoEventWireup="true" CodeFile="UCoordinador.aspx.cs" Inherits="UCoordinador"  EnableEventValidation="false" %>

<asp:Content ID="CNTResumen" ContentPlaceHolderID="CPHPrincipal" runat="server"> 
    <div class="panel-heading section scrollspy">
                          Agregar Coordinador
                        </div>
                        <br />
                        Nombre(s): <asp:TextBox ID="txtNombre" runat="server" Text=""></asp:TextBox>
                        <br />
                        Apellidos: <asp:TextBox ID="txtApellidos" runat="server" Text=""></asp:TextBox>
                        <br />
                        <%--Carrera: <asp:DropDownList runat="server" ID="DropDListCarrera" DataSourceID="SqlDataDropDListCarrera" DataValueField="IdCarrera" DataTextField="Nombre" CssClass="materialboxed input-field orange white-text"></asp:DropDownList>
                        <br />--%>
                        Numero Control: <asp:TextBox ID="txtNumControl" runat="server"></asp:TextBox>
                        <br />
                        Contraseña: <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnEditar" CssClass="waves-effect waves-light btn orange" runat="server" Text="Editar" OnClick="btnEditar_Click"/>

    <br />
    <br />

    <div>
             <asp:SqlDataSource ID="SqlDataDropDListCarrera" runat="server" ConnectionString="<%$ ConnectionStrings:dbProyectoCoordinacion %>" SelectCommand="SELECT * FROM [tbCarreras]">
                            <%--<SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="IdCarrera" SessionField="IdCarrera" Type="Int32" />
                            </SelectParameters>--%>
                </asp:SqlDataSource>
	</div>
</asp:Content>