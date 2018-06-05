using System;
using System.Threading.Tasks;
 
using Microsoft.AspNetCore.SignalR.Client;
using XamarinFormsStarterKit.UserInterfaceBuilder.Models;

namespace XamlPlaygroundConsume
{
    class Program
    {
        private static HubConnection _connection;
        static async Task Main(string[] args)
        {
			if (args == null)
			{
				throw new ArgumentNullException(nameof(args));
			}

			await StartConnectionAsync();
			_connection.On<string, XamlPayload>("XamlPlaygroundSync", (name, message) =>
            {
				Console.WriteLine($"{name} said: {message.XAML} ,{message.PreserveXML}");
            });

            Console.ReadLine();
			await  DisposeAsync();
        }


        public static async Task StartConnectionAsync()
        {
            _connection = new HubConnectionBuilder()
				.WithUrl("http://localhost:6202/XamlPlaygroundSync")
                 .Build();

            await _connection.StartAsync();
        }

        public static async Task DisposeAsync()
        {
            await _connection.DisposeAsync();
        }
    }
}

   