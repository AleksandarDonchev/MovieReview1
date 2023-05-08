using MovieReview.Data.ViewModels;

namespace MovieReview.Services
{
    public interface IMovieServices
    {
        void Add(MovieViewModel movieViewModel);
    }
}