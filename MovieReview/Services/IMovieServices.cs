using MovieReview.Data.ViewModels;

namespace MovieReview.Services
{
    public interface IMovieServices
    {
        IEnumerable<MovieViewModel> GetAll();
        void Add(MovieViewModel movieViewModel);
    }
}