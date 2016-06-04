<%@ Page Title="" Language="C#" MasterPageFile="~/SAdminMaster.master" AutoEventWireup="true" CodeFile="ConfigurarLogIn.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHPrincipal" Runat="Server">
    <asp:ScriptManager ID="scriptMan" runat="server"></asp:ScriptManager>
    <div class="container">
        <asp:UpdateProgress ID="upProgress" runat="server" AssociatedUpdatePanelID="upSubir">
                        <ProgressTemplate>
                            <div class="progress center">
                                <div class="indeterminate"></div>
                                </div>
                            </div>
                        </ProgressTemplate>
        </asp:UpdateProgress>
                <div class="row">
                    <div class="col s12 m12 l6 offset-l3">
                        <div class="row left">
                            <span class="mdl-typography--font-bold big">Subir Archivo: </span>
                            <asp:FileUpload ID="fupArchivo" CssClass="file-path" runat="server" />

                        </div>
                        <div class="row center">
                            <asp:Button ID="btnSubir" Text="Subir" CssClass="btn orange white-text" OnClick="btnSubir_Click" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col s12 m12 l4">
                        <div class="card-panel green darken-2 white-text center" style="height:250px;">
                            <span class="card-title">Imagenes del Servidor</span><br />
                            <div class=" card-content s12 m12 l12 center">
                                            <div class="input-field white-text">
                                                <select id="dropImgServer" runat="server"></select>
                                                <label>Selecciona Imagen</label>
                                            </div>
                                        </div><br /><br />
                            <asp:Button ID="btnSelectImg" OnClick="btnSelectImg_Click" CssClass="btn orange white-text" runat="server" Text="Vista Previa" /><br /><br />
                            <asp:Button ID="btnDelete" OnClick="btnDelete_Click" CssClass="btn red darken-2 white-text" runat="server" Text="Eliminar" /><br /><br />
                        </div>
                    </div>                    
                            <div class="col s12 m12 l8">
                                <div class="card">
                                    <div class="card-image">
                                        <asp:UpdatePanel ID="upSubir" runat="server">
                                        <ContentTemplate>
                                        <img src="logo_ith-bien.png" id="VistaPrevia" runat="server" />
                                            </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnSelectImg" EventName="Click" />
                                        </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="card-content">
                                        <div class="row">
                                            <span class="card-title" id="tituloImg" runat="server">Vista Previa</span>
                                        </div>
                                            <div class="row">
                                                <div class="col s12 m12 l4">
                                                    <asp:Button ID="btnOp1" CssClass="btn orange white-text col s11 m11 l11" runat="server" Text="Poner en Opcion 1" OnClick="btnOp1_Click" />
                                                </div>
                                                <div class="col s12 m12 l4">
                                                    <asp:Button ID="btbOp2" CssClass="btn orange white-text col s11 m11 l11" runat="server" Text="Poner en Opcion 2" OnClick="btbOp2_Click" />
                                                </div>
                                                <div class="col s12 m12 l4">
                                                    <asp:Button ID="btnOp3" CssClass="btn orange white-text col s11 m11 l11" runat="server" Text="Poner en Opcion 3" OnClick="btnOp3_Click" />
                                                </div>
                                            </div>
                                    </div>
                                </div>
                            </div>                     
                </div>            
 </div>
    <script type="text/javascript" lang="javascript">
        $(document).ready(function () {
            $('select').material_select();
        });
    </script>
    <script type="text/javascript" lang="javascript">
        $('select').material_select('update');
    </script>
</asp:Content>

