using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;


namespace asp_mvc.Models
{
    public class MovieModel
    {
        [Required(ErrorMessage = "Please enter movie name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Please enter origin country")]
        public String Country { get; set; }

        [Required(ErrorMessage = "Please select restriction age")]
        public int Restriction { get; set; }
        [Required(ErrorMessage = "Please enter description")]
        public String Description { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please select movie genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile Image { get; set; }
    }
}
