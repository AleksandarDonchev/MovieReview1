using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Data.ViewModels;
using MovieReview.Services;

namespace MovieReview.Controllers
{
    public class ReviewController : Controller
    {
        
        
            private readonly IReviewServices _services;
            private readonly IMapper _mapper;

            public ReviewController(IReviewServices services, IMapper mapper)
            {
                _services = services;
                _mapper = mapper;
            }


            public IActionResult Index()
            {
                var objReviewList = _services.GetAll();
                return View(objReviewList);
            }

            public IActionResult Create()
            {

                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]

            public IActionResult Create(ReviewViewModel reviewViewModel)
            {
                _services.Add(reviewViewModel);
                return RedirectToAction("Index");
            }

            public IActionResult Update(int id)
            {
                var review = _services.GetActorById(id);
                if (review == null)
                {
                    return NotFound();
                }
                var reviewViewModel = _mapper.Map<ReviewViewModel>(review);
                return View(reviewViewModel);

            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Update(ReviewViewModel reviewUpdateModel)
            {
                _services.Update(reviewUpdateModel);
                return RedirectToAction("Index");
            }




            public async Task<IActionResult> Delete(int id)
            {
                await _services.Delete(id);
                return RedirectToAction("Index");
            }


            public IActionResult DeleteConfirmed(ReviewViewModel reviewDeleteModel)
            {

                //_services.Delete(movieDeleteModel);  
                return RedirectToAction("Index");
            }
        }
}
