﻿using System.ComponentModel.DataAnnotations;

namespace MovieReview.Data.DataModels
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        
        public string FullName { get; set; }
        public int Rating { get; set; }
        public DateTime Birthday { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
