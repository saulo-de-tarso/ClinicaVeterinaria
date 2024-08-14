using ProjetoCRM.API.Models;

namespace ProjetoCRM.API.Data
{
    //Creates a data context to connect the API to the database
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Client> Client { get; set; } //dbset for the pet entity
        public DbSet<Pet> Pet { get; set; } //dbset for the pet entity
        public DbSet<Appointment> Appointment { get; set; } //dbset for the pet entity

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false); 
            });
            modelBuilder.Entity<Pet>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Specie)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Race)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
