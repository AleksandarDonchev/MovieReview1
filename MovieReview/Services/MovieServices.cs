using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReview.Data;
using MovieReview.Data.DataModels;
using MovieReview.Data.ViewModels;
using Newtonsoft.Json;
using RestSharp;
using System.Text.Json;

namespace MovieReview.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        static HttpClient client = new HttpClient();


        public MovieViewModel GetMovieById(int id)
        {
            var movie = _db.Movies.Find(id);
            var movieViewModel = _mapper.Map<MovieViewModel>(movie);
            return movieViewModel;
        }

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

        public void Update(MovieViewModel movieViewModel)
        {
            var movie = _mapper.Map<Movie>(movieViewModel);
            _db.Update(movie);
            _db.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);
            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();
            //var movie = _mapper.Map<Movie>(movieViewModel);
            //_db.Movies.Remove(movie);
            //_db.SaveChanges();
        }



       


       

      
    }
}