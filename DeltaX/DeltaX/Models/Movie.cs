using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX.Models
{
	public class Movie
	{
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public TimeSpan? Duration { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Director { get; set; }

        public string MovieImageURL { get; set; }

        public float MovieRating { get; set; }

        public virtual MovieGenre Genres { get; set; }

        public Producer Producer { get; set; }

        public virtual IEnumerable<Actor> Actors { get; set; }

    }

    public enum MovieGenre
    {
        Action, Comedy, Suspense, Thriller, Horror, Drama
    }
}
