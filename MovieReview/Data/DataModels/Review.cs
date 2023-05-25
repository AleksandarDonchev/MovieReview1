using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReview.Data.DataModels
{
    public class Review
    {
        [Key]
        public string Id { get; set; }

        public string Username { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }

        //public string MovieId { get; set; }
        //public Movie Movie { get; set; }

        //public string UserId { get; set; }
        //public User User { get; set; }
    }
}
