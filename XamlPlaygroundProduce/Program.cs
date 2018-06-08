using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinFormsStarterKit.UserInterfaceBuilder.Models;

namespace XamlPlaygroundProduce
{
	class Program
	{
		private const string Url = "http://localhost:6202/api";
		private static string baseUri = Url + "/XamlPlaygroundSync";

		static async Task Main(string[] args)
		{
			if (args.Length == 2)
			{
				await PostUpdatedXaml(args[0], args[1]);

			}
			else
			{
				while (true)
				{
					var preserveXML = "PreserveXML" + new Random().Next().ToString();
					var xAML = "XAML" + new Random().Next().ToString();
					await PostUpdatedXaml(preserveXML, xAML);
					await Task.Delay(5000);

				}
			}

		}

		private static async Task PostUpdatedXaml(string preserveXML, string xAML)
		{
			var xamlPayload = new XamlPayload { PreserveXML = preserveXML, XAML = xAML };

			var json = JsonConvert.SerializeObject(xamlPayload);

			Console.WriteLine($"XamlPlaygroundProduce sent: {xamlPayload.XAML} ,{xamlPayload.PreserveXML}");

			var client = new HttpClient
			{
				BaseAddress = new Uri(baseUri)
			};

			var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

			await client.PostAsync(baseUri, stringContent);

		}
	}
}
