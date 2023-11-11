using CarRental.Models;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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

namespace CarRental
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



        private string get_ConnectionString()
        {
            string host = "host=localhost;";
            string port = "port=5432;";
            string dbName = "database=vanierdb;";
            string userName = "username=postgres;";
            string password = "password=shaojun123;"; //328111
            //string connectionString = string.Format("{0}{1}{2}{3}{4}", host, port, dbName, userName, password);
            string connectionString = $"{host} {port} {dbName} {userName} {password}";
            return connectionString;
        }

        private NpgsqlConnection establishConnection()
        {
            NpgsqlConnection con = null;
            try
            {
                con = new NpgsqlConnection(get_ConnectionString());
                //MessageBox.Show("Connection established.");
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return con;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (userName.Text.Length == 0)
            {
                MessageBox.Show("Please enter user name.");
                return;
            }
            else if (password.Password.Length <= 0)
            {
                MessageBox.Show("Please enter password.");
                return;
            }


            if (this.customer.IsChecked == true)
            {
                CustomerAuthority customer = new CustomerAuthority();
                customer.user_name = userName.Text;
                customer.password = password.Password;

                var serverRes = await DBA.client.PostAsJsonAsync("CheckAuthority", customer);
                if (serverRes.IsSuccessStatusCode)
                {
                    var content = serverRes.Content.ReadAsStringAsync().Result;
                    CustomerAuthorityResponse contentJson = JsonConvert.DeserializeObject<CustomerAuthorityResponse>(content.ToString());
                    if (contentJson.statusCode == 200) {
                        CustomerAuthority c = contentJson.customer;
                        Console.WriteLine(c.user_name + " " + c.email);

                        CarSelection carSelection = new CarSelection(c);
                        carSelection.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Login failed.");
                    }
                }
                else
                {
                    MessageBox.Show("Login failed.");
                }

                //var serverRes = await DBA.client.GetStringAsync($"GetCustomerbyUsername/{userName.Text}" );
                //CustomerAuthorityResponse resJson = JsonConvert.DeserializeObject<CustomerAuthorityResponse>(serverRes);
                //customer = resJson.customer;
                //if (resJson.statusCode==200)
                //{
                //    if (customer.password.Equals(password.Password))
                //    {
                //        MessageBox.Show("Login sucessfull");
                //        CarSelection carSelection = new CarSelection();
                //        carSelection.Show();
                //        this.Close();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Login failed. Incorrect passwrod! ");
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("Login failed.  ");
                //}
            }
            else
            {
                Staff staff = new Staff();
                staff.user_name = userName.Text;
                staff.password = password.Password;
                var serverRes = await DBA.client.PostAsJsonAsync("StaffLogin", staff);
                var content = serverRes.Content.ReadAsStringAsync().Result;
                Response contentJson = JsonConvert.DeserializeObject<Response>(content.ToString());
                if (contentJson?.statusCode == 200)
                {
                    Staff s = JsonConvert.DeserializeObject<Staff>(contentJson.obj.ToString());
                    Console.WriteLine(s.user_name + " " + s.authority);

                    Admin admin = new Admin();
                    admin.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login failed.");
                }

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Close();
        }

        private void staff_Checked(object sender, RoutedEventArgs e)
        {
            if (admin.IsChecked == true)
            {
                //Admin admin = new Admin();
                //admin.Show();
                //this.btn_creat.Visibility = Visibility.Collapsed;
            }
            else
            {
                //this.btn_creat.Visibility = Visibility.Visible;
            }
        }

        private void customer_Checked(object sender, RoutedEventArgs e)
        {
            if (customer.IsChecked == true)
            {
                //this.btn_creat.Visibility= Visibility.Visible;
            }
            else
            {
                //this.btn_creat.Visibility = Visibility.Collapsed;
            }
        }
    }
}
