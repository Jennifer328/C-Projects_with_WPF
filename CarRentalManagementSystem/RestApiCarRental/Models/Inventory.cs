namespace RestApiCarRental.Models
{
    public class Inventory
    {
        public int inventory_id { get; set; }
        public string vin { get; set; }
        public string color {  get; set; }
        public decimal rent_price { get; set; }
        public decimal deposit {  get; set; }
        public decimal cost {  get; set; }
        public int car_id {  get; set; }
        //public int service_point_id {  get; set; }
        //public int contract_id {  get; set; }


    }
}
