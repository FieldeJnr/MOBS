using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobs.Web.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var model = new WhiteBoardModel(); 
            return View(model);
        }
        
    }
}