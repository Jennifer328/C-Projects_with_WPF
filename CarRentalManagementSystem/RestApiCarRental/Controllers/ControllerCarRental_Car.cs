using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RestApiCarRental.Models;

namespace RestApiCarRental.Controllers
{
    public partial class CarRentalController 
    {
        [HttpPost]
        [Route("AddCar")]
        public Response AddCar(Car car)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.AddCar(con, car);

            return response;
        }

        [HttpDelete]
        [Route("DeleteCarbyId/{id}")]
        public Response DeleteCarbyId(int id)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.DeleteCarbyId(con, id);
            return response;
        }

        //[HttpPut]
        [HttpPost]
        [Route("UpdateCar")]
        public Response UpdateCar(Car car)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.UpdateCar(con, car);

            return response;
        }

        [HttpPost]
        [Route("GetCarbyFilter")]
        public Response GetCarbyFilter(Car car)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.GetCarbyFilter(con, car);

            return response;
        }

        [HttpPost]
        [Route("GetCarbyId")]
        public Response GetCarbyId(Car car)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.GetCarbyId(con, car.car_id);

            return response;
        }
    }
}
