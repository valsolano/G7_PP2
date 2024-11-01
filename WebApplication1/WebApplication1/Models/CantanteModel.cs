using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Models
{
    public class CantanteModel
    {

        [Key]
        public int id_cantante { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

    }
}
