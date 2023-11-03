using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JDRC2237A3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "The purpose of this project is to learn various topics Associations many to many, Item Selection, Bootstrap, and Attribute Routing using Tracks and PlayList where we had to add a new track into a playlist with its respective album and media type, we also edited the playlists to add all the tracks we want to the album.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Juan David Rodriguez Castelblanco.";

            return View();
        }
    }
}