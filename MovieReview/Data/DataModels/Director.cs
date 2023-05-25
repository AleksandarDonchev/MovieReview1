
using System.ComponentModel.DataAnnotations;

namespace MovieReview.Data.DataModels
{
    public class Director
    {
        [Key]
        public int Id { get; set; }
        
        public string FullName { get; set; }
        public string Nationality { get; set; }
        public DateTime Birthday { get; set; }

        //public string MovieId { get; set; }
        //public Movie Movie { get; set; }
    }
}
