using System;


namespace CarRental.Models
{
    public class Reservation
    {
        public int reservation_id { get; set; } = 0;
        public DateTime reservation_time { get; set; } = DateTime.Now;
        public DateTime delivery_time { get; set; } = DateTime.Now;
        public DateTime return_time { get; set; } = DateTime.Now;
        //public int staff_id { get; set; }
        public int customer_id { get; set; } = 0;
        public int inventory_id { get; set; } = 0;
        //public int deposit_id { get; set; }
    }
}
