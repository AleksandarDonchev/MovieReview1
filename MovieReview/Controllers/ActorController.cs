using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Data.ViewModels;
using MovieReview.Services;

namespace MovieReview.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorServices _services;
        private readonly IMapper _mapper;

        public ActorController(IActorServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var objActorList = _services.GetAll();
            return View(objActorList);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ActorViewModel actorViewModel)
        {
            _services.Add(actorViewModel);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var actor = _services.GetActorById(id);
            if (actor == null)
            {
                return NotFound();
            }
            var actorViewModel = _mapper.Map<ActorViewModel>(actor);
            return View(actorViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ActorViewModel actorUpdateModel)
        {
            _services.Update(actorUpdateModel);
            return RedirectToAction("Index");
        }




        public async Task<IActionResult> Delete(int id)
        {
            await _services.Delete(id);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteConfirmed(ActorViewModel actorDeleteModel)
        {

            //_services.Delete(movieDeleteModel);  
            return RedirectToAction("Index");
        }
    }
}
