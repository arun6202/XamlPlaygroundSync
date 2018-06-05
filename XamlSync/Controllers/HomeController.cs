using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using XamarinFormsStarterKit.UserInterfaceBuilder.Models;
using XamlSync.Hubs;
using XamlSync.Models;

namespace XamlSync.Controllers
{
	public class HomeController : Controller
	{

		IHubContext<XamlSyncHub> _hubContext;

		public HomeController(IHubContext<XamlSyncHub> hubContext)
		{
			_hubContext = hubContext;

			Program.HubContext = hubContext;
		}

		public async Task<IActionResult> Index()
		{             
			await _hubContext.Clients.All.SendAsync("XamlPlaygroundSync", "sender"+ new Random().Next().ToString(), new XamlPayload{XAML="te",PreserveXML="rerer"}); 
            
			return   View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
