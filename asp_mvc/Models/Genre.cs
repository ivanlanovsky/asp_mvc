using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace asp_mvc.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name of the genre")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Please enter description of the genre")]
        public String Description { get; set; }

        public List<Movie> Courses { get; set; } = new List<Movie>();

    }
}
