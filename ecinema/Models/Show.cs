using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ecinema.Models
{
    public class Show
    {
        [Required(ErrorMessage = "Please show date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please enter duration of show")]
        [Range(30, 250)]
        public int Duration { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select cinema hall")]
        public int HallId { get; set; }

        [Required(ErrorMessage = "Please select movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        
    }
}
