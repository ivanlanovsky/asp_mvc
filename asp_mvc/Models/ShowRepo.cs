using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc.Models
{
    public static class ShowRepo
    {
        private static List<Show> shows =
            new List<Show>();
        public static IEnumerable<Show> Shows
        {
            get
            {
                return shows;
            }
        }
        public static void AddShow(Show show)
        {
            shows.Add(show);
        }
    }
}
