using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;
        private MovieContext _blahContext { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, MovieContext coolName)
        {
            _logger = logger;
            _blahContext = coolName;
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
        public IActionResult FillOutMovieForm()
        {
            return View("MoviesApplication");
        }

        [HttpPost]
        public IActionResult FillOutMovieForm(ApplicationResponse ar)
        {
            //this first if statement is for when all the correct fields are filled out
            if (ModelState.IsValid)
            {
                _blahContext.Add(ar);
                _blahContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else
            {
                //if all different forms are not filled in, it returns this view
                return View("ErrorMessage");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
