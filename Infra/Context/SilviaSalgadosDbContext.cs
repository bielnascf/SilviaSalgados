using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Context
{
    public class SilviaSalgadosDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public SilviaSalgadosDbContext(DbContextOptions<SilviaSalgadosDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<SalgadoEntity> Salgados { get; set; }
        public DbSet<ItemCarrinhoEntity> ItensCarrinho { get; set; }
        public DbSet<PedidoEntity> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string cnnString = _configuration.GetConnectionString("cnnSilviaSalgados").ToString();
                optionsBuilder.UseSqlServer(cnnString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioEntity>()
            .HasKey(u => u.Id);

            modelBuilder.Entity<UsuarioEntity>()
                .Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<UsuarioEntity>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<UsuarioEntity>()
                .Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<UsuarioEntity>()
                .Property(u => u.Celular)
                .IsRequired()
                .HasMaxLength(11);

            modelBuilder.Entity<UsuarioEntity>()
                .Property(u => u.Rua)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder.Entity<UsuarioEntity>()
                .Property(u => u.NumeroCasa)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<UsuarioEntity>()
                .Property(u => u.Cidade)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<UsuarioEntity>()
                .Property(u => u.Bairro)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<UsuarioEntity>()
                .HasMany(u => u.Pedidos)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<SalgadoEntity>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<SalgadoEntity>()
                .Property(s => s.Nome)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<SalgadoEntity>()
                .Property(s => s.Descricao)
                .HasMaxLength(300);

            modelBuilder.Entity<SalgadoEntity>()
                .Property(s => s.TipoSalgado)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<SalgadoEntity>()
                .Property(s => s.Preco)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<SalgadoEntity>()
                .Property(s => s.Imagem)
                .IsRequired()
                .HasMaxLength(300);

            modelBuilder.Entity<SalgadoEntity>()
                .HasMany(s => s.ItensCarrinhos)
                .WithOne(ic => ic.Salgado)
                .HasForeignKey(ic => ic.SalgadoId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<PedidoEntity>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<PedidoEntity>()
                .Property(p => p.UsuarioId)
                .IsRequired();

            modelBuilder.Entity<PedidoEntity>()
                .Property(p => p.DataPedido)
                .IsRequired()
                .HasColumnType("datetime");

            modelBuilder.Entity<PedidoEntity>()
                .Property(p => p.FormaPagamento)
                .HasMaxLength(50);

            modelBuilder.Entity<PedidoEntity>()
                .Property(p => p.Subtotal)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<PedidoEntity>()
                .Property(p => p.TaxaEntrega)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<PedidoEntity>()
                .Property(p => p.Total)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<PedidoEntity>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Pedidos)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PedidoEntity>()
                .HasMany(p => p.ItensCarrinhos)
                .WithOne(ic => ic.Pedido)
                .HasForeignKey(ic => ic.PedidoId)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<ItemCarrinhoEntity>()
                .HasKey(ic => ic.Id);

            modelBuilder.Entity<ItemCarrinhoEntity>()
                .Property(ic => ic.SalgadoId)
                .IsRequired();

            modelBuilder.Entity<ItemCarrinhoEntity>()
                .Property(ic => ic.PedidoId)
                .IsRequired(false);

            modelBuilder.Entity<ItemCarrinhoEntity>()
                .Property(ic => ic.Nome)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<ItemCarrinhoEntity>()
                .Property(ic => ic.Descricao)
                .HasMaxLength(300);

            modelBuilder.Entity<ItemCarrinhoEntity>()
                .Property(ic => ic.TipoSalgado)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<ItemCarrinhoEntity>()
                .Property(ic => ic.ImagemURL)
                .IsRequired()
                .HasMaxLength(300);

            modelBuilder.Entity<ItemCarrinhoEntity>()
                .Property(ic => ic.Quantidade)
                .IsRequired();

            modelBuilder.Entity<ItemCarrinhoEntity>()
                .Property(ic => ic.PrecoTotal)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<ItemCarrinhoEntity>()
                .HasOne(ic => ic.Salgado)
                .WithMany(s => s.ItensCarrinhos)
                .HasForeignKey(ic => ic.SalgadoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemCarrinhoEntity>()
                .HasOne(ic => ic.Pedido)
                .WithMany(p => p.ItensCarrinhos)
                .HasForeignKey(ic => ic.PedidoId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
