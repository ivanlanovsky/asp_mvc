﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecinema.Models
{
    public class Seat
    {
        public int Row;
        public int Number;

        public Seat(int row, int number)
        {
            this.Row = row;
            this.Number = number;
        }
    }
}
