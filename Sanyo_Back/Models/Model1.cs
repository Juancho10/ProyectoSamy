using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Sanyo_Back.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModelSanyo")
        {
        }

        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<detalle_pedido> detalle_pedido { get; set; }
        public virtual DbSet<imagen_producto> imagen_producto { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Telefono> Telefono { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<detalle_pedido>()
                .Property(e => e.id_stock)
                .IsUnicode(false);

            modelBuilder.Entity<detalle_pedido>()
                .Property(e => e.observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Pedido>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Pedido>()
                .HasMany(e => e.detalle_pedido)
                .WithRequired(e => e.Pedido)
                .HasForeignKey(e => e.pedido_id_pedido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.nombre_producto)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.descripcion_producto)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Compra)
                .WithRequired(e => e.Producto)
                .HasForeignKey(e => e.producto_id_producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.detalle_pedido)
                .WithRequired(e => e.Producto)
                .HasForeignKey(e => e.producto_id_producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.nombreProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.direccionProveedor)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .HasMany(e => e.Pedido)
                .WithRequired(e => e.Proveedor)
                .HasForeignKey(e => e.proveedor_nit_empresa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.nombre_rol)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Rol)
                .HasForeignKey(e => e.rol_id_rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoProducto>()
                .Property(e => e.nombre_tipo)
                .IsUnicode(false);

            modelBuilder.Entity<TipoProducto>()
                .HasMany(e => e.Producto)
                .WithRequired(e => e.TipoProducto)
                .HasForeignKey(e => e.tipoProducto_id_tipoProducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Compra)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.usuario_documento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Pedido)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.usuario_documento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Telefono)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.usuario_documento)
                .WillCascadeOnDelete(false);
        }
    }
}
