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
                                    </div>
                                </div>
                            </div>                     
                </div>
        <div class="row">
            <h2 class="center-align">Editar Noticias</h2>
            <div class="col s12 m12 l6">
                <h4 class="center-align">Agregar</h4>
                <div class="row">
                    <h6 class="center-align">Titulo:</h6>
                    <div class="input-field col s12 m12 l8 offset-l2">
                        <asp:TextBox ID="txttitulo" runat="server"></asp:TextBox>
                    </div>                    
                </div>
                <div class="row">
                    <h6 class="center-align">Cuerpo:</h6>
                    <div class="input-field col s12 m12 l8 offset-l2">
                        <asp:TextBox ID="txtCuerpo" TextMode="MultiLine" Rows="8" runat="server"></asp:TextBox>
                    </div><br />
                </div>
                <div class="row center">
                    <asp:Button ID="btnAgregar" CssClass="btn orange white-text center" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                </div>
            </div>
            <div class="col s12 m12 l6">
                <div class="row center">
                    <h4 class="center-align">Eliminar</h4>
                    <div class="input-field col s12 m12 l8 offset-l2">
                        <asp:DropDownList ID="dropFiles" CssClass="browser-default"  runat="server"></asp:DropDownList>
                    </div>                    
                </div>
                <div class="row center">
                        <asp:Button ID="btnVistaNoticia" CssClass="btn green darken-2 white-text" runat="server" Text="Vista Previa" OnClick="btnVistaNoticia_Click" />
                    </div>
                <div class="row center">
                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="panelNoticia" runat="server">
                        <ProgressTemplate>
                            <div class="preloader-wrapper big active">
                            <div class="spinner-layer spinner-blue">
                                <div class="circle-clipper left">
                                    <div class="circle"></div>
                                </div><div class="gap-patch">
                                    <div class="circle"></div>
                                </div><div class="circle-clipper right">
                                    <div class="circle"></div>
                                </div>
                            </div>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:UpdatePanel ID="panelNoticia" runat="server">
                        <ContentTemplate>
                            <h5 class="center" runat="server" id="tituloSpan"></h5><br />
                            <p class="center" runat="server" id="Cuerpo"></p>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnVistaNoticia" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="row center">
                    <asp:Button ID="btnEliminarNoticia" CssClass="btn red darken-3 white-text" runat="server" Text="Eliminar" OnClick="btnEliminarNoticia_Click" />
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

