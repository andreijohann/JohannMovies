using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleasdDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }

        //Navigation Property
        public Genre Genre { get; set; }
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