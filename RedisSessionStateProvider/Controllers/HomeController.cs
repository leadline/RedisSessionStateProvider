using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedisSessionStateProvider.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
		const string userSession = "userSession";

        public ActionResult Index()
        {
			if (Session[userSession] == null)
			{
				Session[userSession] = new User { Id = Guid.NewGuid().ToString(), Name = Request.Browser.Browser };
			}

			return Content(JsonConvert.SerializeObject(Session[userSession]));
        }


    }

	[Serializable]
	public class User
	{
		public string Id { get; set; }
		public DateTime Now { get; set; }
		public string Name { get; set; }

		public User() {
			Now = DateTime.Now;
		}
	}

}
