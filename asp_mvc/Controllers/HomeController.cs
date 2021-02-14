using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using asp_mvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {
            //ViewBag.genreCount = Genres.length;
            return View();
        }
        [HttpGet]
        public ViewResult GenreForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult GenreForm(Genre genre)
        {
            if (ModelState.IsValid)
            {
                GenreRepo.AddGenre(genre);
                return View("Index");
            }
            return View();

        }

        public ViewResult ListGenres()
        {
            return View(GenreRepo.Genres);
        }

        [HttpGet]
        public ViewResult MovieForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult MovieForm(Movie movie)
        {
            if (ModelState.IsValid)
            {
                MovieRepo.AddMovie(movie);
                return View("Index");
            }
            return View();

        }

        public ViewResult ListMovies()
        {
            return View(MovieRepo.Movies);
        }
    }
}
