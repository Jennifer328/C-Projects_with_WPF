using CarRental.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
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

namespace CarRental
{
    /// <summary>
    /// Interaction logic for CarSelection.xaml
    /// </summary>
    public partial class CarSelection : Window
    {
        private CustomerAuthority customer { get; set; }
        private Inventory _inventory = new Inventory();

        public CarSelection()
        {
            InitializeComponent();
        }

        public CarSelection(CustomerAuthority c) : this()
        {
            customer = c;
        }



        private async void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Car car = this.dataGrid.SelectedItem as Car;
            if (car != null)
            {
                Inventory inventory = new Inventory();
                inventory.car_id = car.car_id;
                var serverRes = await DBA.client.PostAsJsonAsync("GetInventorybyCarId", inventory);
                var content = serverRes.Content.ReadAsStringAsync().Result;
                Response contentJson = JsonConvert.DeserializeObject<Response>(content.ToString());

                if (contentJson.statusCode == 200)
                {
                    //for (int i = 0; i < contentJson.objs.Count; i++)
                    {
                        inventory = JsonConvert.DeserializeObject<Inventory>(contentJson.objs[0].ToString());
                        this.price.Content = $"Price : $ {inventory.rent_price.ToString()}";
                        _inventory = inventory;
                    }
                }
                else
                {

                }
            }
        }



        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            //Filter
            Car car = new Car();
            car.transmission = this.transmission.Text.ToLower();
            car.fuel_type = this.fuelType.Text.ToLower();
            car.body_type = this.bodyType.Text.ToLower();
            var serverRes = await DBA.client.PostAsJsonAsync("GetCarbyFilter", car);
            var content = serverRes.Content.ReadAsStringAsync().Result;
            Response contentJson = JsonConvert.DeserializeObject<Response>(content.ToString());
            List<Car> cars = new List<Car>();
            if (contentJson.statusCode == 200)
            {
                for (int i = 0; i < contentJson.objs.Count; i++)
                {
                    car = JsonConvert.DeserializeObject<Car>(contentJson.objs[i].ToString());
                    cars.Add(car);
                    Console.WriteLine(car);
                }
            }
            else
            {

            }
            this.dataGrid.ItemsSource = cars;
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if(this.endTime.SelectedDate==null || this.endTime.SelectedDate==null)
            {
                MessageBox.Show("Please select reservatin time");
                return;
            }
            if((this.dataGrid.SelectedItem as Car) == null)
            {
                MessageBox.Show("Please select a car");
                return;
            }

            Reservation r = new Reservation();
            r.reservation_time = DateTime.Now;
            r.return_time = (DateTime)this.endTime.SelectedDate;
            r.delivery_time = (DateTime)this.startTime.SelectedDate;
            r.customer_id = customer.id;
            r.inventory_id = _inventory.inventory_id;
            var serverRes = await DBA.client.PostAsJsonAsync("AddReservation", r);
            var content = serverRes.Content.ReadAsStringAsync().Result;
            Response contentJson = JsonConvert.DeserializeObject<Response>(content.ToString());
            List<Car> cars = new List<Car>();
            if (contentJson.statusCode == 200)
            {
                MessageBox.Show("Reserve successful");
            }
            else
            {
                MessageBox.Show("Reserve faild");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ReservationWin win = new ReservationWin(customer);
            win.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
    }
}
