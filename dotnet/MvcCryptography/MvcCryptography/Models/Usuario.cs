using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

#region SQL
//CREATE TABLE USERS
//(IDUSUARIO INT PRIMARY KEY,
//NOMBRE NVARCHAR(50),
//EMAIL NVARCHAR(100),
//PASS VARBINARY(MAX),
//SALT NVARCHAR(50),
//IMAGEN NVARCHAR(150));
#endregion

namespace MvcCryptography.Models
{
    [Table("USERS")]
    public class Usuario
    {
        [Key]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("SALT")]
        public string Salt { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
        [Column("PASS")]
        public byte[] Password { get; set; }
    }
}
