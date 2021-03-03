﻿using Microsoft.AspNetCore.Http;
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
    public class ShowController : Controller
    {

        private ApplicationContext db;
        public ShowController(ApplicationContext context)
        {
            db = context;
        }


        // GET: ShowController/Details/5
        public ActionResult Details(int id)
        {
            Show show = db.Shows.Find(id);
            Movie movie = db.Movies.Find(show.MovieId);
            movie.Genre = db.Genres.Find(movie.GenreId);
            show.Movie = movie;

            return View("Show", show);
        }

        [HttpGet]
        public IActionResult AddNew()
        {
            ViewBag.Movies = db.Movies.ToList<Movie>();
            return View("ShowForm");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Show show)
        {
            if (ModelState.IsValid)
            {
                db.Shows.Add(show);
                await db.SaveChangesAsync();
                return Redirect("~/Home/Index");
            }
            return View();
        }

        public IActionResult ListAll()
        {
            var shows = db.Shows.Join(db.Movies, 
            s => s.MovieId, 
            m => m.Id, 
            (s, m) => new Show
            {
                Movie = m,
                Date = s.Date,
                Duration = s.Duration,
                Id = s.Id
            });
            
            return View("ListShows", shows);
        }


        // POST: ShowController/Edit/5
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


        // POST: ShowController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Show show = db.Shows.Find(id);
                db.Shows.Remove(show);
                db.SaveChanges();
                return RedirectToAction("ListAll");
            }
            catch
            {
                return View();
            }
        }
    }
}
