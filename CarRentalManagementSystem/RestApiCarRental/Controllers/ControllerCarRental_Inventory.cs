using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RestApiCarRental.Models;

namespace RestApiCarRental.Controllers
{
    public partial class CarRentalController 
    {
        /*************************************************
         * Inventory
         */

        [HttpPost]
        [Route("AddInventory")]
        public Response AddInventory(Inventory inv)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.AddInventory(con, inv);

            return response;
        }

        [HttpDelete]
        [Route("DeleteInventorybyId/{id}")]
        public Response DeleteInventorybyId(int id)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.DeleteInventorybyId(con, id);
            return response;
        }

        //[HttpPut]
        [HttpPost]
        [Route("UpdateInventory")]
        public Response UpdateInventory(Inventory inv)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.UpdateInventory(con, inv);

            return response;
        }

        [HttpPost]
        [Route("GetInventorybyCarId")]
        public Response GetInventorybyCarId(Inventory inv)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.GetInventorybyCarId(con, inv.car_id);

            return response;
        }

        [HttpPost]
        [Route("GetInventorybyId")]
        public Response GetInventorybyId(Inventory inv)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.GetInventorybyId(con, inv.inventory_id);

            return response;
        }

        [HttpPost]
        [Route("GetInventory")]
        public Response GetInventory(Inventory inv)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.GetInventory(con);

            return response;
        }

    }
}
