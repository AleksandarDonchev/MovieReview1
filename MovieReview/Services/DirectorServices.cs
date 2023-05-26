using AutoMapper;
using MovieReview.Data.DataModels;
using MovieReview.Data.ViewModels;
using MovieReview.Data;

namespace MovieReview.Services
{
    public class DirectorServices : IDirectorServices
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public DirectorViewModel GetActorById(int id)
        {
            var director = _db.Directors.Find(id);
            var directorViewModel = _mapper.Map<DirectorViewModel>(director);
            return directorViewModel;
        }

        public DirectorServices(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IEnumerable<DirectorViewModel> GetAll()
        {
            var directors = _db.Directors.ToList();
            var directorViewModels = _mapper.Map<IEnumerable<DirectorViewModel>>(directors);
            return directorViewModels;
        }

        public void Add(DirectorViewModel directorViewModel)
        {
            var director = _mapper.Map<Director>(directorViewModel);
            _db.Directors.Add(director);
            _db.SaveChanges();
        }

        public void Update(DirectorViewModel directorViewModel)
        {
            var director = _mapper.Map<Director>(directorViewModel);
            _db.Update(director);
            _db.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var director = _db.Directors.FirstOrDefault(x => x.Id == id);
            _db.Directors.Remove(director);
            await _db.SaveChangesAsync();
        }
    }
}
