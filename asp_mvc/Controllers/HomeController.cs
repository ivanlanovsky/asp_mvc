using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using asp_mvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace asp_mvc.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public ViewResult Index()
        {
            ViewBag.counts = new List<int>() { db.Genres.Count(),
                                               db.Movies.Count(),
                                               db.Shows.Count()};
            return View(db.Shows.ToList());
        }
        
    }
}
