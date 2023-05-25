using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReview.Data;
using MovieReview.Data.DataModels;
using MovieReview.Data.ViewModels;

namespace MovieReview.Services
{
    public class ActorServices : IActorServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ActorViewModel GetActorById(int id)
        {
            var actor = _db.Actors.Find(id);
            var actorViewModel = _mapper.Map<ActorViewModel>(actor);
            return actorViewModel;
        }

        public ActorServices(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IEnumerable<ActorViewModel> GetAll()
        {
            var actors = _db.Actors.ToList();
            var actorViewModels = _mapper.Map<IEnumerable<ActorViewModel>>(actors);
            return actorViewModels;
        }

        public void Add(ActorViewModel actorViewModel)
        {
            var actor = _mapper.Map<Actor>(actorViewModel);
            _db.Actors.Add(actor);
            _db.SaveChanges();
        }

        public void Update(ActorViewModel actorViewModel)
        {
            var actor = _mapper.Map<Actor>(actorViewModel);
            _db.Update(actor);
            _db.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var actor = _db.Actors.FirstOrDefault(x => x.Id == id);
            _db.Actors.Remove(actor);
            await _db.SaveChangesAsync();
        }






        }
}
