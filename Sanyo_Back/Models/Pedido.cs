namespace Sanyo_Back.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pedido")]
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            detalle_pedido = new HashSet<detalle_pedido>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_pedido { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_pedido { get; set; }

        [Required]
        [StringLength(100)]
        public string descripcion { get; set; }

        public double? descuentos { get; set; }

        public double? total { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_entrega { get; set; }

        public int usuario_documento { get; set; }

        public int proveedor_nit_empresa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_pedido> detalle_pedido { get; set; }

        public virtual Proveedor Proveedor { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
