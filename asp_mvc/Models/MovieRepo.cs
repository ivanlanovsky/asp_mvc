using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc.Models
{
    public static class MovieRepo
    {
        private static List<Movie> movies =
            new List<Movie>();
        public static IEnumerable<Movie> Movies
        {
            get
            {
                return movies;
            }
        }
        public static void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }
    }
}
