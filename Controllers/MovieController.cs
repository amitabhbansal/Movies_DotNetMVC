using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {
        private MovieContext Context { get; set; }
        public MovieController(MovieContext context)
        {
            this.Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add new movie";
            ViewBag.Genres = Context.Genre.OrderBy(g => g.GenereName).ToList();
            return View("Edit", new Movie());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit a movie";
            ViewBag.Genres = Context.Genre.OrderBy(g => g.GenereName).ToList();
            var movie = Context.Movies.Find(id);
            return View(movie);
        }
        
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0)
                {
                    Context.Movies.Add(movie);
                }
                else
                {
                    Context.Movies.Update(movie);
                }
                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action =(movie.MovieId==0)?"Add":"Edit";
                ViewBag.Genres = Context.Genre.OrderBy(g=>g.GenereName).ToList();
                return View(movie);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = Context.Movies.Find(id);
            /*Context.Movies.Remove(movie);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");*/
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            Context.Movies.Remove(movie);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> SearchMovies (string query)
            {
            IEnumerable<Movie> filteredMovies;

            if (string.IsNullOrEmpty(query))
                {
                // If query is empty, return all movies
                filteredMovies = Context.Movies.Include(m => m.Genre).ToList();
                }
            else
                {
                // Query the database to filter movies by the search term
                filteredMovies = Context.Movies
                    .Include(m => m.Genre)
                    .Where(m => m.Name.Contains(query) || m.Genre.GenereName.Contains(query))
                    .ToList();
                }
            

            // Return the partial view with the filtered data
            return PartialView("~/Views/Home/_MovieListPartial.cshtml", filteredMovies);
            }

        }
    }
