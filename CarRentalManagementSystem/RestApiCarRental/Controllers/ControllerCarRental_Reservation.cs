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
        [Route("AddReservation")]
        public Response AddReservation(Reservation e)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.AddReservation(con, e);

            return response;
        }

        [HttpDelete]
        [Route("DeleteReservationbyId/{id}")]
        public Response DeleteReservationbyId(int id)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.DeleteReservationbyId(con, id);
            return response;
        }

        [HttpPut]
        [Route("UpdateReservation")]
        public Response UpdateReservation(Reservation e)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.UpdateReservation(con, e);

            return response;
        }

        [HttpPost]
        [Route("GetReservationbyId")]
        public Response GetReservationbyId(int id)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.GetReservationbyId(con, id);

            return response;
        }

        [HttpPost]
        [Route("GetReservationbyCustomerId")]
        public Response GetReservationbyCustomerId(CustomerAuthority customer)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.GetReservationbyCustomerId(con, customer.id);

            return response;
        }

        [HttpPost]
        [Route("GetReservationbyInventoryId")]
        public Response GetReservationbyInventoryId(int id)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.GetReservationbyInventoryId(con, id);

            return response;
        }

    }
}
