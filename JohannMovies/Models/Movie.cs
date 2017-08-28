using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace JohannMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1,20)]
        public int? NumberInStock { get; set; }

        //Navigation Property
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }


        public static List<Movie> GetAllMovies()
        {
            var Movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Conquest Of Paradise"},
                new Movie { Id = 2, Name = "Closet"}
            };
            return Movies;
        }

    }


}