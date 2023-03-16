using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcNetCoreZapatillas.Models
{
    [Table("V_IMAGENZAPATILLA_INDIVIDUAL")]
    public class VistaImagenZapatilla
    {
        [Key]
        [Column("IDIMAGEN")]
        public int IdImagen { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
        [Column("IDPRODUCTO")]
        public int IdProducto { get; set; }
    }
}
