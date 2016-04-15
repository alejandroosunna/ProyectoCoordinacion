<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Agregar.aspx.cs" Inherits="Agregar" %>

                      <asp:Content ID="Principal" ContentPlaceHolderID="CPHPrincipal" runat="server">
              <div class="panel panel-default">
                        <div class="panel-heading">
                          Alumno
                        </div>
                        <div class="panel-body" >
                            <div class="table-responsive" style="margin-left:5%">
                                <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre"></asp:TextBox>
                                <br />
                                <br />

                                <asp:TextBox ID="txtApellidoPaterno" runat="server" placeholder="Apellido Paterno"></asp:TextBox>
                                <br />
                                <br />
                                <asp:TextBox ID="txtApellidoMaterno" runat="server" placeholder="Apellido Materno"></asp:TextBox>
                                <br />
                                <br />
                                <asp:TextBox ID="txtNumControl" runat="server" placeholder="Numero de Control" OnTextChanged="txtNumControl_TextChanged" AutoPostBack="True"></asp:TextBox>
                                <br />
                                <br />
                                <asp:TextBox ID="txtContraseña" runat="server" placeholder="Contraseña"></asp:TextBox>
                                <br />
                                
                               <div style="margin-left:20%;margin-top:3%;"> <asp:Button class="waves-effect waves-light btn orange white-text"  ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"  /> </div>
                            </div>
                        </div>
                    </div>
          </asp:Content>
       