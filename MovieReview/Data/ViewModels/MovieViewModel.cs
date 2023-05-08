namespace MovieReview.Data.ViewModels
{
    public class MovieViewModel
    {

        public int Id { get; set; }


        public string Title { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
