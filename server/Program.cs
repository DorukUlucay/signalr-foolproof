using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;

namespace signalr.server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string url = @"http://localhost:11223/";
            //here we start a server with config info in Startup class and url above
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Server running at {0}", url);

                //what we do here is simply take all input and
                while (true)
                {
                    string userInput = Console.ReadLine();

                    //exit app if user writes exit
                    if (userInput == "exit")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        //or push it to all clients via method PublishMessage, which is handled in client
                        var hub = GlobalHost.ConnectionManager.GetHubContext<MessagingHub>();
                        hub.Clients.All.PublishMessage(string.Format(@"Hub Says: {0}", userInput));
                    }
                }
            }
        }
    }
}