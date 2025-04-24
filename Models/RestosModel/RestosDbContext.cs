using Microsoft.EntityFrameworkCore;

namespace RestoManager_SadkaouiMouhamed.Models.RestosModel
{
    public class RestosDbContext : DbContext
    {
        public RestosDbContext(DbContextOptions<RestosDbContext> options)
            : base(options)
        {
        }

        public DbSet<Proprietaire> Proprietaires { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Avis> Avis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Proprietaire>(entity =>
            {
                entity.ToTable("TProprietaire", "resto");

                entity.HasKey(p => p.Numero);

                entity.Property(p => p.Nom)
                      .HasColumnName("NomProp")
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(p => p.Email)
                      .HasColumnName("EmailProp")
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(p => p.Gsm)
                      .HasColumnName("GsmProp")
                      .HasMaxLength(8)
                      .IsRequired();
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("TRestaurant", "resto");

                entity.HasKey(r => r.CodeResto);

                entity.Property(r => r.NomResto)
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(r => r.Specialite)
                      .HasColumnName("SpecResto")
                      .HasMaxLength(20)
                      .IsRequired()
                      .HasDefaultValue("Tunisienne");

                entity.Property(r => r.Ville)
                      .HasColumnName("VilleResto")
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(r => r.Tel)
                      .HasColumnName("TelResto")
                      .HasMaxLength(8)
                      .IsRequired();

                entity.HasOne(r => r.LeProprio)
                      .WithMany(p => p.LesRestos)
                      .HasForeignKey(r => r.NumProp)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("Relation_Proprio_Restos");

                entity.HasMany(r => r.LesAvis)
                      .WithOne(a => a.LeResto)
                      .HasForeignKey(a => a.NumResto) 
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("Relation_Resto_Avis");
            });

            modelBuilder.Entity<Avis>(entity =>
            {
                entity.ToTable("TAvis", "admin");

                entity.HasKey(a => a.CodeAvis);

                entity.Property(a => a.NomPersonne)
                      .HasColumnName("NomPersonne")
                      .HasMaxLength(30)
                      .IsRequired();  
                entity.Property(a => a.Note)
                      .HasColumnName("Note")
                      .IsRequired();  
                entity.Property(a => a.Commentaire)
                      .HasColumnName("Commentaire")
                      .HasMaxLength(256);  
                entity.HasOne(a => a.LeResto)
                      .WithMany(r => r.LesAvis)
                      .HasForeignKey(a => a.NumResto)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName("FK_Avis_Restaurant");
            });
        }
    }
}

