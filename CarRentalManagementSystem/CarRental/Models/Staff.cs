using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models
{
    internal class Staff
    {
        public int id { get; set; } = 0;
        public string user_name { get; set; } = "";
        public string password { get; set; } = "";
        public string salt { get; set; } = "";
        public string phone { get; set; } = "";
        public string email { get; set; } = "";
        public int authority { get; set; } = 0;

        //public static implicit operator Staff(Object obj)
        //{
        //    Staff staff = obj as Staff;
        //    return staff;
        //}
    }
}
