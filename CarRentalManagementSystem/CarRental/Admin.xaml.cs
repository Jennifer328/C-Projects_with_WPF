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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Car car = new Car();
            car.brand = this.tb_brand.Text;
            car.model = this.tb_model.Text;
            car.trim = this.tb_trim.Text;
            car.year = int.Parse(this.tb_year.Text);
            car.transmission = this.tb_transmission.Text;
            car.fuel_type = this.tb_fuelType.Text;
            car.body_type = this.tb_bodyType.Text;
            car.seats = int.Parse(this.tb_seats.Text);
            car.doors = int.Parse(this.tb_doors.Text);

            var serverRes = await DBA.client.PostAsJsonAsync("AddCar", car);
            var content = serverRes.Content.ReadAsStringAsync().Result;
            Response contentJson = JsonConvert.DeserializeObject<Response>(content.ToString());
            if(contentJson.statusCode == 200)
            {
                MessageBox.Show("Add car successful");
            }
            else
            {
                MessageBox.Show("Add car failed");
            }


        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Car car = new Car();
            car.transmission = "any";
            car.fuel_type = "any";
            car.body_type = "any";
            var serverRes = await DBA.client.PostAsJsonAsync("GetCarbyFilter", car);
            var content = serverRes.Content.ReadAsStringAsync().Result;
            Response contentJson = JsonConvert.DeserializeObject<Response>(content.ToString());
            List<Car> list = new List<Car>();
            
            if (contentJson.statusCode == 200)
            {
                for (int i = 0; i < contentJson.objs.Count; i++)
                {
                    car = JsonConvert.DeserializeObject<Car>(contentJson.objs[i].ToString());
                    list.Add(car);
                }
            }
            else
            {
                MessageBox.Show("Retrieve data failed");
            }
            this.carDataGrid.ItemsSource = list;

        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Car car = new Car();
            car.brand = this.tb_brand.Text;
            car.model = this.tb_model.Text;
            car.trim = this.tb_trim.Text;
            car.year = int.Parse(this.tb_year.Text);
            car.transmission = this.tb_transmission.Text;
            car.fuel_type = this.tb_fuelType.Text;
            car.body_type = this.tb_bodyType.Text;
            car.seats = int.Parse(this.tb_seats.Text);
            car.doors = int.Parse(this.tb_doors.Text);
            car.car_id = int.Parse(this.tb_carId.Text);

            var serverRes = await DBA.client.PostAsJsonAsync("UpdateCar", car);
            var content = serverRes.Content.ReadAsStringAsync().Result;
            Response contentJson = JsonConvert.DeserializeObject<Response>(content.ToString());

            if (contentJson.statusCode == 200)
            {
                MessageBox.Show("Update Car successful");
            }
            else
            {
                MessageBox.Show("Update Car failed");
            }
        }

        private void carDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Car car = this.carDataGrid.SelectedItem as Car;
            if (car != null)
            {
                this.tb_carId.Text = car.car_id.ToString();
                this.tb_brand.Text = car.brand.ToString();
                this.tb_model.Text = car.model.ToString();
                this.tb_trim.Text = car.trim.ToString();
                this.tb_year.Text = car.year.ToString();
                this.tb_transmission.Text = car.transmission.ToString();
                this.tb_fuelType.Text = car.fuel_type.ToString();
                this.tb_bodyType.Text = car.body_type.ToString();
                this.tb_seats.Text = car.seats.ToString();
                this.tb_doors.Text = car.doors.ToString();
            }
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Inventory inv = new Inventory();
            var serverRes = await DBA.client.PostAsJsonAsync("GetInventory", inv);
            var content = serverRes.Content.ReadAsStringAsync().Result;
            Response contentJson = JsonConvert.DeserializeObject<Response>(content.ToString());
            List<Inventory> list = new List<Inventory>();
            if (contentJson.statusCode == 200)
            {
                for (int i = 0; i < contentJson.objs.Count; i++)
                {
                    inv = JsonConvert.DeserializeObject<Inventory>(contentJson.objs[i].ToString());
                    list.Add(inv);
                }
            }
            else
            {
                MessageBox.Show(contentJson.message);
            }
            this.invDataGrid.ItemsSource = list;
        }

        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Car car = new Car();
            car.brand = this.tb_brand.Text;
            car.model = this.tb_model.Text;
            car.trim = this.tb_trim.Text;
            car.year = int.Parse(this.tb_year.Text);
            car.transmission = this.tb_transmission.Text;
            car.fuel_type = this.tb_fuelType.Text;
            car.body_type = this.tb_bodyType.Text;
            car.seats = int.Parse(this.tb_seats.Text);
            car.doors = int.Parse(this.tb_doors.Text);
            car.car_id = int.Parse(this.tb_carId.Text);
            var serverRes = await DBA.client.DeleteAsync($"DeleteCarbyId/{car.car_id}");
            var content = serverRes.Content.ReadAsStringAsync().Result;
            Response contentJson = JsonConvert.DeserializeObject<Response>(content.ToString());
            if (contentJson.statusCode == 200)
            {
                MessageBox.Show("Delete Inventory successful");
            }
            else
            {
                MessageBox.Show(contentJson.message);
            }
        }

        private async void update_Click(object sender, RoutedEventArgs e)
        {
            Inventory inv = new Inventory();
            inv.inventory_id = int.Parse(this.tb_invId.Text);
            inv.vin = this.tb_vin.Text;
            inv.color = this.tb_color.Text;
            inv.rent_price = decimal.Parse(this.tb_rent.Text);
            inv.deposit = decimal.Parse(this.tb_deposit.Text);
            inv.cost = decimal.Parse(this.tb_cost.Text);
            inv.car_id = int.Parse(this.tb_invCarId.Text);
            var serverRes = await DBA.client.PostAsJsonAsync("UpdateInventory", inv);
            var content = serverRes.Content.ReadAsStringAsync().Result;
            Response contentJson = JsonConvert.DeserializeObject<Response>(content.ToString());
            if (contentJson.statusCode == 200)
            {
                MessageBox.Show("Update Inventory successful");
            }
            else
            {
                MessageBox.Show(contentJson.message);
            }

        }

        private void invDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Inventory inv = this.invDataGrid.SelectedItem as Inventory;
            if (inv != null)
            {
                this.tb_invId.Text = inv.inventory_id.ToString();
                this.tb_vin.Text = inv.vin.ToString();
                this.tb_color.Text = inv.color.ToString();
                this.tb_rent.Text = inv.rent_price.ToString();
                this.tb_deposit.Text = inv.deposit.ToString();
                this.tb_cost.Text = inv.cost.ToString();
                this.tb_invCarId.Text = inv.car_id.ToString();
            }
        }

        private async void add_Click(object sender, RoutedEventArgs e)
        {

            Inventory inv = new Inventory();
            inv.inventory_id = int.Parse(this.tb_invId.Text);
            inv.vin = this.tb_vin.Text;
            inv.color = this.tb_color.Text;
            inv.rent_price = decimal.Parse(this.tb_rent.Text);
            inv.deposit = decimal.Parse(this.tb_deposit.Text);
            inv.cost = decimal.Parse(this.tb_cost.Text);
            inv.car_id = int.Parse(this.tb_invCarId.Text);
            var serverRes = await DBA.client.PostAsJsonAsync("AddInventory", inv);
            var content = serverRes.Content.ReadAsStringAsync().Result;
            Response contentJson = JsonConvert.DeserializeObject<Response>(content.ToString());
            if (contentJson.statusCode == 200)
            {
                MessageBox.Show("Add Inventory successful");
            }
            else
            {
                MessageBox.Show(contentJson.message);
            }

        }

        private async void find_Click(object sender, RoutedEventArgs e)
        {
            Inventory inv = new Inventory();
            inv.inventory_id = int.Parse(this.tb_invId.Text);
            inv.vin = this.tb_vin.Text;
            inv.color = this.tb_color.Text;
            inv.rent_price = decimal.Parse(this.tb_rent.Text);
            inv.deposit = decimal.Parse(this.tb_deposit.Text);
            inv.cost = decimal.Parse(this.tb_cost.Text);
            inv.car_id = int.Parse(this.tb_invCarId.Text);
            var serverRes = await DBA.client.PostAsJsonAsync("GetInventorybyId", inv);
            var content = serverRes.Content.ReadAsStringAsync().Result;
            Response contentJson = JsonConvert.DeserializeObject<Response>(content.ToString());
            if (contentJson.statusCode == 200)
            {
                MessageBox.Show("Find Inventory successful");
                inv = JsonConvert.DeserializeObject<Inventory>(contentJson.obj.ToString());
                this.tb_invId.Text = inv.inventory_id.ToString();
                this.tb_vin.Text = inv.vin.ToString();
                this.tb_color.Text = inv.color.ToString();
                this.tb_rent.Text = inv.rent_price.ToString();
                this.tb_deposit.Text = inv.deposit.ToString();
                this.tb_cost.Text = inv.cost.ToString();
                this.tb_invCarId.Text = inv.car_id.ToString();
            }
            else
            {
                MessageBox.Show("Find Inventory failed");
            }
        }

        private async void delete_Click(object sender, RoutedEventArgs e)
        {
            Inventory inv = new Inventory();
            inv.inventory_id = int.Parse(this.tb_invId.Text);
            inv.vin = this.tb_vin.Text;
            inv.color = this.tb_color.Text;
            inv.rent_price = decimal.Parse(this.tb_rent.Text);
            inv.deposit = decimal.Parse(this.tb_deposit.Text);
            inv.cost = decimal.Parse(this.tb_cost.Text);
            inv.car_id = int.Parse(this.tb_invCarId.Text);
            var serverRes = await DBA.client.DeleteAsync($"DeleteInventorybyId/{inv.inventory_id}");
            var content = serverRes.Content.ReadAsStringAsync().Result;
            Response contentJson = JsonConvert.DeserializeObject<Response>(content.ToString());
            if (contentJson.statusCode == 200)
            {
                MessageBox.Show("Delete Inventory successful");
            }
            else
            {
                MessageBox.Show(contentJson.message);
            }
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        
    }
}
