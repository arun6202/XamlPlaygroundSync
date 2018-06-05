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

		public HomeController(IHubContext<XamlSyncHub> hubContext)
		{
			Program.HubContext = hubContext;
		}

		public IActionResult Index()
		{

			return View();
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
