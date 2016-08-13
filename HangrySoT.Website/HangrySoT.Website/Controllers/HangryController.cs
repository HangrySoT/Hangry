using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HangrySoT.Website.Controllers
{

    public class HangryInputModel
    {

        public double lat { get; set; }
        public double lon { get; set; }
        public HttpPostedFile image { get; set; }       

    }

    public class HangryController : Controller
    {
        // GET: Hangry
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HangryInputModel model)
        {
            return Content(model.image.ContentLength.ToString());
        }
    }
}