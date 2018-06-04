using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using XamarinFormsStarterKit.UserInterfaceBuilder.Models;



namespace XamlSync.Hubs
{
	public class XamlPlaygroundSyncHub: Hub
    {
        

		public Task Broadcast(string sender, XamlPayload xamlPayload)
        {

		 

            return Clients
                // Do not Broadcast to Caller:
                .AllExcept(new[] { Context.ConnectionId })
                // Broadcast to all connected clients:
					.InvokeAsync("Broadcast", sender, xamlPayload);
        }
    }
}
