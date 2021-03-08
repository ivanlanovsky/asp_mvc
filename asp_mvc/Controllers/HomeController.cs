using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using asp_mvc.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace asp_mvc.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationContext db;
        private readonly IWebHostEnvironment webHostEnvironment;
        public HomeController(ApplicationContext context, IWebHostEnvironment hostEnvironment)
        {
            db = context;
            webHostEnvironment = hostEnvironment;
        }

        public ViewResult Index()
        {
            ViewBag.counts = new List<int>() { db.Genres.Count(),
                                               db.Movies.Count(),
                                               db.Shows.Count()};
            List<Show> shows = db.Shows.ToList();
            List<Movie> movies = db.Movies.ToList();
            foreach (Show s in shows)
            {
                s.Movie = movies.Find(m => m.Id == s.MovieId);
            }
            ViewBag.imageFolderPath = Path.Combine(webHostEnvironment.WebRootPath, "images");
            return View(shows);

        }

        public ViewResult About()
        {
            return View();
        }
    }
}
