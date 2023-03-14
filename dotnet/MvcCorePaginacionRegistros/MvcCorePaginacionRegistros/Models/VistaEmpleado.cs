using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCorePaginacionRegistros.Models
{
    public class VistaEmpleado
    {
        [Key]
        [Column("EMP_NO")]
        public int EmpNo { get; set; }
        [Column("APELLIDO")]
        public int Apellido { get; set; }
        [Column("OFICIO")]
        public int Oficio { get; set; }
        [Column("POSICION")]
        public int Posicion { get; set; }
    }
}
