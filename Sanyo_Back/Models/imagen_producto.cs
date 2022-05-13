namespace Sanyo_Back.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class imagen_producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_imagen { get; set; }

        public byte[] imagen { get; set; }

        public int? id_producto { get; set; }
    }
}
