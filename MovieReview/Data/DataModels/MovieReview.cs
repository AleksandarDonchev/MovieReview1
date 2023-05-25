namespace MovieReview.Data.DataModels
{
    public class MovieReview
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
