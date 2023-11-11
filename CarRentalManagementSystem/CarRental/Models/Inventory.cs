namespace CarRental.Models
{
    public class Inventory
    {
        public int inventory_id { get; set; } = 0;
        public string vin { get; set; } = "";
        public string color { get; set; } = "";
        public decimal rent_price { get; set; } = 0;
        public decimal deposit { get; set; } = 0;
        public decimal cost { get; set; } = 0;
        public int car_id { get; set; } = 0;
        //public int service_point_id {  get; set; }
        //public int contract_id {  get; set; }


    }
}
