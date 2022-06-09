using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ecommerce.Repository.Models;

namespace Ecommerce.Repository
{
    public partial class ShopDbContext : DbContext
    {
        public ShopDbContext()
        {
        }

        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Corriere> Corrieres { get; set; } = null!;
        public virtual DbSet<Immagine> Immagines { get; set; } = null!;
        public virtual DbSet<ListaProdotti> ListaProdottis { get; set; } = null!;
        public virtual DbSet<Magazzino> Magazzinos { get; set; } = null!;
        public virtual DbSet<Ordine> Ordines { get; set; } = null!;
        public virtual DbSet<Prodotto> Prodottos { get; set; } = null!;
        public virtual DbSet<Rubrica> Rubricas { get; set; } = null!;
        public virtual DbSet<Scortum> Scorta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=GIOPC\\SQLEXPRESS;Initial Catalog=Ecommerce;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descrizione");

                entity.Property(e => e.Icona)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("icona");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.HasIndex(e => e.Email, "UQ__Cliente__AB6E6164B4D768FA")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__Cliente__F3DBC572AB6BACAD")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Cognome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cognome");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.NumeroTel)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("numero_tel");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Corriere>(entity =>
            {
                entity.ToTable("Corriere");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Immagine>(entity =>
            {
                entity.ToTable("Immagine");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdProdotto).HasColumnName("id_prodotto");

                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("link");

                entity.HasOne(d => d.IdProdottoNavigation)
                    .WithMany(p => p.Immagines)
                    .HasForeignKey(d => d.IdProdotto)
                    .HasConstraintName("FK__Immagine__id_pro__5812160E");
            });

            modelBuilder.Entity<ListaProdotti>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Lista_prodotti");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdOrdine).HasColumnName("id_ordine");

                entity.Property(e => e.IdProdotto).HasColumnName("id_prodotto");

                entity.Property(e => e.Quantita).HasColumnName("quantita");

                entity.HasOne(d => d.IdOrdineNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdOrdine)
                    .HasConstraintName("FK__Lista_pro__id_or__4F7CD00D");

                entity.HasOne(d => d.IdProdottoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProdotto)
                    .HasConstraintName("FK__Lista_pro__id_pr__5070F446");
            });

            modelBuilder.Entity<Magazzino>(entity =>
            {
                entity.ToTable("Magazzino");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Ordine>(entity =>
            {
                entity.ToTable("Ordine");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Codice)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("codice");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdCorriere).HasColumnName("id_corriere");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Ordines)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Ordine__id_clien__4CA06362");

                entity.HasOne(d => d.IdCorriereNavigation)
                    .WithMany(p => p.Ordines)
                    .HasForeignKey(d => d.IdCorriere)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_id_corriere");
            });

            modelBuilder.Entity<Prodotto>(entity =>
            {
                entity.ToTable("Prodotto");

                entity.HasIndex(e => e.Codice, "UQ__Prodotto__40F9C18BFEF9B0CC")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Codice)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("codice");

                entity.Property(e => e.DescBreve)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("desc_breve");

                entity.Property(e => e.Descrizione)
                    .HasColumnType("text")
                    .HasColumnName("descrizione")
                    .HasDefaultValueSql("('N/A')");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("id_categoria")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Peso)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("peso");

                entity.Property(e => e.Prezzo)
                    .HasColumnType("money")
                    .HasColumnName("prezzo");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Prodottos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("fk_id_categoria");
            });

            modelBuilder.Entity<Rubrica>(entity =>
            {
                entity.ToTable("Rubrica");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Cap)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("cap")
                    .IsFixedLength();

                entity.Property(e => e.Citta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("citta");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Via)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("via");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Rubricas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("fk_id_cliente");
            });

            modelBuilder.Entity<Scortum>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdMagazzino).HasColumnName("id_magazzino");

                entity.Property(e => e.IdProdotto).HasColumnName("id_prodotto");

                entity.Property(e => e.Quantita).HasColumnName("quantita");

                entity.HasOne(d => d.IdMagazzinoNavigation)
                    .WithMany(p => p.Scorta)
                    .HasForeignKey(d => d.IdMagazzino)
                    .HasConstraintName("fk_id_magazzino");

                entity.HasOne(d => d.IdProdottoNavigation)
                    .WithMany(p => p.Scorta)
                    .HasForeignKey(d => d.IdProdotto)
                    .HasConstraintName("fk_id_prodotto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
