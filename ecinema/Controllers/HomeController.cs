using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ecinema.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace ecinema.Controllers
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
            
            //if (db.Genres.Count() == 0)
            //{
            //    db.Genres.Add(new Genre
            //    {
            //        Id = 1,
            //        Name = "Comedy",
            //        Description = "Humorous film",
            //    }) ;

            //    db.Movies.Add(new Movie
            //    {
            //        Name = "Megalomania",
            //        Description = "Comedy about medieval Spain",
            //        GenreId = db.Genres.ToList().Where(g => g.Name == "Comedy").ElementAt(0).Id,
            //        Country = "France",
            //        Picture = "megalomania.jpg",
            //        Restriction = 12
            //    });

            //    db.Shows.Add(new Show
            //    {
            //        Date = new DateTime(1, 4, 2021),
            //        MovieId = db.Movies.ToList().Where(g => g.Name == "Megalomania").ElementAt(0).Id,
            //        Duration = 120
            //    }) ;
            //}
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
