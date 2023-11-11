namespace CarRental.Models
{
    public class Car
    {
        public int car_id { get; set; }  = 0;
        public string brand { get; set; } = "";
        public string model { get; set; } = "";
        public string trim { get; set; } = "";
        public int year { get; set; } = 0;
        public string transmission { get; set; } = "";
        public string fuel_type { get; set; } = "";
        public string body_type { get; set; } = "";
        public int seats { get; set; } = 0;
        public int doors { get; set; } = 0;
        public int category_id { get; set; } = 0;
    }
}
