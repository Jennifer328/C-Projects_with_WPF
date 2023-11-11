using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models
{
    internal class Response
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public Object obj { get; set; }
        public List<Object> objs { get; set; }
    }
}
