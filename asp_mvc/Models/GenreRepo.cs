using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc.Models
{
    public static class GenreRepo
    {
        private static List<Genre> genres =
            new List<Genre>();
        public static IEnumerable<Genre> Genres
        {
            get
            {
                return genres;
            }
        }
        public static void AddGenre(Genre genre)
        {
            genres.Add(genre);
        }
    }
}
