using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using asp_mvc.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace asp_mvc.Controllers
{
    public class MovieController : Controller
    {

        private readonly ApplicationContext db;
        private readonly IWebHostEnvironment webHostEnvironment;
        public MovieController(ApplicationContext context, IWebHostEnvironment hostEnvironment)
        {
            db = context;
            webHostEnvironment = hostEnvironment;
        }


        [HttpGet]
        public ViewResult AddNew()
        {
            ViewBag.Genres = db.Genres.ToList<Genre>();
            return View("MovieForm");
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieModel mdata)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("AddNew");
            }
            string uniqueFileName = UploadedFile(mdata.Image);
            Movie movie = new Movie
            {
                Name = mdata.Name,
                Country = mdata.Country,
                Restriction = mdata.Restriction,
                Description = mdata.Description,
                GenreId = mdata.GenreId,
                Picture = uniqueFileName,
            };

            db.Movies.Add(movie);
            await db.SaveChangesAsync();
            return View("MovieModel", mdata);
        }

        private string UploadedFile(IFormFile file)
        {
            string filename = "placeholder.png";
            
            if (file != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                filename = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return filename;
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
                 Id = m.Id,
                 Picture = m.Picture
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