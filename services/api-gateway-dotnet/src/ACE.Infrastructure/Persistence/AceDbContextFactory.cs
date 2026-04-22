using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ACE.Infrastructure.Persistence;

public class AceDbContextFactory : IDesignTimeDbContextFactory<AceDbContext>
{
    public AceDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AceDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=AceDb;User Id=sa;Password=AceEngine#2026Secure;TrustServerCertificate=True");

        return new AceDbContext(optionsBuilder.Options);
    }
}