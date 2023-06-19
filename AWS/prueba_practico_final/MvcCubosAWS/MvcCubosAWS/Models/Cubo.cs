﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcCubosAWS.Models {
    [Table("CUBOS")]
    public class Cubo {
        [Key] [Column("id_cubo")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("marca")]
        public string Marca { get; set; }

        [Column("imagen")]
        public string Imagen { get; set; }

        [Column("precio")]
        public int Precio { get; set; }
    }
}
