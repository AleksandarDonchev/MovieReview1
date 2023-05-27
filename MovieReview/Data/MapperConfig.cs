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
            CreateMap<Actor, ActorViewModel>().ReverseMap();
            CreateMap<Director, DirectorViewModel>().ReverseMap();
            CreateMap<Review , ReviewViewModel>().ReverseMap();
        }
        
    }
}
