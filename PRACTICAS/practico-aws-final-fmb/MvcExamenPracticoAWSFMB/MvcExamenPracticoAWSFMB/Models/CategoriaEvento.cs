using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPracticoAWSFMB.Models
{
    public class CategoriaEvento
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
    }
}
