using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Npgsql;
using RestApiCarRental.Models;

namespace RestApiCarRental.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public partial class CarRentalController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        
        public CarRentalController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllCustomer")]
        public CustomerAuthorityResponse GetAllProducts()
        {
            CustomerAuthorityResponse response = new CustomerAuthorityResponse();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.GetAllCustomer(con);

            return response;
        }

        [HttpGet]
        [Route("GetCustomerbyUsername/{username}")]
        public CustomerAuthorityResponse GetCustomerbyUsername(string username)
        {
            CustomerAuthorityResponse response = new CustomerAuthorityResponse();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.GetCustomerbyUsername(con, username);

            return response;
        }

        [HttpPost]
        [Route("AddCustomer")]
        public CustomerAuthorityResponse AddCustomer(CustomerAuthority customer)
        {
            CustomerAuthorityResponse response = new CustomerAuthorityResponse();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.AddCustomer(con, customer);

            return response;
        }

        [HttpPost]
        [Route("AddStaff")]
        public Response AddStaff(Staff staff)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.AddStaff(con, staff);

            return response;
        }


        [HttpPost]
        [Route("CheckAuthority")]
        public CustomerAuthorityResponse CheckAuthority(CustomerAuthority customer)
        {
            CustomerAuthorityResponse response = new CustomerAuthorityResponse();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.CheckAuthority(con, customer);

            return response;
        }


        [HttpPost]
        [Route("StaffLogin")]
        public Response StaffLogin(Staff staff)
        {
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("CustomerAuthorityConnection"));
            DbAppCarRental dba = new DbAppCarRental();
            response = dba.StaffLogin(con, staff);

            return response;
        }



        


        
    }
}
