using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConnectionController : ControllerBase
    {
        //appsettings
        private readonly IConfiguration _configuration;

        public ConnectionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult Connect()
        {
            string connectionString = _configuration.GetConnectionString("connData");

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    return Ok("Conexion exitosa");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
