using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ListaModel
    {
            [Key]
            public int id_lista { get; set; }
            public string nombre { get; set; }
            public string descripcion { get; set; }
            public string privacidad { get; set; }
            public DateTime fechacreacion { get; set; }
            public bool activo { get; set; }
        }
    }

