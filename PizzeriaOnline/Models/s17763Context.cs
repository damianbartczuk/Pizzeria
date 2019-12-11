using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzeriaOnline.Models
{
    public partial class s17763Context : DbContext
    {
        public s17763Context()
        {
        }

        public s17763Context(DbContextOptions<s17763Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Kierownik> Kierownik { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<StanZamowienia> StanZamowienia { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }
        public virtual DbSet<ZamowieniePizza> ZamowieniePizza { get; set; }
        public virtual DbSet<ZamowieniePracownik> ZamowieniePracownik { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17763;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Kierownik>(entity =>
            {
                entity.HasKey(e => e.IdKierownika)
                    .HasName("Kierownik_pk");

                entity.Property(e => e.IdKierownika).ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NazwaUzytkownika)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKlienta)
                    .HasName("Klient_pk");

                entity.Property(e => e.IdKlienta).ValueGeneratedNever();

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NazwaKlienta)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("I");

                entity.Property(e => e.IdPizza).ValueGeneratedOnAdd();

                entity.Property(e => e.Cena).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.NaliczonaPromocja).HasColumnType("numeric(3, 2)");

                entity.Property(e => e.NazwaPizzy)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaSkladnik>(entity =>
            {
                entity.HasKey(e => new { e.SkladnikIdSkladnik, e.PizzaIdPizza })
                    .HasName("Pizza_Skladnik_pk");

                entity.ToTable("Pizza_Skladnik");

                entity.Property(e => e.SkladnikIdSkladnik).HasColumnName("Skladnik_IdSkladnik");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_IdPizza");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Skladnik_Pizza");

                entity.HasOne(d => d.SkladnikIdSkladnikNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.SkladnikIdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Skladnik_Skladnik");
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.IdPracownik)
                    .HasName("Pracownik_pk");

                entity.Property(e => e.IdPracownik).ValueGeneratedNever();

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.KierownikIdKierownika).HasColumnName("Kierownik_IdKierownika");

                entity.Property(e => e.NazwaUzytkownika)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.KierownikIdKierownikaNavigation)
                    .WithMany(p => p.Pracownik)
                    .HasForeignKey(d => d.KierownikIdKierownika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pracownik_Kierownik");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StanZamowienia>(entity =>
            {
                entity.HasKey(e => e.IdStanZamowienia)
                    .HasName("StanZamowienia_pk");

                entity.Property(e => e.IdStanZamowienia)
                    .HasColumnName("idStanZamowienia")
                    .ValueGeneratedNever();

                entity.Property(e => e.NazwaStanu)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienia)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienia).ValueGeneratedNever();

                entity.Property(e => e.DataZamowienia).HasColumnType("date");

                entity.Property(e => e.MiejsceDoceloweZamowienia)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_IdPizza");

                entity.Property(e => e.StanZamowieniaIdStanZamowienia).HasColumnName("StanZamowienia_idStanZamowienia");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_PizzaFK");

                entity.HasOne(d => d.StanZamowieniaIdStanZamowieniaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.StanZamowieniaIdStanZamowienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_StanZamowienia");
            });

            modelBuilder.Entity<ZamowieniePizza>(entity =>
            {
                entity.HasKey(e => new { e.KlientIdKlienta, e.ZamowienieIdZamowienia })
                    .HasName("Zamowienie_Pizza_pk");

                entity.ToTable("Zamowienie_Pizza");

                entity.Property(e => e.KlientIdKlienta).HasColumnName("Klient_IdKlienta");

                entity.Property(e => e.ZamowienieIdZamowienia).HasColumnName("Zamowienie_IdZamowienia");

                entity.HasOne(d => d.KlientIdKlientaNavigation)
                    .WithMany(p => p.ZamowieniePizza)
                    .HasForeignKey(d => d.KlientIdKlienta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pizza_Klient");

                entity.HasOne(d => d.ZamowienieIdZamowieniaNavigation)
                    .WithMany(p => p.ZamowieniePizza)
                    .HasForeignKey(d => d.ZamowienieIdZamowienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pizza_Zamowienie");
            });

            modelBuilder.Entity<ZamowieniePracownik>(entity =>
            {
                entity.HasKey(e => new { e.PracownikIdPracownik, e.ZamowienieIdZamowienia })
                    .HasName("Zamowienie_Pracownik_pk");

                entity.ToTable("Zamowienie_Pracownik");

                entity.Property(e => e.PracownikIdPracownik).HasColumnName("Pracownik_IdPracownik");

                entity.Property(e => e.ZamowienieIdZamowienia).HasColumnName("Zamowienie_IdZamowienia");

                entity.HasOne(d => d.PracownikIdPracownikNavigation)
                    .WithMany(p => p.ZamowieniePracownik)
                    .HasForeignKey(d => d.PracownikIdPracownik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pracownik_Pracownik");

                entity.HasOne(d => d.ZamowienieIdZamowieniaNavigation)
                    .WithMany(p => p.ZamowieniePracownik)
                    .HasForeignKey(d => d.ZamowienieIdZamowienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Pracownik_Zamowienie");
            });
        }
    }
}
