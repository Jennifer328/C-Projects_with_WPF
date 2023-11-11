using Npgsql;
using System.Data;

namespace RestApiCarRental.Models
{
    public partial class DbAppCarRental //DbAppInventory
    {
        /**************************************************************************
         * Car
         */
        public Response AddCar(NpgsqlConnection con, Car car)
        {
            Response response = new Response();
            con.Open();
            string query = $"insert into car_rental.car values(default,'{car.brand}',  '{car.model}', '{car.trim}', {car.year},   '{car.transmission}', '{car.fuel_type}', '{car.body_type}', {car.seats}, {car.doors} )";
            //string query = "insert into car_rental.car values(default, @user_name, @password, @salt, @phone, @email)";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            Console.WriteLine(query);
            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    response.statusCode = 200;
                    response.message = "Insertion Successful";
                    response.obj = car;
                    response.objs = null;

                }
                else
                {
                    response.statusCode = 100;
                    response.message = "Insertion failed";
                    response.obj = null;
                    response.objs = null;
                }
            }
            catch (Exception ex)
            {
                response.statusCode = 100;
                response.message = "Insertion failed: " + ex.ToString();
                response.obj = null;
                response.objs = null;
            }

            con.Close();
            return response;
        }

        public Response DeleteCarbyId(NpgsqlConnection con, int id)
        {
            con.Open();
            Response response = new Response();
            string query = "delete from car_rental.car where car_id='" + id + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);

            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    response.statusCode = 200;
                    response.message = "Delete successfully";
                    response.obj = null;
                    response.objs = null;
                }
                else
                {
                    response.statusCode = 100;
                    response.message = "Delete failed";
                    response.obj = null;
                    response.objs = null;
                }
            }
            catch (Exception ex)
            {
                response.statusCode = 100;
                response.message = "Delete failed: " + ex.ToString();
                response.obj = null;
                response.objs = null;
            }
            con.Close();
            return response;
        }

        public Response UpdateCar(NpgsqlConnection con, Car car)
        {
            Response response = new Response();
            con.Open();
            string query = $"update car_rental.car set brand='{car.brand}', model='{car.model}', trim='{car.trim}'," +
                $"year={car.year}, transmission='{car.transmission.ToLower()}', fuel_type='{car.fuel_type.ToLower()}', body_type='{car.body_type.ToLower()}'," +
                $"seats={car.seats}, doors={car.doors} where car_id={car.car_id}";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);

            if (cmd.ExecuteNonQuery() > 0)
            {
                response.statusCode = 200;
                response.message = "Update successfully";
                response.obj = car;
            }
            else
            {
                response.statusCode = 100;
                response.message = "failed to update";
            }

            con.Close();
            return response;
        }

        public Response GetCarbyFilter(NpgsqlConnection con, Car car)
        {
            Response response = new Response();
            string transmission = $"('{car.transmission}')";
            if ("any".Equals(car.transmission?.ToLower()))
            {
                transmission = "('manual','auto')";
            }

            string fuel_type = $"('{car.fuel_type}')";
            if ("any".Equals(car.fuel_type?.ToLower()))
            {
                fuel_type = "('gasoline','electric', 'hybird')";
            }

            string body_type = $"('{car.body_type}')";
            if ("any".Equals(car.body_type?.ToLower()))
            {
                body_type = "('suv','sedan')";
            }

            string query = $"select * from car_rental.car where transmission IN {transmission} and fuel_type IN {fuel_type} and body_type IN {body_type} ";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                object obj = new Car();
                List<object> list = new List<object>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Car c = new Car();
                    c.car_id = (int)dt.Rows[i]["car_id"];
                    c.brand = (string)dt.Rows[i]["brand"];
                    c.model = (string)dt.Rows[i]["model"];
                    c.trim = (string)dt.Rows[i]["trim"];
                    c.year = (int)dt.Rows[i]["year"];
                    c.transmission = (string)dt.Rows[i]["transmission"];
                    c.fuel_type = (string)dt.Rows[i]["fuel_type"];
                    c.body_type = (string)dt.Rows[i]["body_type"];
                    c.seats = (int)dt.Rows[i]["seats"];
                    c.doors = (int)dt.Rows[i]["doors"];
                    list.Add(c);
                }

                response.statusCode = 200;
                response.message = "Data retriving successful";
                response.obj = null;
                response.objs = list;
            }
            else
            {
                response.statusCode = 100;
                response.message = "Data retriving failed";
                response.obj = null;
                response.objs = null;
            }
            return response;

        }

        public Response GetCarbyId(NpgsqlConnection con, int id)
        {
            Response response = new Response();

            string query = $"select * from car_rental.car where car_id={id}";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                object obj = new Car();
                List<object> list = new List<object>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Car c = new Car();
                    c.car_id = (int)dt.Rows[i]["car_id"];
                    c.brand = (string)dt.Rows[i]["brand"];
                    c.model = (string)dt.Rows[i]["model"];
                    c.trim = (string)dt.Rows[i]["trim"];
                    c.year = (int)dt.Rows[i]["year"];
                    c.transmission = (string)dt.Rows[i]["transmission"];
                    c.fuel_type = (string)dt.Rows[i]["fuel_type"];
                    c.body_type = (string)dt.Rows[i]["body_type"];
                    c.seats = (int)dt.Rows[i]["seats"];
                    c.doors = (int)dt.Rows[i]["doors"];
                    list.Add(c);
                }

                response.statusCode = 200;
                response.message = "Data retriving successful";
                response.obj = list[0];
                response.objs = list;
            }
            else
            {
                response.statusCode = 100;
                response.message = "Data retriving failed";
                response.obj = null;
                response.objs = null;
            }
            return response;

        }

    }
}
