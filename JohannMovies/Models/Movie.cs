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