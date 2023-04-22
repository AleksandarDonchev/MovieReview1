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

        //many-to-many
        public virtual ICollection<User> Users { get; set; }

        //many-to-many
        public virtual ICollection<Director> Directors { get; set; }
    }
}
