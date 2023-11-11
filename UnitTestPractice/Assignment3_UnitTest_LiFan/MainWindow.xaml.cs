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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment3_UnitTest_LiFan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void shippingCharge_Click(object sender, RoutedEventArgs e)
        {
            double weightInput = double.Parse(weight.Text);
            int mile = int.Parse(distance.Text);
            double charge = 0.00;

            if (weightInput > 10)
            {
                charge = weightInput * (int)(mile / 500) * 4.8;
            }
            else if (weightInput > 6 && weightInput <= 10)
            {
                charge = weightInput * (int)(mile / 500) * 3.7;
            }
            else if (weightInput > 2 && weightInput <= 6)
            {
                charge = weightInput * (int)(mile / 500) * 2.2;
            }
            else
            {
                charge = weightInput * (int)(mile / 500) * 1.1;
            }

            string formattedCharge = charge.ToString("F2");

            MessageBox.Show("The shipping charge : $" + formattedCharge);
        }
    }
}
