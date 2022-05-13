namespace Sanyo_Back.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class detalle_pedido
    {
        [Key]
        [StringLength(50)]
        public string id_stock { get; set; }

        public int cantidadSolicitada { get; set; }

        [StringLength(200)]
        public string observaciones { get; set; }

        public int pedido_id_pedido { get; set; }

        public int producto_id_producto { get; set; }

        public virtual Pedido Pedido { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
