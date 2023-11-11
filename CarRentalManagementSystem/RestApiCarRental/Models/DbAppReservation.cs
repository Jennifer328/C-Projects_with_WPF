using Npgsql;
using System.Data;

namespace RestApiCarRental.Models
{
    public partial class DbAppCarRental //DbAppInventory
    {
        public Response AddReservation(NpgsqlConnection con, Reservation res)
        {
            Response response = new Response();
            con.Open();
            string query = $"insert into car_rental.reservation values(default,'{res.reservation_time.ToString("yyyy/MM/dd HH:mm:ss")}'," +
                $"  '{res.delivery_time.ToString("yyyy/MM/dd HH:mm:ss")}', '{res.return_time.ToString("yyyy/MM/dd HH:mm:ss")}', " +
                $"{res.customer_id}, {res.inventory_id});";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            Console.WriteLine(query);
            if (cmd.ExecuteNonQuery() > 0)
            {
                response.statusCode = 200;
                response.message = "Insertion Successful";
                response.obj = res;
                response.objs = null;

            }
            else
            {
                response.statusCode = 100;
                response.message = "Insertion failed";
                response.obj = null;
                response.objs = null;
            }
            con.Close();
            return response;
        }

        public Response DeleteReservationbyId(NpgsqlConnection con, int id)
        {
            con.Open();
            Response response = new Response();
            string query = "delete from car_rental.reservation where reservation_id='" + id + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);

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
            con.Close();
            return response;
        }

        public Response UpdateReservation(NpgsqlConnection con, Reservation e)
        {
            Response response = new Response();
            con.Open();
            string query = $"update car_rental.reservation set reservation_time='{e.reservation_time}', " +
                $"delivery_time='{e.delivery_time}', return_time='{e.return_time}'," +
                $"customer_id={e.customer_id}, inventory_id={e.inventory_id} where reservation_id={e.reservation_id}";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);

            if (cmd.ExecuteNonQuery() > 0)
            {
                response.statusCode = 200;
                response.message = "Update successfully";
                response.obj = e;
            }
            else
            {
                response.statusCode = 100;
                response.message = "failed to update";
            }

            con.Close();
            return response;
        }

        public Response GetReservationbyId(NpgsqlConnection con, int id)
        {
            Response response = new Response();
            string query = $"select * from car_rental.reservation where reservation_id={id}";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                List<object> list = new List<object>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reservation e = new Reservation();
                    e.reservation_id = (int)dt.Rows[i]["reservation_id"];
                    e.reservation_time = (DateTime)dt.Rows[i]["reservation_time"];
                    e.delivery_time = (DateTime)dt.Rows[i]["delivery_time"];
                    e.return_time= (DateTime)dt.Rows[i]["return_time"];
                    e.customer_id = (int)dt.Rows[i]["customer_id"];
                    e.inventory_id = (int)dt.Rows[i]["inventory_id"];
                    list.Add(e);
                }

                response.statusCode = 200;
                response.message = "Data retriving successful";
                response.obj = list?[0];
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

        public Response GetReservationbyCustomerId(NpgsqlConnection con, int id)
        {
            Response response = new Response();
            string query = $"select * from car_rental.reservation where customer_id={id}";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                List<object> list = new List<object>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reservation e = new Reservation();
                    e.reservation_id = (int)dt.Rows[i]["reservation_id"];
                    e.reservation_time = (DateTime)dt.Rows[i]["reservation_time"];
                    e.delivery_time = (DateTime)dt.Rows[i]["delivery_time"];
                    e.return_time = (DateTime)dt.Rows[i]["return_time"];
                    e.customer_id = (int)dt.Rows[i]["customer_id"];
                    e.inventory_id = (int)dt.Rows[i]["inventory_id"];
                    list.Add(e);
                }

                response.statusCode = 200;
                response.message = "Data retriving successful";
                response.obj = list?[0];
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


        public Response GetReservationbyInventoryId(NpgsqlConnection con, int id)
        {
            Response response = new Response();
            string query = $"select * from car_rental.reservation where inventory_id={id}";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                List<object> list = new List<object>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reservation e = new Reservation();
                    e.reservation_id = (int)dt.Rows[i]["reservation_id"];
                    e.reservation_time = (DateTime)dt.Rows[i]["reservation_time"];
                    e.delivery_time = (DateTime)dt.Rows[i]["delivery_time"];
                    e.return_time = (DateTime)dt.Rows[i]["return_time"];
                    e.customer_id = (int)dt.Rows[i]["customer_id"];
                    e.inventory_id = (int)dt.Rows[i]["inventory_id"];
                    list.Add(e);
                }

                response.statusCode = 200;
                response.message = "Data retriving successful";
                response.obj = list?[0];
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
