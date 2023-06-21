using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Data;
using MovieReview.Data.DataModels;
using MovieReview.Data.ViewModels;
using MovieReview.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace MovieReview.Controllers
{
  

    public class MovieController : Controller
    {
   
        private readonly IMovieServices _services;
        private readonly IMapper _mapper;
 

        public MovieController(IMovieServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
   
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

        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id) 
        {
            var movie = _services.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            var movieViewModel = _mapper.Map<MovieViewModel>(movie);
            return View(movieViewModel);
          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(MovieViewModel movieUpdateModel)
        {
            _services.Update(movieUpdateModel);
            return RedirectToAction("Index");
        }



        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.Delete(id);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteConfirmed(MovieViewModel movieDeleteModel)
        {
            
            //_services.Delete(movieDeleteModel);  
            return RedirectToAction("Index");
        }



    }
}
