using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XamarinFormsStarterKit.UserInterfaceBuilder.Models;


namespace XamlSync.Controllers
{
	[Route("api/[controller]")]
	public class XamlPlaygroundSyncController : Controller
	{
		private static XamlPayload XamlPayload = new XamlPayload();

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
