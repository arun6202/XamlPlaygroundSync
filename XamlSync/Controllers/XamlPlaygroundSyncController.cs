using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using XamarinFormsStarterKit.UserInterfaceBuilder.Models;
using XamlSync.Hubs;

namespace XamlSync.Controllers
{
	[Route("api/[controller]")]
	public class XamlPlaygroundSyncController : Controller
	{
		public static XamlPayload XamlPayload = new XamlPayload();

		public XamlPlaygroundSyncController(IHubContext<XamlSyncHub> hubContext)
        {
			if (Program.HubContext  ==null)
			{
				Program.HubContext = hubContext;

			}
        }

		[HttpGet]
		public XamlPayload Get()
		{
			return XamlPayload;
		}


		// POST api/values
		[HttpPost]
		public void Post([FromBody]XamlPayload xamlPayload)
		{
			XamlPayload = xamlPayload;
		}


	}
}
