using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc.Models
{
    public static class ExistingHalls
    {
        public static List<Hall> AllHalls;
        //static Hall hall2;

        static ExistingHalls()
        {
            AllHalls = new List<Hall>();
            Hall hall1 = new Hall(1, "Green"); 
            for (int i = 0; i < 5; i++)
            {
                hall1.Seats.Add(new List<Seat>());
                for (int j = 1; j < 7; j++)
                {
                    hall1.Seats[i].Add(new Seat(i + 1, j));
                }  
            }
            AllHalls.Add(hall1);
        }

    }
}
