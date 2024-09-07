using Domain;
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