namespace Sanyo_Back.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Telefono")]
    public partial class Telefono
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_telefono { get; set; }

        public int numero { get; set; }

        public int usuario_documento { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
