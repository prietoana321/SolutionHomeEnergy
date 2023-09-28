using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SystemHomeEnergy.MODELS;
namespace SystemHomeEnergy.MODELS;

public partial class BdhomeEnergyContext : DbContext
{
    public BdhomeEnergyContext()
    {
    }

    public BdhomeEnergyContext(DbContextOptions<BdhomeEnergyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<Contratos> Cotizacions { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<NumeroDocumento> NumeroDocumentos { get; set; }

    public virtual DbSet<Prospecto> Prospectos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<ServicioCotizacion> ServicioCotizacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioCliente> UsuarioClientes { get; set; }

    public virtual DbSet<UsuarioCotizacion> UsuarioCotizacions { get; set; }

    public virtual DbSet<UsuarioProspecto> UsuarioProspectos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240C5FA84DF9");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EE41F04A0E");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Contacto)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("contacto");
            entity.Property(e => e.Detalle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("detalle");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.Fachadaimg)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fachadaimg");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Idauditor).HasColumnName("idauditor");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("razonSocial");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.IdContrato).HasName("PK__Contrato__91431FE1284CF7E8");

            entity.ToTable("Contrato");

            entity.Property(e => e.IdContrato).HasColumnName("idContrato");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Documento)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("documento");
            entity.Property(e => e.IdCotizacion).HasColumnName("idCotizacion");
            entity.Property(e => e.IdServicio5).HasColumnName("idServicio5");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Tax).HasColumnName("tax");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.Url)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("url");

            entity.HasOne(d => d.IdCotizacionNavigation).WithMany(p => p.Contrato)
                .HasForeignKey(d => d.IdCotizacion)
                .HasConstraintName("FK__Contrato__idCoti__6A30C649");

            entity.HasOne(d => d.IdServicio5Navigation).WithMany(p => p.Contrato)
                .HasForeignKey(d => d.IdServicio5)
                .HasConstraintName("FK__Contrato__idServ__6B24EA82");
        });

        modelBuilder.Entity<Contratos>(entity =>
        {
            entity.HasKey(e => e.IdCotizacion).HasName("PK__Cotizaci__D931C39B754BE659");

            entity.ToTable("Cotizacion");

            entity.Property(e => e.IdCotizacion).HasColumnName("idCotizacion");
            entity.Property(e => e.Ahorra).HasColumnName("ahorra");
            entity.Property(e => e.Consumoelec).HasColumnName("consumoelec");
            entity.Property(e => e.Consumosolar).HasColumnName("consumosolar");
            entity.Property(e => e.Contrato)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("contrato");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.FormaPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("formaPago");
            entity.Property(e => e.IdEstado1).HasColumnName("idEstado1");
            entity.Property(e => e.Inicial).HasColumnName("inicial");
            entity.Property(e => e.Notas)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("notas");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.Plazo).HasColumnName("plazo");
            entity.Property(e => e.Plazoconsumo).HasColumnName("plazoconsumo");
            entity.Property(e => e.Recursos)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("recursos");
            entity.Property(e => e.Socein)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("socein");
            entity.Property(e => e.Tamañosistema)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("tamañosistema");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.TotalInteres).HasColumnName("totalInteres");
            entity.Property(e => e.Totalinteresxmes).HasColumnName("totalinteresxmes");
            entity.Property(e => e.Url)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("url");

            entity.HasOne(d => d.IdEstado1Navigation).WithMany(p => p.Cotizacions)
                .HasForeignKey(d => d.IdEstado1)
                .HasConstraintName("FK__Cotizacio__idEst__619B8048");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__62EA894AFC2ED06F");

            entity.ToTable("Estado");

            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__C26AF4839D54037F");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Icono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("icono");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.IdMenuRol).HasName("PK__MenuRol__9D6D61A492D5B823");

            entity.ToTable("MenuRol");

            entity.Property(e => e.IdMenuRol).HasColumnName("idMenuRol");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__MenuRol__idMenu__3C69FB99");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__MenuRol__idRol__3D5E1FD2");
        });

        modelBuilder.Entity<NumeroDocumento>(entity =>
        {
            entity.HasKey(e => e.IdNumeroDocumento).HasName("PK__NumeroDo__471E421A0532E2FA");

            entity.ToTable("NumeroDocumento");

            entity.Property(e => e.IdNumeroDocumento).HasColumnName("idNumeroDocumento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.UltimoNumero).HasColumnName("ultimo_Numero");
        });

        modelBuilder.Entity<Prospecto>(entity =>
        {
            entity.HasKey(e => e.IdProspecto).HasName("PK__Prospect__B7A63E9605D2CBFD");

            entity.ToTable("Prospecto");

            entity.Property(e => e.IdProspecto).HasColumnName("idProspecto");
            entity.Property(e => e.Contacto)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("contacto");
            entity.Property(e => e.Detalle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("detalle");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.Fachadaimg)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fachadaimg");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Idauditor).HasColumnName("idauditor");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("razonSocial");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F7616CF204F");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__CEB98119791A6F26");

            entity.ToTable("Servicio");

            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.PulgadaIn).HasColumnName("pulgadaIn");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Servicio__idCate__5812160E");
        });

        modelBuilder.Entity<ServicioCotizacion>(entity =>
        {
            entity.HasKey(e => e.IdServicioCotizacion).HasName("PK__Servicio__9D68B9D1CCD15B0D");

            entity.ToTable("ServicioCotizacion");

            entity.Property(e => e.IdServicioCotizacion).HasColumnName("idServicioCotizacion");
            entity.Property(e => e.IdCotizacion2).HasColumnName("idCotizacion2");
            entity.Property(e => e.IdServicio1).HasColumnName("idServicio1");

            entity.HasOne(d => d.IdCotizacion2Navigation).WithMany(p => p.ServicioCotizacions)
                .HasForeignKey(d => d.IdCotizacion2)
                .HasConstraintName("FK__ServicioC__idCot__797309D9");

            entity.HasOne(d => d.IdServicio1Navigation).WithMany(p => p.ServicioCotizacions)
                .HasForeignKey(d => d.IdServicio1)
                .HasConstraintName("FK__ServicioC__idSer__787EE5A0");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A657A0C4A8");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreCompleto");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__idRol__403A8C7D");
        });

        modelBuilder.Entity<UsuarioCliente>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioCliente).HasName("PK__UsuarioC__7F4042706CDEC0DE");

            entity.ToTable("UsuarioCliente");

            entity.Property(e => e.IdUsuarioCliente).HasColumnName("idUsuarioCliente");
            entity.Property(e => e.IdClientes1).HasColumnName("idClientes1");
            entity.Property(e => e.IdUsuario3).HasColumnName("idUsuario3");

            entity.HasOne(d => d.IdClientes1Navigation).WithMany(p => p.UsuarioClientes)
                .HasForeignKey(d => d.IdClientes1)
                .HasConstraintName("FK__UsuarioCl__idCli__5165187F");

            entity.HasOne(d => d.IdUsuario3Navigation).WithMany(p => p.UsuarioClientes)
                .HasForeignKey(d => d.IdUsuario3)
                .HasConstraintName("FK__UsuarioCl__idUsu__5070F446");
        });

        modelBuilder.Entity<UsuarioCotizacion>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioCotizacion).HasName("PK__UsuarioC__8A2DE4AE7B049CD0");

            entity.ToTable("UsuarioCotizacion");

            entity.Property(e => e.IdUsuarioCotizacion).HasColumnName("idUsuarioCotizacion");
            entity.Property(e => e.IdCotizacion1).HasColumnName("idCotizacion1");
            entity.Property(e => e.IdUsuario4).HasColumnName("idUsuario4");

            entity.HasOne(d => d.IdCotizacion1Navigation).WithMany(p => p.UsuarioCotizacions)
                .HasForeignKey(d => d.IdCotizacion1)
                .HasConstraintName("FK__UsuarioCo__idCot__6754599E");

            entity.HasOne(d => d.IdUsuario4Navigation).WithMany(p => p.UsuarioCotizacions)
                .HasForeignKey(d => d.IdUsuario4)
                .HasConstraintName("FK__UsuarioCo__idUsu__66603565");
        });

        modelBuilder.Entity<UsuarioProspecto>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioProspecto).HasName("PK__UsuarioP__11F42BCC85C65384");

            entity.ToTable("UsuarioProspecto");

            entity.Property(e => e.IdUsuarioProspecto).HasColumnName("idUsuarioProspecto");
            entity.Property(e => e.IdProspecto2).HasColumnName("idProspecto2");
            entity.Property(e => e.IdUsuario2).HasColumnName("idUsuario2");

            entity.HasOne(d => d.IdProspecto2Navigation).WithMany(p => p.UsuarioProspectos)
                .HasForeignKey(d => d.IdProspecto2)
                .HasConstraintName("FK__UsuarioPr__idPro__49C3F6B7");

            entity.HasOne(d => d.IdUsuario2Navigation).WithMany(p => p.UsuarioProspectos)
                .HasForeignKey(d => d.IdUsuario2)
                .HasConstraintName("FK__UsuarioPr__idUsu__48CFD27E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
