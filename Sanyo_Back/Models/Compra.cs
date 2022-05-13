namespace Sanyo_Back.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Compra")]
    public partial class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_compra { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_compra { get; set; }

        public double? total { get; set; }

        public double? descuentos { get; set; }

        public int usuario_documento { get; set; }

        public int producto_id_producto { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
