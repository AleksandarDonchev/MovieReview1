using Microsoft.AspNetCore.Mvc;
using MovieReview.Data;
using MovieReview.Data.DataModels;

namespace MovieReview.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Movie> objMovieList = _db.Movies;
            return View(objMovieList);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Movie obj)
        {
            _db.Movies.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
