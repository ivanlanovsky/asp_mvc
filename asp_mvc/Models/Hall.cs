using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc.Models
{
    public class Hall
    {
        public List<List<Seat>> Seats { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public Hall(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Seats = new List<List<Seat>>();
        }
    }
}
