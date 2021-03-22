using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ecinema.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ecinema.Controllers
{
    namespace ecinema.Controllers
    {
        public class GenreController : Controller
        {

            private readonly ApplicationContext db;
            public GenreController(ApplicationContext context)
            {
                db = context;
            }


            [HttpGet]
            [Authorize]
            public IActionResult AddGenre()
            {
                return View();
            }

            [HttpPost]
            [Authorize]
            public async Task<IActionResult> AddGenre(Genre genre)
            {
                if (ModelState.IsValid)
                {
                    db.Genres.Add(genre);
                    await db.SaveChangesAsync();
                    return Redirect("~/Home/Index");
                }
                return View(genre);
            }

            public async Task<IActionResult> ListAll()
            {
                var movies = await db.Genres.ToListAsync();

                return View("ListGenres", movies);
            }


            [HttpPost]
            [Authorize]
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

            // POST: ShowController/Delete/5
            [HttpPost]
            [Authorize]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(int id, IFormCollection collection)
            {
                    Movie movie = db.Movies.Find(id);
                    db.Movies.Remove(movie);
                    db.SaveChanges();
                    return Redirect("~/Movie/ListAll");
            }
        }
    }
}
