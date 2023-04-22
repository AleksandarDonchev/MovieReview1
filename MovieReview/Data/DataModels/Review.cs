using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReview.Data.DataModels
{
    public class Review
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public int Rating { get; set; }
        public List<string> Comments { get; set; }

        //many-to-one
        public virtual ICollection<Movie> Movies { get; set; }
        //many-to-one

        public virtual ICollection<User> Users { get; set; }
    }
}
