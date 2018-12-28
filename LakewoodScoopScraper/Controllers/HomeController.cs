using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LakewoodScoopScraper.API;

namespace LakewoodScoopScraper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Scraper scraper = new Scraper();
            IEnumerable<Post> posts = scraper.GetNews();
            return View(posts);
        }
    }
}