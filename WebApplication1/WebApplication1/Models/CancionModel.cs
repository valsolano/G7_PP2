using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CancionModel
    {
        [Key]
        public int id_cancion { get; set; }
        public string nombre { get; set; }
        public string album { get; set; }
        public int num_reproducciones { get; set; }
        public int duracion { get; set; }
        public string genero { get; set; }

    }
}
