﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReview.Data;
using MovieReview.Data.DataModels;
using MovieReview.Data.ViewModels;

namespace MovieReview.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

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
            _db.Entry(movie).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(MovieViewModel movieViewModel)
        {
            var movie = _mapper.Map<Movie>(movieViewModel);
            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }
    }
}