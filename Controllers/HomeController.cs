using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext Context {  get; set; }
        public HomeController(MovieContext context)
        {
            this.Context = context;
        }

        public IActionResult Index()
        {   
            var movies =  Context.Movies.Include(m=>m.Genre).OrderBy(m=> m.Name).ToList();
            return View(movies);
        }

    }
}
