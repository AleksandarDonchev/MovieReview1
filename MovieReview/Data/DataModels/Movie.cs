using System.IO;

namespace MovieReview.Data.DataModels
{
    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        public Review Review { get; set; }
        public Actor Actor { get; set; }
        public Director Director { get; set; }
    }
}
