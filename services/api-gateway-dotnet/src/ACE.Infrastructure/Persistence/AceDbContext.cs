using ACE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ACE.Infrastructure.Persistence;

public class AceDbContext : DbContext
{
    public AceDbContext(DbContextOptions<AceDbContext> options) : base(options)
    {
    }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Document> Documents => Set<Document>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Projects");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name).IsRequired().HasMaxLength(255);
            entity.Property(x => x.Description).HasMaxLength(2000);
            entity.Property(x => x.CreatedAt).IsRequired();
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.ToTable("Documents");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.FileName).IsRequired().HasMaxLength(255);
            entity.Property(x => x.FileType).IsRequired().HasMaxLength(50);
            entity.Property(x => x.StoragePath).IsRequired().HasMaxLength(1000);
            entity.Property(x => x.Status).IsRequired().HasMaxLength(50);
            entity.Property(x => x.UploadedAt).IsRequired();
        });
    }
}