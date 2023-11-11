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
    /// Interaction logic for Problem_1.xaml
    /// </summary>
    public partial class Problem_1 : Window
    {
        public Problem_1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double serviceFee = 10;
            double balance = double.Parse(bankBalance.Text);
            int numOfChecks = int.Parse(checkNum.Text);

            if(balance < 400)
            {
                serviceFee += 15;
            }

            double checkFee = 0;

            if(numOfChecks >= 60)
            {
                checkFee = numOfChecks * 0.1;
            }else if(numOfChecks >=40 && numOfChecks <= 59)
            {
                checkFee = numOfChecks * 0.06;
            }else if(numOfChecks >=20 && numOfChecks <= 39)
            {
                checkFee = numOfChecks * 0.08;
            }else
            {
                checkFee = numOfChecks * 0.1;
            }

            serviceFee += checkFee;

            MessageBox.Show("The service fee of the month is: $" + serviceFee + "\nThe number of check written: " + numOfChecks);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double serviceFee = 10;
            double balance = double.Parse(bankBalance.Text);
            int numOfChecks = int.Parse(checkNum.Text);

            if (balance < 400)
            {
                serviceFee += 15;
            }

            double checkFee = 0;

            if (numOfChecks >= 60)
            {
                checkFee = numOfChecks * 0.1;
            }
            else if (numOfChecks >= 40 && numOfChecks <= 59)
            {
                checkFee = numOfChecks * 0.06;
            }
            else if (numOfChecks >= 20 && numOfChecks <= 39)
            {
                checkFee = numOfChecks * 0.08;
            }
            else
            {
                checkFee = numOfChecks * 0.1;
            }

            serviceFee += checkFee;
            double newBalance = balance - serviceFee;

            MessageBox.Show("The New Balance is : $" + newBalance);

        }
    }
}
