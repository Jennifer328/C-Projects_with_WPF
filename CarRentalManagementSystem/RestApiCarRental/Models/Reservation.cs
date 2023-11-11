using System;
using System.Reflection.Metadata.Ecma335;

namespace RestApiCarRental.Models
{
    public class Reservation
    {
        public int reservation_id { get; set; }
        public DateTime reservation_time { get; set; }
        public DateTime delivery_time { get; set; }
        public DateTime return_time { get; set; }
        //public int staff_id { get; set; }
        public int customer_id { get; set; }
        public int inventory_id { get; set; }
        //public int deposit_id { get; set; }
    }
}
