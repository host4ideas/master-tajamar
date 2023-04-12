using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
    CREATE TABLE CHOLLOS
    (IDCHOLLO INT PRIMARY KEY,
    TITULO NVARCHAR(MAX),
    LINK NVARCHAR(MAX),
    DESCRIPCION NVARCHAR(MAX),
    FECHA DATETIME);
*/

namespace MvcWebJobChollometro.Models
{
    [Table("CHOLLOS")]
    public class Chollo
    {
        [Key]
        [Column("IDCHOLLO")]
        public int IdChollo { get; set; }
        [Column("TITULO")]
        public string Titulo { get; set; }
        [Column("LINK")]
        public string Link { get; set; }
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
    }
}
