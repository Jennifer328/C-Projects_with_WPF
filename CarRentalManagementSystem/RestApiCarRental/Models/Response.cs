namespace RestApiCarRental.Models
{
    public class Response
    {
        public int statusCode { get; set; } 
        public string message { get; set; } 
        public object obj { get; set; } = null;
        public List<object> objs { get; set; } = null;
    }
}
