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
    /// Interaction logic for Problem_3.xaml
    /// </summary>
    public partial class Problem_3 : Window
    {
        public Problem_3()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int startP = int.Parse(startingPopulation.Text);
            double increaseRate = double.Parse(icrRate.Text);
            int days = int.Parse(comboBoxOne.Text);

            if(startP < 2 || increaseRate < 0 || days < 1)
            {
                MessageBox.Show("Invalid input, please try again!");
                return;
            }

            int totalP = startP;
            for (int i = 1; i <= days; i++)
            {
                totalP = (int)(totalP * (1 + increaseRate / 100));
                MessageBox.Show("Day No " + i + ", predicted population: " + totalP);
            }
        }
    }
}
