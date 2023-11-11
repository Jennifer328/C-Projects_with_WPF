namespace CarRental.Models
{
    public class CustomerAuthority
    {
        public int id {  get; set; } = 0;
        public string user_name { get; set; } = "";
        public string password { get; set; } = "";
        public string salt { get; set; } = "";
        public string phone { get; set; } = "";
        public string email { get; set; } = "";
    }
}
