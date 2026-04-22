using Microsoft.EntityFrameworkCore;
public class KontekstGry : DbContext
{
    public DbSet<GraVideo> GryVideo { get; set; }
    public DbSet<Wydawca> Wydawcy { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Data Source=GryWideoDB.db;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wydawca>()
            .HasMany(wydawca => wydawca.Gry)
            .WithOne(gra => gra.Wydawca);
    }
}