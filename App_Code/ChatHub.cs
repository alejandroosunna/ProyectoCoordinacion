using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace SIAC
{
    public class ChatHub : Hub
    {

        static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        static List<MessageDetail> CurrentMessage = new List<MessageDetail>();

        public void Connect(string userName)
        {
            var id = Context.ConnectionId;

            var item = ConnectedUsers.FirstOrDefault(x => x.UserName == userName);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                Clients.All.onUserDisconnected(item.ConnectionId, item.UserName);

            }

            if (ConnectedUsers.Count(x=>x.UserName == userName) ==0)
            {
                ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserName = userName, idCarrera = userName.Split(' ')[0] });

                // send to caller
                Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);

                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, userName, ConnectedUsers.Find(x=> x.UserName == userName).idCarrera);

            }
           
           
            


        }

        public void SendMessageToAll(string userName, string message, string idcarrera)
        {
            var id = Context.ConnectionId;
            if(ConnectedUsers.Count(x=> x.ConnectionId == id) == 1)
            {
                // store last 100 messages in cache
                AddMessageinCache(userName, message, idcarrera);

                // Broad cast message
                Clients.All.messageReceived(userName, message, idcarrera);
            }
          
          
        }

        public void SendPrivateMessage(string toUserId, string message)
        {

            string fromUserId = Context.ConnectionId;

            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

            if (toUser != null && fromUser != null)
            {
                // send to 
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);
            }

        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);

            }else
            {
                Connect(item.UserName);
            }


            return base.OnDisconnected(stopCalled);
        }


        #region private Messages

        private void AddMessageinCache(string userName, string message, string idcarrera)
        {
            CurrentMessage.Add(new MessageDetail { UserName = userName, Message = message, idCarrera= idcarrera });

            if (CurrentMessage.Count > 100)
                CurrentMessage.RemoveAt(0);
        }

        #endregion
    }
}

