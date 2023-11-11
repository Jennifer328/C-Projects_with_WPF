namespace RestApiCarRental.Models
{
    public class Car
    {
        public int car_id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string trim { get; set; }
        public int year { get; set; }
        public string transmission { get; set; }
        public string fuel_type { get; set; }
        public string body_type { get; set; }
        public int seats { get; set; }
        public int doors { get; set; }
        //public int category_id { get; set; }
    }
}
