using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JohannMovies.Models;

namespace JohannMovies.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}