<%@ Page Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="Citas.aspx.cs" Inherits="Citas" %>
<asp:Content ID="Principal" ContentPlaceHolderID="CPHPrincipal" runat="server">
   
   <script type="text/javascript">

        function getDetails() {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Citas.aspx/GetData",
                data: {},
                datatype: "json",
                success: function (data) {
                    $('#tableCitas tbody').remove();
                    for (var i = 0; i < data.d.length; i++)
                    {
                        $('#tableCitas').append(
                            "<tr><td>" + data.d[i].idCita + "</td><td>" + "<td>" + data.d[i].idUsuario + "</td><td>" +
                            "<td>" + data.d[i].FechaAgendada + "</td><td>" + "<td>" + data.d[i].FechaDisponible + "</td><td>" +
                            "<td>" + data.d[i].Estado + "</td><td>" + "<td>" + data.d[i].Comentario + "</td>" +
                            "<td>" + "<input type='button' class='btn editButtnon' data-id='" + data.d[i].idCita + "' data-toggle='modal' data-target='#myModal' name='submitButton' id='btnEdit' value='Edit' />" + "</td>" +
                                "<td><input type='button' class='btn deleteButton' name='submitButton' id='btnDelete' value='Delete'/> </td></tr>");
                            
                    }
                }, error: function () {
                    alert("Ocurrio un error");
                }

            });
        }
        $(document).ready(function () {
            $('.datepicker').pickadate({
                selectMonths: true, // Creates a dropdown to control month
                selectYears: 15 // Creates a dropdown of 15 years to control year
            });
            
        });
        $(document).on("click", ".editButton", function () {
            
            $('#myModal').openModal();

            var id = $(this).attr("data-id");
            console.log(id);
            $('#btnUpdate').attr("itemid", id);

            $.ajax({
                type: "Post",
                contentType: "application/json; charset=utf-8",
                url: "Citas.aspx/EditCita",
                data: '{cid: ' + id + '}',
                dataType: 'json',
                success: function (data) {
                    console.log("Hasta aqui va bien");
                    var citaDetails = $.parseJSON(data.d);
                    console.log(citaDetails);
                    
                        
                        $("#idCita1").val(citaDetails.id);
                        $("#idUsuario1").val(citaDetails.idUsuario);
                        $("#fechaDisponible1").val(citaDetails.fechaDisponible);
                        $("#estado1").val(citaDetails.estado);
                        $("#comentario1").val(citaDetails.comentario);
                   
                },
                error: function () {
                    alert("Ocurrio algún error en + " + id);
                }
            });
            
        });
        $(document).on("click", "#btnUpdate", function () {
           
            var id = $(this).attr("itemid");
           
            var cita = {};
            cita.id = $("#idCita1").val();
            cita.idUsuario = $("#idUsuario1").val();
            cita.fechaDisponible = $("#fechaDisponible1").val();
            cita.estado = $("#estado1").val();
            cita.comentario = $("#comentario1").val();
            console.log(cita);
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Cita.aspx/UpdateData",
                data: '{cita: ' + JSON.stringify(cita) + ', cid: ' + id + '}',
                dataType: "json",
                success: function (data) {
                    if (confirm("Seguro que desea modificar la cita? ") == true) {
                        alert("Tu cita se a cambiado exitosamente!");
                    } else {
                        alert("Tu cancelaste los cambios");
                    }
                    getDetails();
                },
                error: function (data) {
                    alert("Error al actualizar los datos en: " + id);
                }
            });
        });
        $(document).on("click", ".deleteButton", function () {
            var id = $(this).attr("data-id");
            
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Citas.aspx/RemoveCita",
                data: '{cid: ' + id + '}',
                dataType: "json",
                success: function () {
                    if (confirm("Estas seguro que deseas eliminar la cita?") == true) {
                        alert("Cita Eliminada Exitosamente!");
                        window.location.reload();
                        
                    } else {
                        alert("Cancelaste la cita");
                    }
                   
                },
                error: function (data) {
                    alert("Ocurrio un error en la cita : " + id);
                }
            });
        });

    </script>
        <!-- Modal para editas Citas -->
        <div id="myModal" class="modal"  >
            <div class="modal-content">

                <div class="input-field col s6">
                  <input disabled  placeholder="Placeholder" id="idCita1" type="number" class="validate"/>
                  <label for="idCita1">id Cita</label>
                </div>
                
                <div class="input-field col s6">
                  <input placeholder="numero de control" id="idUsuario1" type="number" class="validate"/>
                  <label for="idUsuario1">Numero de control</label>
                </div>      

                <div class="input-field col s6">
                  <label for="fechaDisponible1">fecha Disponible</label><br />
                  <input id="fechaDisponible1" type="text" class="validate"/>
                </div>  
    
                <div class="input-field col s6">
                        <input id="comentario1" type="text" class="materialize-textarea"/>
                        <label for="comentario1">comentario</label>
                    </div>
                <div class="input-field col s6">
                    <input id="estado1" type="number" class="validate" />
                    <label for="estado1">Estado</label>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" id="btnUpdate" class="btn" itemid="" data-dismiss="modal"> Guardar </button>
            </div>
            
        </div>

       <!-- Tabla que muestra las citas -->
        <table id="tableCitas" class="table-of-contents" role="grid" aria-describedby="tablaCitas">
            <thead>
                <tr role="row">
                    <th tabindex="0" aria-controls="tableCitas" rowspan="1" colspan="1" aria-sort="ascending" 
                        aria-label="Rendering engine: active to sort column descending">id Cita</th>
                    <th tabindex="0" aria-controls="tableCitas" rowspan="1" colspan="1" aria-sort="ascending" 
                        aria-label="Browser engine: active to sort column descending">id Usuario</th>
                    <th tabindex="0" aria-controls="tableCitas" rowspan="1" colspan="1" aria-sort="ascending" 
                        aria-label="Platform(s): active to sort column descending">Fecha Agendad</th>
                    <th tabindex="0" aria-controls="tableCitas" rowspan="1" colspan="1" aria-sort="ascending" 
                        aria-label="Engine version: active to sort column descending">Fecha Disponible</th>
                    <th tabindex="0" aria-controls="tableCitas" rowspan="1" colspan="1" aria-sort="ascending" 
                        aria-label="CSS grade: active to sort column ascending">Estado</th>
                    <th tabindex="0" aria-controls="tableCitas" rowspan="1" colspan="1" aria-sort="ascending" 
                        aria-label="CSS grade: active to sort column ascending">Comentario</th>
                    <th tabindex="0" aria-controls="tableCitas" rowspan="1" colspan="2" aria-sort="ascending" 
                        aria-label="CSS grade: active to sort column ascending">Acciones</th>
                </tr>
            </thead>
            <tbody>
            
                <%for (var data = 0; data < TableData.Rows.Count; data++)  { %>
                    <tr class="" role="row">
                        <td><%=TableData.Rows[data]["idCita"]%></td>
                        <td><%=TableData.Rows[data]["idUsuario"]%></td>
                        <td><%=TableData.Rows[data]["FechaAgendada"]%></td>
                        <td><%=TableData.Rows[data]["FechaDisponible"]%></td>
                        <td><%=TableData.Rows[data]["Estado"]%></td>
                        <td><%=TableData.Rows[data]["Comentario"]%></td>
                        <td><input type="button" class="btn btn-flat editButton" data-id="<%=TableData.Rows[data]["idCita"]%>"
                            data-toggle="modal" data-target="#myModal" name="submitButton" id="btnEdit" value="Editar"/></td>
                        <td><input type="button" class="btn btn-flat deleteButton" data-id="<%=TableData.Rows[data]["idCita"]%>" 
                            name="submitButton" id="btnDelete" value="Eliminar"/></td>
                    </tr>
                <%} %>
            </tbody>
        </table>
   
</asp:Content> 