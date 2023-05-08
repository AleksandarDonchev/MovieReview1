using AutoMapper;
using MovieReview.Data;
using MovieReview.Data.DataModels;
using MovieReview.Data.ViewModels;

namespace MovieReview.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public MovieServices(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public IEnumerable<MovieViewModel> GetAll() 
        {
            var movies = _db.Movies.ToList();
            var movieViewModels = _mapper.Map<IEnumerable<MovieViewModel>>(movies);
            return movieViewModels;
        }
        public void Add(MovieViewModel movieViewModel)
        {
            var movie = _mapper.Map<Movie>(movieViewModel);
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }
    }
}