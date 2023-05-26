using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Data.ViewModels;
using MovieReview.Services;

namespace MovieReview.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IDirectorServices _services;
        private readonly IMapper _mapper;

        public DirectorController(IDirectorServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var objDirectorList = _services.GetAll();
            return View(objDirectorList);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(DirectorViewModel directorViewModel)
        {
            _services.Add(directorViewModel);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var director = _services.GetActorById(id);
            if (director == null)
            {
                return NotFound();
            }
            var directorViewModel = _mapper.Map<DirectorViewModel>(director);
            return View(directorViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(DirectorViewModel directorUpdateModel)
        {
            _services.Update(directorUpdateModel);
            return RedirectToAction("Index");
        }




        public async Task<IActionResult> Delete(int id)
        {
            await _services.Delete(id);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteConfirmed(DirectorViewModel directorDeleteModel)
        {

            //_services.Delete(movieDeleteModel);  
            return RedirectToAction("Index");
        }
    }
}
