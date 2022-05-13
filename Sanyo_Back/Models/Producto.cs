namespace Sanyo_Back.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            Compra = new HashSet<Compra>();
            detalle_pedido = new HashSet<detalle_pedido>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_producto { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre_producto { get; set; }

        [Required]
        [StringLength(100)]
        public string descripcion_producto { get; set; }

        public double precio { get; set; }

        public int tipoProducto_id_tipoProducto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_pedido> detalle_pedido { get; set; }

        public virtual TipoProducto TipoProducto { get; set; }
    }
}
