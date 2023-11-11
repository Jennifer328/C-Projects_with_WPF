using Npgsql;
using System.Data;

namespace RestApiCarRental.Models
{
    public partial class DbAppCarRental //DbAppInventory
    {
        public Response AddInventory(NpgsqlConnection con, Inventory inv)
        {
            Response response = new Response();
            con.Open();
            string query = $"insert into car_rental.inventory values(default,'{inv.vin}',  '{inv.color}', {inv.rent_price}, {inv.deposit},   {inv.cost}, {inv.car_id})";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            Console.WriteLine(query);
            response.statusCode = 100;
            response.message = "Insertion failed";
            response.obj = null;
            response.objs = null;
            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    response.statusCode = 200;
                    response.message = "Insertion Successful";
                    response.obj = inv;
                    response.objs = null;

                }
            }
            catch (Exception ex)
            {
                response.message = "Insertion failed: " + ex.ToString() ;
            }
            
            con.Close();
            return response;
        }

        public Response DeleteInventorybyId(NpgsqlConnection con, int id)
        {
            con.Open();
            Response response = new Response();
            string query = "delete from car_rental.inventory where inventory_id='" + id + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);

            response.statusCode = 100;
            response.message = "Delete failed";
            response.obj = null;
            response.objs = null;
            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    response.statusCode = 200;
                    response.message = "Delete successfully";
                    response.obj = null;
                    response.objs = null;
                }
            }
            catch (Exception ex)
            {
                response.message = "Delete failed: " + ex.ToString();
            }
            
            con.Close();
            return response;
        }

        public Response UpdateInventory(NpgsqlConnection con, Inventory inv)
        {
            Response response = new Response();
            con.Open();
            string query = $"update car_rental.inventory set vin='{inv.vin}', color='{inv.color}', rent_price={inv.rent_price}," +
                $"deposit={inv.deposit}, cost={inv.cost}, car_id={inv.car_id} where inventory_id={inv.inventory_id}";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            response.statusCode = 100;
            response.message = "failed to update";
            response.obj = inv;
            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    response.statusCode = 200;
                    response.message = "Update successfully";
                    response.obj = inv;
                }
            }
            catch (Exception ex)
            {
                response.message = "failed to update: " + ex.ToString();
            }

            con.Close();
            return response;
        }

        public Response GetInventorybyCarId(NpgsqlConnection con, int id)
        {
            Response response = new Response();
            string query = $"select * from car_rental.inventory where car_id={id}";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                List<object> list = new List<object>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Inventory inve = new Inventory();
                    inve.inventory_id = (int)dt.Rows[i]["inventory_id"];
                    inve.vin = (string)dt.Rows[i]["vin"];
                    inve.color = (string)dt.Rows[i]["color"];
                    inve.rent_price = (decimal)dt.Rows[i]["rent_price"];
                    inve.deposit = (decimal)dt.Rows[i]["deposit"];
                    inve.deposit = (decimal)dt.Rows[i]["deposit"];
                    inve.cost = (decimal)dt.Rows[i]["cost"];
                    inve.car_id = (int)dt.Rows[i]["car_id"];
                    list.Add(inve);
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

        public Response GetInventorybyId(NpgsqlConnection con, int id)
        {
            Response response = new Response();
            string query = $"select * from car_rental.inventory where inventory_id={id}";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                List<object> list = new List<object>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Inventory inv = new Inventory();
                    inv.inventory_id = (int)dt.Rows[i]["inventory_id"];
                    inv.vin = (string)dt.Rows[i]["vin"];
                    inv.color = (string)dt.Rows[i]["color"];
                    inv.rent_price = (decimal)dt.Rows[i]["rent_price"];
                    inv.deposit = (decimal)dt.Rows[i]["deposit"];
                    inv.deposit = (decimal)dt.Rows[i]["deposit"];
                    inv.cost = (decimal)dt.Rows[i]["cost"];
                    inv.car_id = (int)dt.Rows[i]["car_id"];
                    list.Add(inv);
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


        public Response GetInventory(NpgsqlConnection con)
        {
            Response response = new Response();
            string query = $"select * from car_rental.inventory";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                List<object> list = new List<object>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Inventory inv = new Inventory();
                    inv.inventory_id = (int)dt.Rows[i]["inventory_id"];
                    inv.vin = (string)dt.Rows[i]["vin"];
                    inv.color = (string)dt.Rows[i]["color"];
                    inv.rent_price = (decimal)dt.Rows[i]["rent_price"];
                    inv.deposit = (decimal)dt.Rows[i]["deposit"];
                    inv.deposit = (decimal)dt.Rows[i]["deposit"];
                    inv.cost = (decimal)dt.Rows[i]["cost"];
                    inv.car_id = (int)dt.Rows[i]["car_id"];
                    list.Add(inv);
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
