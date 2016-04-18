﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chat.aspx.cs" Inherits="Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link type="text/css" rel="stylesheet" href="themes/css/ChatStyle.css" />
    <link type="text/css" rel="stylesheet" href="themes/css/bootstrap.css" />
    <link rel="stylesheet" href="themes/Css/JQueryUI/themes/base/jquery.ui.all.css" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>

    <!--Script references. -->
    <!--Reference the jQuery library. -->
    <script src="Scripts/jquery-2.2.0.min.js"></script>

    <script src="Scripts/jquery.ui.core.js"></script>
    <script src="Scripts/jquery.ui.widget.js"></script>
    <script src="Scripts/jquery.ui.mouse.js"></script>
    <script src="Scripts/jquery.ui.draggable.js"></script>
    <script src="Scripts/jquery.ui.resizable.js"></script>

    <!--Reference the SignalR library. -->
    <script src="Scripts/jquery.signalR-1.0.1.js"></script>

    <!--Reference the autogenerated SignalR hub script. -->
    <script src="signalr/hubs"></script>
    
    <script type="text/javascript">
        
        var audioElement = document.createElement('audio');
        audioElement.setAttribute('src', 'audio/chat.mp3');
        $(function () {

            $("#resizable").resizable();

        });



        $(function () {

            setScreen(false);

            // Declare a proxy to reference the hub. 
            var chatHub = $.connection.chatHub;
          
            registerClientMethods(chatHub);

            // Start Hub
            $.connection.hub.start().done(function () {

                registerEvents(chatHub)

            });

        });

        function setScreen(isLogin) {

            if (!isLogin) {

                $("#divChat").hide();
                $("#divLogin").show();
            }
            else {

                $("#divChat").show();
                $("#divLogin").hide();
            }

        }
        function getUser(id) {
            $.ajax({
                type: "Post",
                contentType: "application/json; charset=utf-8",
                url: "Chat.aspx/ObtenerUsuario",
                data: '{usu: ' + id + '}',
                dataType: 'json',
                success: function (data) {
                    var user = $.parseJSON(data.d);
                    $("#txtNickName").val(user);
                    
                },
                error: function () {
                    alert("Ocurrio algún error ");
                }
            });
        }
        
        function registerEvents(chatHub) {
            getUser(<%=Server.HtmlEncode(Session["IdUsuario"].ToString())%>);
            $("#txtNickName").val();
            $("#btnStartChat").click(function () {
               
                var name = $("#txtNickName").val();
                if (name.length > 0) {

                    
                    chatHub.server.connect(name);
                    
                }
                else {
                    alert("Por favor ingresa tu nombre");
                }

            });


            $('#btnSendMsg').click(function () {

                var msg = $("#txtMessage").val();
                if (msg.length > 0) {

                    var userName = $('#hdUserName').val();
                    chatHub.server.sendMessageToAll(userName, msg);
                    $("#txtMessage").val('');
                }
            });


            $("#txtNickName").keypress(function (e) {
                if (e.which == 13) {
                    $("#btnStartChat").click();
                }
            });

            $("#txtMessage").keypress(function (e) {
                if (e.which == 13) {
                    $('#btnSendMsg').click();
                }
            });

        }

        function registerClientMethods(chatHub) {

            // Calls when user successfully logged in
            chatHub.client.onConnected = function (id, userName, allUsers, messages) {

                setScreen(true);

                $('#hdId').val(id);
                $('#hdUserName').val(userName);
                $('#spanUser').html(userName);
                // Add All Users
                for (i = 0; i < allUsers.length; i++) {
                    
                    AddUser(chatHub, allUsers[i].ConnectionId, allUsers[i].UserName);
                }

                // Add Existing Messages
                for (i = 0; i < messages.length; i++) {

                    AddMessage(messages[i].UserName, messages[i].Message);
                }


            }

            // On New User Connected
            chatHub.client.onNewUserConnected = function (id, name) {

                AddUser(chatHub, id, name);
            }


            // On User Disconnected
            chatHub.client.onUserDisconnected = function (id, userName) {

                $('#' + id).remove();

                var ctrId = 'private_' + id;
                $('#' + ctrId).remove();


                var disc = $('<div class="disconnect">"' + userName + '" se desconecto.</div>');

                $(disc).hide();
                $('#divusers').prepend(disc);
                $(disc).fadeIn(200).delay(2000).fadeOut(200);

            }

            chatHub.client.messageReceived = function (userName, message) {

                AddMessage(userName, message);
            }


            chatHub.client.sendPrivateMessage = function (windowId, fromUserName, message) {

                var ctrId = 'private_' + windowId;


                if ($('#' + ctrId).length == 0) {

                    createPrivateChatWindow(chatHub, windowId, ctrId, fromUserName);

                }
                
                $('#' + ctrId).find('#divMessage').append('<div class="media-body"> <div class="media"><div class="media-body">' + message + '<br/> <small class="text-muted">' + fromUserName + '</small></div></div></div><br/>');
                $('#' + ctrId).find('.header').removeClass("read").addClass("unread");
                $(document).attr('title', fromUserName);
                audioElement.play();
              
                
                
                // set scrollbar
                var height = $('#' + ctrId).find('#divMessage')[0].scrollHeight;
                $('#' + ctrId).find('#divMessage').scrollTop(height);

            }

        }
        function AddUser(chatHub, id, name) {

            var userId = $('#hdId').val();
           
            var code = "";

            if (userId == id) {

                code = $('<div class="loginUser">' + name + "</div>");

            }
            else {

                code = $('<a id="' + id + '" class="user" >' + name + '<a>');
                
                $(code).click(function () {

                    var id = $(this).attr('id');

                    if (userId != id)
                        OpenPrivateChatWindow(chatHub, id, name);

                });
            }

            $("#divusers").append(code);
            
        }

        function AddMessage(userName, message) {


            $('#divChatWindow').append('<div class="media-body"> <div class="media"><div class="media-body">' + message + '<br/> <small class="text-muted">' + userName + '</small></div></div></div><br/>');

            var height = $('#divChatWindow')[0].scrollHeight;
            $('#divChatWindow').scrollTop(height);
        }

        function OpenPrivateChatWindow(chatHub, id, userName) {

            var ctrId = 'private_' + id;

            if ($('#' + ctrId).length > 0) return;

            createPrivateChatWindow(chatHub, id, ctrId, userName);

        }

        function createPrivateChatWindow(chatHub, userId, ctrId, userName) {

            var div = '<div id="' + ctrId + '" class="ui-widget-content draggable resizable" rel="0">' +
                       '<div class="header">' +
                              '<div  style="float:right;">' +
                              '<img id="imgDelete"  style="cursor:pointer;" src="/Img/delete.png"/>' +
                              '<img id="imgMini" style="cursor:pointer;" class="ui-icon ui-icon-minus"/>'+
                           '</div>' +
                           '<i class="material-icons">account_circle</i>'+
                           '<span class="selText" rel="0">' + userName + '</span>' +
                       '</div>' +
                       '<div  class="panel-body">' +
                       '<ul id="divMessage" class="media-list" style="height: 150px; overflow-y: scroll;" >' +
                    
                       '</ul>'+
                       '</div>' +
                       '<div class="buttonBar">' +
                          '<input id="txtPrivateMessage" class="msgText" type="text"   />' +
                          '<input id="btnSendMessage" class=" btn btn-warning" type="button" value="Enviar"   />' +
                       '</div>' +
                    '</div>';

            var $div = $(div);

            $div.find('.header').click(function () {
                readd();
            });
            // DELETE BUTTON IMAGE
            $div.find('#imgDelete').click(function () {
                $('#' + ctrId).remove();
            });
            $(function () {

                $div.find('#imgMini').click(function () {
                    $('#' + ctrId).accordion({
                        collapsible: true
                    });
                });

            });


           
            function readd() {
                $('#' + ctrId).find('.header').removeClass("unread").addClass("read");
                $(document).attr('title', "Chat");
            };
            // Send Button event
            $div.find("#btnSendMessage").click(function () {
                
                $textBox = $div.find("#txtPrivateMessage");
                var msg = $textBox.val();
                if (msg.length > 0) {
                    
                    chatHub.server.sendPrivateMessage(userId, msg);
                    $('#' + ctrId).find('.header').removeClass("unread").addClass("read");
                    $textBox.val('');
                }
            });

            // Text Box event
            $div.find("#txtPrivateMessage").keypress(function (e) {
                if (e.which == 13) {
                    $div.find("#btnSendMessage").click();
                   
                }
            });

            $div.find("#txtPrivateMessage").click(function () {
                readd();
            });

            AddDivToContainer($div);

        }
     
        function AddDivToContainer($div) {
            $('#divContainer').prepend($div);

            $div.draggable({

                
                stop: function () {

                }
            });

            //$div.resizable({

            //    stop: function () {

            //    }
            //});

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div id="header">
        Sala de Chat
    </div>
    <div id="divContainer" class="container-fluid ">
        <div id="divLogin" class="login">
            <div>
                Tu nombre:<br />
            <input disabled id="txtNickName" type="text" class="textBox" />
            </div>
            <div id="divButton">
                <input id="btnStartChat" type="button" class="submitButton" value="Iniciar Chat" />
            </div>
        </div>
        <div id="divChat" class="row " style="padding-top:40px;">
            <h3>Sala de Chat Coordinación</h3>
            <br />
            <br />
            <div class="col-md-8 chatRoom">
            <div class="panel panel-info">
                <div class="panel-heading" style="background-color:darkorange">Chat de Todos  Bienvenido [<span id='spanUser'></span>]</div>
                <div class="panel-body">
                    <ul id="divChatWindow" class="media-list" style="height: 300px;
	                overflow-y: scroll;" >
                    
                    </ul>
                </div>
                <div class="panel-footer">
                    <div class="input-group">
                        <input id="txtMessage" class="form-control" type="text" placeholder="Ingrese mensaje" />
                        <span class="input-group-btn">
                            <button id="btnSendMsg" class="btn btn-warning" type="button">Enviar</button>
                        </span>
                    </div>
                </div>

            </div>
            <input id="hdId" type="hidden" />
            <input id="hdUserName" type="hidden" />
        </div>
        <div class="col-md-4">
            <div class="panel panel-primary">
                <div class="panel-heading" style="background-color:darkorange"> Usuarios Online</div>
                <div id="divusers" class="panel-body " style="cursor: pointer;display: block;">         
            </div>
            </div>
        </div>
        </div>   
    </div>
    </form>
</body>
</html>
