using AutoMapper;
using MovieReview.Data.DataModels;
using MovieReview.Data.ViewModels;

namespace MovieReview.Data
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Movie, MovieViewModel>().ReverseMap();
        }
        
    }
}
