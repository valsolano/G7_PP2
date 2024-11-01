using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
        private readonly ConnectionDbContext _dbContext;

        public TareaController(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TareaModel>> GetTareas()
        {
            return Ok(_dbContext.Tarea_G7.ToList());
        }

        [HttpGet("{_id}")]
        public ActionResult<IEnumerable<TareaModel>> GetTareaById(int _id)
        {
            var datos = _dbContext.Tarea_G7.Find(_id);

            if (datos == null)
            {
                return NotFound($"No se pudo encontrar la tarea con el id {_id}");
            }

            return Ok(datos);
        }

        [HttpPost]

        public IActionResult AgregarTarea(TareaModel _tarea)
        {
            try
            {
                _dbContext.Tarea_G7.Add(_tarea);
                _dbContext.SaveChanges();
                return Ok("Tarea agregada");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]

        public IActionResult ModificarTarea(TareaModel _tarea)
        {
            try
            {
                if (!ConsultarDatos(_tarea.id_tarea))
                {
                    return NotFound($"La tarea buscada no existe.");
                }

                _dbContext.Entry(_tarea).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return Ok("Tarea modificada");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{_id}")]
        public ActionResult<IEnumerable<TareaModel>> EliminarTarea(int _id)
        {
            try
            {
                if (!ConsultarDatos(_id))
                {
                    return NotFound($"La tarea buscada no existe.");
                }

                var datos = _dbContext.Tarea_G7.Find(_id);

                _dbContext.Tarea_G7.Remove(datos);
                _dbContext.SaveChanges();

                return Ok($"Se elimino la tarea con el id {_id}");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        private bool ConsultarDatos(int _id)
        {
            return _dbContext.Tarea_G7.Any(x => x.id_tarea == _id);
        }
    }
}
