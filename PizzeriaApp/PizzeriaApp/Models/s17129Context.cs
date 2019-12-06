using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzeriaApp.Models
{
    public partial class s17129Context : DbContext
    {
        public s17129Context()
        {
        }

        public s17129Context(DbContextOptions<s17129Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Dodatki> Dodatki { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<PracownikZamowienie> PracownikZamowienie { get; set; }
        public virtual DbSet<Promocja> Promocja { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }
        public virtual DbSet<ZamowienieDodatki> ZamowienieDodatki { get; set; }
        public virtual DbSet<ZamowieniePizza> ZamowieniePizza { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17129;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Dodatki>(entity =>
            {
                entity.HasKey(e => e.IdDodatek)
                    .HasName("Dodatki_pk");

                entity.Property(e => e.IdDodatek).ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("smallmoney");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("Klient_pk");

                entity.Property(e => e.IdUser).ValueGeneratedNever();

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza).ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("smallmoney");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaSkladnik>(entity =>
            {
                entity.HasKey(e => new { e.IdPizza, e.IdSkladnik })
                    .HasName("Pizza_Skladnik_pk");

                entity.ToTable("Pizza_Skladnik");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Skladnik_Pizza");

                entity.HasOne(d => d.IdSkladnikNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.IdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Skladnik_Skladnik");
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownik)
                    .HasName("Pracownik_pk");

                entity.Property(e => e.IdPracownik).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TypPracownika)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PracownikZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.IdZamowienie, e.IdPracownik })
                    .HasName("Pracownik_Zamowienie_pk");

                entity.ToTable("Pracownik_Zamowienie");

                entity.HasOne(d => d.IdPracownikNavigation)
                    .WithMany(p => p.PracownikZamowienie)
                    .HasForeignKey(d => d.IdPracownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pracownik_Zamowienie_Pracownik");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.PracownikZamowienie)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pracownik_Zamowienie_Zamowienie");
            });

            modelBuilder.Entity<Promocja>(entity =>
            {
                entity.HasKey(e => e.IdPromocja)
                    .HasName("Promocja_pk");

                entity.Property(e => e.IdPromocja).ValueGeneratedNever();

                entity.Property(e => e.ObowiazujeDo).HasColumnType("date");

                entity.Property(e => e.ObowiazujeOd).HasColumnType("date");

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienie).ValueGeneratedNever();

                entity.Property(e => e.CenaZamowienia).HasColumnType("money");

                entity.Property(e => e.DataZamowienia).HasColumnType("datetime");

                entity.Property(e => e.StanZamowienia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SzacowanaDataDostarczenia).HasColumnType("datetime");

                entity.HasOne(d => d.IdPromocjaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdPromocja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Promocja");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Klient");
            });

            modelBuilder.Entity<ZamowienieDodatki>(entity =>
            {
                entity.HasKey(e => new { e.IdDodatek, e.IdZamowienie })
                    .HasName("Zamowienie_Dodatki_pk");

                entity.ToTable("Zamowienie_Dodatki");

                entity.HasOne(d => d.IdDodatekNavigation)
                    .WithMany(p => p.ZamowienieDodatki)
                    .HasForeignKey(d => d.IdDodatek)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Dodatki_Dodatki");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.ZamowienieDodatki)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Dodatki_Zamowienie");
            });

            modelBuilder.Entity<ZamowieniePizza>(entity =>
            {
                entity.HasKey(e => new { e.IdPizza, e.IdZamowienie })
                    .HasName("Zamowienie_Pizza_pk");

                entity.ToTable("Zamowienie_Pizza");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.ZamowieniePizza)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pizza_Pizza");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.ZamowieniePizza)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pizza_Zamowienie");
            });
        }
    }
}
