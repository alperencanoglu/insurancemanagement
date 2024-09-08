using Domain;
using Domain.Agreement;
using Domain.Partner;
using Domain.RiskAnalysis;
using Domain.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Database;

public class ApplicationDbContext :  IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Policies> Policies { get; set; }
    public DbSet<Agreement> Agreements { get; set; }
    public DbSet<Partner> Partners { get; set; }
    public DbSet<RiskAnalysis> RiskAnalyses { get; set; }
    
    
   
}





//forscaffold
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=sigortacilik;User Id=sa; Password=reallyStrongPwd123; MultipleActiveResultSets=true;TrustServerCertificate=true;");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}