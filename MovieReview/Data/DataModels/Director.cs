namespace MovieReview.Data.DataModels
{
    public class Director
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Nationality { get; set; }
        public DateTime Birthday { get; set; }

        //many-to-many
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
