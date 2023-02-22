using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6_celder20.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_celder20.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext blahContext { get; set; }

        //Constructor
        public HomeController(MovieContext coolName)
        {
            blahContext = coolName;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MyPodcasts()
        {
            return View("Podcasts");
        }
        [HttpGet]
        public IActionResult MoviesApplication()
        {
            ViewBag.Categories = blahContext.Categories.ToList();

            return View("MoviesApplication");
        }

        [HttpPost]
        public IActionResult MoviesApplication(ApplicationResponse ar)
        {
            //this first if statement is for when all the correct fields are filled out
            if (ModelState.IsValid)
            {
                blahContext.Add(ar);
                blahContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else
            {
                //if all different forms are not filled in, it returns this view and shoots out the error messages associated with each required field
                ViewBag.Categories = blahContext.Categories.ToList();

                return View();
            }
        }

        public IActionResult MovieList()
        {
            //Order the database by movie title
            var applications = blahContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(applications);
        }

        //Creating actions that can edit past entries through a get and post
        [HttpGet]
        public IActionResult Edit(int appid)
        {
            ViewBag.Categories = blahContext.Categories.ToList();

            //Creating an object of application response type
            var application = blahContext.Responses.Single(x => x.AppId == appid);

            return View("MoviesApplication", application);
        }
        [HttpPost]
        public IActionResult Edit (ApplicationResponse appre)
        {
            blahContext.Update(appre);
            blahContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        //Creating actions that can delete records through a get and post
        [HttpGet]
        public IActionResult Delete(int appid)
        {
            var application = blahContext.Responses.Single(x => x.AppId == appid);

            return View(application);
        }
        [HttpPost]
        public IActionResult Delete(ApplicationResponse appresp)
        {
            blahContext.Responses.Remove(appresp);
            blahContext.SaveChanges();
            
            return RedirectToAction("MovieList");
        }

    }
}
