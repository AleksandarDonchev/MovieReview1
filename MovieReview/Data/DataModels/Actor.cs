namespace MovieReview.Data.DataModels
{
    public class Actor
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public int Rating { get; set; }
        public DateTime Birthday { get; set; }

        //many-to-many relation
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
