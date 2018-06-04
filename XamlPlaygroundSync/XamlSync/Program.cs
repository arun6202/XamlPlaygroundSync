using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace XamlSync
{
	public class Program
	{
		private const string Urls = "http://localhost:6202";

		public static void Main(string[] args)
		{

			var config = new ConfigurationBuilder()
			   .AddCommandLine(args)
			   .Build();

			var host = new WebHostBuilder()
				.UseConfiguration(config)
				.UseSetting(WebHostDefaults.PreventHostingStartupKey, "true")
				.ConfigureLogging(factory =>
				{
					factory.AddConsole();
				})
				.UseKestrel()
				.UseUrls(Urls)
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseEnvironment("Development")
				.UseStartup<Startup>()
				.Build();

			host.Run();

		}



		// run command    "/usr/local/share/dotnet/dotnet" run  --project $HOME/XamlPlaygroundSync/XamlPlaygroundSync/XamlSync/XamlSync.csproj
	}
}

