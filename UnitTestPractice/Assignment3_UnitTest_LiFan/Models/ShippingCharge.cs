using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_UnitTest_LiFan
{
    public class ShippingCharge
    {
        public string ChargeCalculate (double weight, int distance)
        {
            double charge;
            if (weight > 10)
            {
                charge = weight * (int)(distance / 500) * 4.8;
            }
            else if (weight > 6 && weight <= 10)
            {
                charge = weight * (int)(distance / 500) * 3.7;
            }
            else if (weight > 2 && weight <= 6)
            {
                charge = weight * (int)(distance / 500) * 2.2;
            }
            else
            {
                charge = weight * (int)(distance / 500) * 1.1;
            }

            string formattedCharge = charge.ToString("F2");

            return formattedCharge;
        }
    }
}
