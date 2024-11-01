using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class TareaModel
    {
        [Key]
        public int id_tarea { get; set; }

        public string accion { get; set; }

        public DateTime fecha_accion { get; set; }

        public int id_ususario { get; set; }

        public int id_lista { get; set; }
    }
}
