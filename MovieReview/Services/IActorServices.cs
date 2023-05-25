using MovieReview.Data.ViewModels;

namespace MovieReview.Services
{
    public interface IActorServices
    {
        IEnumerable<ActorViewModel> GetAll();
        ActorViewModel GetActorById(int id);
        void Add(ActorViewModel actorViewModel);
        void Update(ActorViewModel actorViewModel);
        Task Delete(int id);
    }
}
