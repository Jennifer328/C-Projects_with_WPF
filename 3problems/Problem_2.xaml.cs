using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab1_LiFAN_2395027
{
    /// <summary>
    /// Interaction logic for Problem_2.xaml
    /// </summary>
    public partial class Problem_2 : Window
    {
        public Problem_2()
        {
            InitializeComponent();
        }

        private void shippingCharge_Click(object sender, RoutedEventArgs e)
        {
            double weightInput = double.Parse(weight.Text);
            int mile = int.Parse(distance.Text);
            double charge = 0;
            
            if(weightInput > 10)
            {
                charge = weightInput * (int)(mile / 500) * 4.8;
            }else if (weightInput > 6 && weightInput <= 10)
            {
                charge = weightInput * (int)(mile / 500) * 3.7;
            }else if(weightInput >2 && weightInput <= 6)
            {
                charge = weightInput * (int)(mile / 500) * 2.2;
            }else
            {
                charge = weightInput * (int)(mile / 500) * 1.1;
            }

            MessageBox.Show("The shipping charge : $" + charge);
            
        }
    }
}
