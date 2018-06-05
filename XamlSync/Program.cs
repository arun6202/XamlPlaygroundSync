using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using XamarinFormsStarterKit.UserInterfaceBuilder.Models;
using XamlSync.Controllers;
using XamlSync.Hubs;

namespace XamlSync
{
	public class Program
	{
		private const string Url = "http://localhost:6202";


		public static IHubContext<XamlSyncHub> HubContext;


		public static async Task Main(string[] args)
		{
			await UpdateSimulatorsAsync(args);
			await CreateWebHostBuilder(args).Build().RunAsync();

		}



		private static Task UpdateSimulatorsAsync(string[] args)
		{

			var task = Task.Factory.StartNew(async () =>
		   {
			   try
			   {
				   while (true)
				   {
					   await Task.Delay(TimeSpan.FromSeconds(1));

					   if (HubContext != null)
					   {
							await HubContext.Clients.All.SendAsync("XamlPlaygroundSync", "UpdateSimulatorsAsync", XamlPlaygroundSyncController.XamlPayload);

					   }

				   }
			   }
			   catch (Exception ex)
			   {
				   Console.WriteLine($"Broadcast Halted!{ex.ToString()}");
			   }
		   });

			return task;
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseConfiguration(new ConfigurationBuilder()
				.AddCommandLine(args)
				.Build())
		           .UseUrls(Url)
				.UseKestrel()
				   .ConfigureLogging(factory =>
				   {
					   factory.AddConsole();
				   })
				   .UseEnvironment("Development")
				.UseStartup<Startup>();
	}
}
