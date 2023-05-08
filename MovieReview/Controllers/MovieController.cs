using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Data;
using MovieReview.Data.DataModels;
using MovieReview.Data.ViewModels;
using MovieReview.Services;

namespace MovieReview.Controllers
{
    public class MovieController : Controller
    {
   
        private readonly IMovieServices _services;
        private readonly IMapper _mapper;
        public MovieController(IMovieServices services,IMapper mapper)
        {
            _services= services;
            _mapper= mapper;
        }


        public IActionResult Index()
        {
            var objMovieList = _services.GetAll();
            return View(objMovieList);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(MovieViewModel movieViewModel)
        {
            _services.Add(movieViewModel);
            return RedirectToAction("Index");
        }
    }
}
