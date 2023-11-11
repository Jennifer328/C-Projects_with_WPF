using CarRental.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Interaction logic for ReservationWin.xaml
    /// </summary>
    public partial class ReservationWin : Window
    {
        private CustomerAuthority _customer {  get; set; }
        public ReservationWin()
        {
            InitializeComponent();
        }

        public ReservationWin(CustomerAuthority c):this() 
        {
            _customer = c;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var serverRes = await DBA.client.PostAsJsonAsync("GetReservationbyCustomerId", _customer);
            var content = serverRes.Content.ReadAsStringAsync().Result;
            Response contentJson = JsonConvert.DeserializeObject<Response>(content.ToString());
            List<Reservation> list = new List<Reservation>();
            if (contentJson.statusCode == 200)
            {
                for (int i = 0; i < contentJson.objs.Count; i++)
                {
                    Reservation res = JsonConvert.DeserializeObject<Reservation>(contentJson.objs[i].ToString());
                    list.Add(res);
                }
            }
            else
            {

            }
            this.dataGrid.ItemsSource = list;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CarSelection win = new CarSelection(_customer);
            win.Show();
            this.Close();
        }

        private async void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reservation res = this.dataGrid.SelectedItem as Reservation;
            if (res != null)
            {
                Inventory inv = new Inventory();
                inv.inventory_id = res.inventory_id;
                var serverRes = await DBA.client.PostAsJsonAsync("GetInventorybyId", inv);
                var content = serverRes.Content.ReadAsStringAsync().Result;
                Response contentJson = JsonConvert.DeserializeObject<Response>(content.ToString());
                if (contentJson.statusCode == 200)
                {
                    //for (int i = 0; i < contentJson.objs.Count; i++)
                    {
                        inv = JsonConvert.DeserializeObject<Inventory>(contentJson.objs[0].ToString());
                        //this.price.Content = $"Price : $ {inv.rent_price.ToString()}";
                        Car car = new Car();
                        car.car_id = inv.car_id;
                        var serverRes_car = await DBA.client.PostAsJsonAsync("GetCarbyId", car);
                        var content_car = serverRes_car.Content.ReadAsStringAsync().Result;
                        Response contentJson_car = JsonConvert.DeserializeObject<Response>(content_car.ToString());
                        List<Car> list = new List<Car>();
                        if (contentJson_car.statusCode == 200)
                        {
                            car = JsonConvert.DeserializeObject<Car>(contentJson_car.objs[0].ToString());
                            list.Add(car);
                        }
                        this.carDataGrid.ItemsSource = list;
                    }
                }
                else
                {

                }
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
    }
}
