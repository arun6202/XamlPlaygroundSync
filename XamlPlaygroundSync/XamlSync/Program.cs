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
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				   .UseStartup<Startup>().UseUrls(Urls);

		// run command    "/usr/local/share/dotnet/dotnet" run  --project $HOME/XamlPlaygroundSync/XamlPlaygroundSync/XamlSync/XamlSync.csproj
	}
}

