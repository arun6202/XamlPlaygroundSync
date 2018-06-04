using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XamlSync.Models;

namespace XamlSync.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class XamlPlaygroundSyncController : ControllerBase
	{

		[HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //  add database support to hold multiple versions of loaded XAML files.

		// POST api/values
		[HttpPost]
		public void Post([FromBody] XamlPayload payload)
		{

		}


	}
}
