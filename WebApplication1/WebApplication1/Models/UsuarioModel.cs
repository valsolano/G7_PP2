namespace WebApplication1.Models
{
   

        public class UsuarioModel
        {
            public int IdUsuario { get; set; }
            public string Nombre { get; set; }
            public string Apellidos { get; set; }
            public string Correo { get; set; }
            public string Username { get; set; }
            public string Contrasena { get; set; }
            public bool Activo { get; set; }

            public UsuarioModel() { }

            public UsuarioModel(int idUsuario, string nombre, string apellidos, string correo, string username, string contrasena, bool activo)
            {
                IdUsuario = idUsuario;
                Nombre = nombre;
                Apellidos = apellidos;
                Correo = correo;
                Username = username;
                Contrasena = contrasena;
                Activo = activo;
            }
        }
    }

