using System;
using Microsoft.AspNet.SignalR.Client;

namespace signalr.client
{
    class Program
    {
        static void Main(string[] args)
        {
            // in here we create a connection and a proxy for the hub we wan to be a member of
            string url = @"http://localhost:11223/";
            var connection = new HubConnection(url);
            IHubProxy _hub = connection.CreateHubProxy("MessagingHub");

            //in here, we specify what to do when hub wants to invoke a method named PublishMessage
            _hub.On("PublishMessage", x => Console.WriteLine(x));

            //we start the connection
            connection.Start().Wait();
            string _welcomeMessage = string.Format("connected to {0} as {1}", url, connection.ConnectionId);
            Console.WriteLine(_welcomeMessage);

            //in this block, anything we write goes and invokes hub method named GetMessage
            string line = null;
            while ((line = Console.ReadLine()) != null)
            {
                _hub.Invoke("GetMessage", line, connection.ConnectionId).Wait();
            }
        }
    }
}
