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

        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public ViewResult Index()
        {
            ViewBag.counts = new List<int>() { db.Genres.ToList().Count,
                                               db.Movies.ToList().Count,
                                               db.Shows.ToList().Count};
            return View();
        }
        [HttpGet]
        public ViewResult GenreForm()
        {
            return View();
        }

        public async Task<IActionResult> ListGenres()
        {
            return View(await db.Genres.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> GenreForm(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Genres.Add(genre);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpGet]
        public ViewResult MovieForm()
        {
            ViewBag.Genres = db.Genres.ToList<Genre>();
            return View();
        }

        public async Task<IActionResult> ListMovies()
        {
            ViewBag.Genres = db.Genres.ToList<Genre>();
            return View(await db.Movies.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> MovieForm(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ViewResult ShowForm()
        {
            ViewBag.Movies = db.Movies.ToList<Movie>();
            return View();
        }

        public async Task<IActionResult> ListShows()
        {
            ViewBag.Movies = db.Movies.ToList<Movie>();
            return View(await db.Shows.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> ShowForm(Show show)
        {
            if (ModelState.IsValid)
            {
                db.Shows.Add(show);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
