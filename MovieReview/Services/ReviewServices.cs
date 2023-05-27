using AutoMapper;
using MovieReview.Data.DataModels;
using MovieReview.Data.ViewModels;
using MovieReview.Data;

namespace MovieReview.Services
{
    public class ReviewServices : IReviewServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ReviewViewModel GetActorById(int id)
        {
            var review = _db.Directors.Find(id);
            var reviewViewModel = _mapper.Map<ReviewViewModel>(review);
            return reviewViewModel;
        }

        public ReviewServices(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IEnumerable<ReviewViewModel> GetAll()
        {
            var reviews = _db.Reviews.ToList();
            var reviewViewModels = _mapper.Map<IEnumerable<ReviewViewModel>>(reviews);
            return reviewViewModels;
        }

        public void Add(ReviewViewModel reviewViewModel)
        {
            var director = _mapper.Map<Review>(reviewViewModel);
            _db.Reviews.Add(director);
            _db.SaveChanges();
        }

        public void Update(ReviewViewModel reviewViewModel)
        {
            var review = _mapper.Map<Review>(reviewViewModel);
            _db.Update(review);
            _db.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var review = _db.Reviews.FirstOrDefault(x => x.Id == id);
            _db.Reviews.Remove(review);
            await _db.SaveChangesAsync();
        }
    }
}
