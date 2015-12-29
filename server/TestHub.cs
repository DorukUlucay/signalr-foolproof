using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace signalr.server
{
    [HubName("MessagingHub")]
    public class MessagingHub : Hub
    {
        public void GetMessage(string message, string connectionId)
        {
            Console.WriteLine("Client says:{0}", message);
        }
    }
}