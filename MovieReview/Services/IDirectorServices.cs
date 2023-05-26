using MovieReview.Data.ViewModels;

namespace MovieReview.Services
{
    public interface IDirectorServices
    {
        IEnumerable<DirectorViewModel> GetAll();
        DirectorViewModel GetActorById(int id);
        void Add(DirectorViewModel directorViewModel);
        void Update(DirectorViewModel directorViewModel);
        Task Delete(int id);
    }
}
