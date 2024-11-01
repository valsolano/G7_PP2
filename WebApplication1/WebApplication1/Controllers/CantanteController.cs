using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CantanteController : ControllerBase
    {
        private readonly ConnectionDbContext _dbContext;

        public CantanteController(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CantanteModel>> GetCantantes()
        {
            return Ok(_dbContext.Cantante_G7.ToList());
        }

        [HttpGet("{_id}")]
        public ActionResult<IEnumerable<CantanteModel>> GetCantanteById(int _id)
        {
            var datos = _dbContext.Cantante_G7.Find(_id);

            if (datos == null)
            {
                return NotFound($"El cantante con el ID: {_id} no existe.");
            }

            return Ok(datos);
        }

        [HttpPost]
        public IActionResult AgregarCantante(CantanteModel _cantante)
        {
            try
            {
                _dbContext.Cantante_G7.Add(_cantante);
                _dbContext.SaveChanges();
                return Ok("Cantante agregado");

            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]

        public IActionResult ModificarCantante(CantanteModel _cantante)
        {
            try
            {
                if (!ConsultarDatos(_cantante.id_cantante))
                {
                    return NotFound($"El cantante buscado no existe.");
                }

                _dbContext.Entry(_cantante).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return Ok("Cantante agregado");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{_id}")]
        public ActionResult<IEnumerable<CantanteModel>> EliminarCantante(int _id)
        {
            try
            {
                if (!ConsultarDatos(_id))
                {
                    return NotFound($"El cantante buscado no existe.");
                }

                var datos = _dbContext.Cantante_G7.Find(_id);

                _dbContext.Cantante_G7.Remove(datos);
                _dbContext.SaveChanges();

                return Ok($"Se elimino el cantante con el id {_id}");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        private bool ConsultarDatos(int _id)
        {
            return _dbContext.Cantante_G7.Any(x => x.id_cantante == _id);
        }
    }
}
