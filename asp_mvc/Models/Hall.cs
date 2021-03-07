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
        public int Cost { get; set; }

        public Hall(int id, string name, int cost)
        {
            this.Id = id;
            this.Name = name;
            this.Cost = cost;
            this.Seats = new List<List<Seat>>();
        }
    }
}
