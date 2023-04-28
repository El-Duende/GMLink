﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMLink.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int? GameMasterID { get; set; }
        public string? GameMaster { get; set; }  
        public String? Date { get; set; }   
        public String? StartTime { get; set; }
        public String? EndTime { get; set; }
        public decimal Price { get; set; }
        public String? Description { get; set; }

        public String? About { get; set; }

        

    }
}
