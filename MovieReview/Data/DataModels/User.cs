using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReview.Data.DataModels
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        //one-to-many
        public virtual ICollection<Movie> Movies { get; set; }

        //one-to-many
       
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
