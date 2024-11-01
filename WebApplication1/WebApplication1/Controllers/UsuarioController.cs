using System;
using System.Collections.Generic;
using WebApplication1.Models;

public class UsuarioController
{
    private List<UsuarioModel> usuarios = new List<UsuarioModel>();

    // Crear un nuevo usuario
    public void CrearUsuario(UsuarioModel usuario)
    {
        usuarios.Add(usuario);
        Console.WriteLine("Usuario creado correctamente.");
    }

    // Leer (obtener) un usuario por ID
    public UsuarioModel ObtenerUsuarioPorId(int id)
    {
        return usuarios.Find(u => u.IdUsuario == id);
    }

    // Leer (obtener) todos los usuarios
    public List<UsuarioModel> ObtenerTodosLosUsuarios()
    {
        return usuarios;
    }

    // Actualizar un usuario existente
    public void ActualizarUsuario(int id, UsuarioModel usuarioActualizado)
    {
        UsuarioModel usuario = ObtenerUsuarioPorId(id);
        if (usuario != null)
        {
            usuario.Nombre = usuarioActualizado.Nombre;
            usuario.Apellidos = usuarioActualizado.Apellidos;
            usuario.Correo = usuarioActualizado.Correo;
            usuario.Username = usuarioActualizado.Username;
            usuario.Contrasena = usuarioActualizado.Contrasena;
            usuario.Activo = usuarioActualizado.Activo;
            Console.WriteLine("Usuario actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("Usuario no encontrado");

        }
    }

}
