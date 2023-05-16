using MovieReview.Data.ViewModels;

namespace MovieReview.Services
{
    public interface IMovieServices
    {
        IEnumerable<MovieViewModel> GetAll();
        MovieViewModel GetMovieById(int id);
        void Add(MovieViewModel movieViewModel);
        void Update(MovieViewModel movieViewModel);
        void Delete(MovieViewModel movieViewMode);

    }
}