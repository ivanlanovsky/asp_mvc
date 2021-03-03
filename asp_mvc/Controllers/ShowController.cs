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
    public class ShowController : Controller
    {

        private ApplicationContext db;
        public ShowController(ApplicationContext context)
        {
            db = context;
        }

        // GET: ShowController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShowController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShowController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShowController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ShowController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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

        // GET: ShowController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShowController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Show show = db.Shows.Find(id);
                db.Shows.Remove(show);
                db.SaveChanges();
                return Redirect("~/Home/ListShows");
            }
            catch
            {
                return View();
            }
        }
    }
}
