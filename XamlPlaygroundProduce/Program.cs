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
			while (true)
			{
				var xamlPayload = new XamlPayload { PreserveXML = "PreserveXML" + new Random().Next().ToString(), XAML = "XAML" + new Random().Next().ToString() };

				var json = JsonConvert.SerializeObject(xamlPayload);

				Console.WriteLine($"XamlPlaygroundProduce sent: {xamlPayload.XAML} ,{xamlPayload.PreserveXML}");

				var client = new HttpClient
				{
					BaseAddress = new Uri(baseUri)
				};

				var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

				await client.PostAsync(baseUri, stringContent);

				await Task.Delay(5000);
			}

		}

	}
}
