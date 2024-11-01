using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancionController : ControllerBase
    {

        private readonly ConnectionDbContext _dbContext;

        public CancionController(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CancionModel>> GetCanciones()
        {
            return Ok(_dbContext.Cancion_G7.ToList());
        }

        [HttpGet("{_id}")]
        public ActionResult<IEnumerable<CancionModel>> GetCancionById(int _id)
        {
            var datos = _dbContext.Cancion_G7.Find(_id);

            if(datos == null)
            {
                return NotFound($"La cancion con el ID: {_id} no existe.");
            }

            return Ok(datos);
        }

        [HttpPost]
        public IActionResult AddCancion(CancionModel cancion)
        {
            try
            {
                _dbContext.Cancion_G7.Add(cancion);
                _dbContext.SaveChanges();

                return Ok("Cancion agregada exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult ModifyCancion(CancionModel cancion)
        {
            try
            {
                if (!VerifyIfExists(cancion.id_cancion))
                {
                    return NotFound("La cancion buscada no existe");
                }

                _dbContext.Entry(cancion).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return Ok($"Se modifico correctamente la cancion con el id {cancion.id_cancion}");
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{_id}")]
        public IActionResult deleteCancion(int _id)
        {
            try
            {
                if (!VerifyIfExists(_id))
                {
                    return NotFound("La cancion buscada no existe");
                }

                var datos = _dbContext.Cancion_G7.Find(_id);

                _dbContext.Cancion_G7.Remove(datos);
                _dbContext.SaveChanges();

                return Ok($"Se elimino correctamente la cancion con el id {_id}");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }

        private bool VerifyIfExists(int _id)
        {
            return _dbContext.Cancion_G7.Any(x => x.id_cancion == _id);
        }
    }
}
