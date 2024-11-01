using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private static List<UsuarioModel> usuarios = new List<UsuarioModel>();

    // GET: api/usuario - Obtener todos los usuarios
    [HttpGet]
    public ActionResult<List<UsuarioModel>> ObtenerTodosLosUsuarios()
    {
        return usuarios;
    }

    // GET: api/usuario/{id} - Obtener un usuario por ID
    [HttpGet("{id}")]
    public ActionResult<UsuarioModel> ObtenerUsuarioPorId(int id)
    {
        var usuario = usuarios.FirstOrDefault(u => u.IdUsuario == id);
        if (usuario == null)
        {
            return NotFound("Usuario no encontrado.");
        }
        return usuario;
    }

    // POST: api/usuario - Crear un nuevo usuario
    [HttpPost]
    public ActionResult CrearUsuario([FromBody] UsuarioModel nuevoUsuario)
    {
        nuevoUsuario.IdUsuario = usuarios.Count > 0 ? usuarios.Max(u => u.IdUsuario) + 1 : 1;
        usuarios.Add(nuevoUsuario);
        return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { id = nuevoUsuario.IdUsuario }, nuevoUsuario);
    }

    // PUT: api/usuario/{id} - Actualizar un usuario existente
    [HttpPut("{id}")]
    public ActionResult ActualizarUsuario(int id, [FromBody] UsuarioModel usuarioActualizado)
    {
        var usuario = usuarios.FirstOrDefault(u => u.IdUsuario == id);
        if (usuario == null)
        {
            return NotFound("Usuario no encontrado.");
        }

        usuario.Nombre = usuarioActualizado.Nombre;
        usuario.Apellidos = usuarioActualizado.Apellidos;
        usuario.Correo = usuarioActualizado.Correo;
        usuario.Username = usuarioActualizado.Username;
        usuario.Contrasena = usuarioActualizado.Contrasena;
        usuario.Activo = usuarioActualizado.Activo;

        return NoContent();
    }

    // DELETE: api/usuario/{id} - Eliminar un usuario
    [HttpDelete("{id}")]
    public ActionResult EliminarUsuario(int id)
    {
        var usuario = usuarios.FirstOrDefault(u => u.IdUsuario == id);
        if (usuario == null)
        {
            return NotFound("Usuario no encontrado.");
        }

        usuarios.Remove(usuario);
        return NoContent();
    }

}
