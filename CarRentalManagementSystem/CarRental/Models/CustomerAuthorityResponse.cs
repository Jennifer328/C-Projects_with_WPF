using System.Collections.Generic;

namespace CarRental.Models
{
    public class CustomerAuthorityResponse
    {
        public int statusCode {  get; set; }
        public string message { get; set; }
        public CustomerAuthority customer {  get; set; }
        public List<CustomerAuthority> customers { get; set; }
    }
}
