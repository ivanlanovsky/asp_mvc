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
            ViewBag.counts = new List<int>() { db.Genres.Count(),
                                               db.Movies.Count(),
                                               db.Shows.Count()};
            return View(db.Shows.ToList());
        }

        public ViewResult Show(int Id)
        {
            Show show = db.Shows.Find(Id);
            Movie movie = db.Movies.Find(show.MovieId);
            movie.Genre = db.Genres.Find(movie.GenreId);
            show.Movie = movie;

            return View(show);
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

        public IActionResult ListMovies()
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
            //ViewBag.Genres = db.Genres.ToList<Genre>();
            return View(movies);
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

        public  IActionResult ListShows()
        {
            var shows = db.Shows.Join(db.Movies, // второй набор
            s => s.MovieId, // свойство-селектор объекта из первого набора
            m => m.Id, // свойство-селектор объекта из второго набора
            (s, m) => new Show
            {
                Movie = m,
                Date = s.Date,
                Duration = s.Duration,
                Id = s.Id
            });
            //ViewBag.Movies = db.Movies.Select(m => m.Name);
            return View(shows);
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
        [HttpPost("{id}")]
        public ViewResult DeleteShow(int Id)
        {
            Show show = db.Shows.Find(Id);
            db.Shows.Remove(show);
            return View("ListShows");
        }
    }
}
