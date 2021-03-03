using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using asp_mvc.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace asp_mvc.Controllers
{
    public class MovieController : Controller
    {

        private ApplicationContext db;
        public MovieController(ApplicationContext context)
        {
            db = context;
        }


        [HttpGet]
        public ViewResult AddNew()
        {
            ViewBag.Genres = db.Genres.ToList<Genre>();
            return View("MovieForm");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                await db.SaveChangesAsync();
                return Redirect("~/Home/Index");
            }
            return View();
        }

        public IActionResult ListAll()
        {
            var movies = db.Movies.Join(db.Genres,
             m => m.GenreId,
             g => g.Id,
             (m, g) => new Movie
             {
                 Genre = g,
                 Name = m.Name,
                 Country = m.Country,
                 Description = m.Description,
                 Restriction = m.Restriction,
                 Id = m.Id
             });

            return View("ListMovies", movies);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Movie movie = db.Movies.Find(id);
                db.Movies.Remove(movie);
                db.SaveChanges();
                return Redirect("~/Movie/ListAll");
            }
            catch
            {
                return View();
            }
        }
    }
}