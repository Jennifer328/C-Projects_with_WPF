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

namespace Lab1_LiFAN_2395027
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

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if(radioOne.IsChecked == true)
            {
                Problem_1 problem_1 = new Problem_1();
                problem_1.Show();
                this.Close(); // only if you want to close the current window which is Main window

            }else if (radioThree.IsChecked == true)
            {
                Problem_3 problem_3 = new Problem_3();
                problem_3.Show();

            }else if(radioTwo.IsChecked == true)
            {
                Problem_2 problem_2 = new Problem_2();
                problem_2.Show();
            }
            else
            {
                MessageBox.Show("Please choose a project!");
            }
        }

  
    }
}
