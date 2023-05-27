using MovieReview.Data.ViewModels;

namespace MovieReview.Services
{
    public interface IReviewServices
    {
        IEnumerable<ReviewViewModel> GetAll();
        ReviewViewModel GetActorById(int id);
        void Add(ReviewViewModel reviewViewModel);
        void Update(ReviewViewModel reviewViewModel);
        Task Delete(int id);
    }
}
