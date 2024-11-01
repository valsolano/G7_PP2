using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ListaController : ControllerBase
    {
        private readonly ConnectionDbContext _dbContext;

        public ListaController(ConnectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ListaModel>> GetLista()
        {
            return Ok(_dbContext.Lista_G7.ToList());
        }

        [HttpGet("{_id}")]
        public ActionResult<IEnumerable<ListaModel>> GetListaById(int _id)
        {
            var datos = _dbContext.Lista_G7.Find(_id);

            if (datos == null)
            {
                return NotFound($"La Lista con el ID: {_id} no existe.");
            }

            return Ok(datos);
        }

        [HttpPost]
        public IActionResult AddLista(ListaModel lista)
        {
            try
            {
                _dbContext.Lista_G7.Add(lista);
                _dbContext.SaveChanges();

                return Ok("Lista agregada exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult ModifyLista(ListaModel lista)
        {
            try
            {
                if (!VerifyIfExists(lista.id_lista))
                {
                    return NotFound("La lista buscada no existe");
                }

                _dbContext.Entry(lista).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return Ok($"Se modifico correctamente la lista con el id {lista.id_lista}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{_id}")]
        public IActionResult deleteLista(int _id)
        {
            try
            {
                if (!VerifyIfExists(_id))
                {
                    return NotFound("La lista buscada no existe");
                }

                var datos = _dbContext.Lista_G7.Find(_id);

                _dbContext.Lista_G7.Remove(datos);
                _dbContext.SaveChanges();

                return Ok($"Se elimino correctamente la lista con el id {_id}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }

        private bool VerifyIfExists(int _id)
        {
            return _dbContext.Lista_G7.Any(x => x.id_lista == _id);
        }
    }
}
