using Domain.User;
using Infrastructure.Database;
using Infrastructure.UserManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Initializers;

public class DbInitializer: IDbInitializer
{
    private UserManager<IdentityUser> _userManager;
    private RoleManager<IdentityRole> _roleManager;
    
    
    private readonly ApplicationDbContext _context;

    public DbInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }
  
    public void Initialize()
    {
        try
        {
           
            if (_context.Database.GetPendingMigrations().Count()>0)
            {
                _context.Database.Migrate();
            }
        }
        catch (Exception ex)        
        {
            throw;
        }

        if (!_roleManager.RoleExistsAsync(UserRoles.Admin).GetAwaiter().GetResult())
        {
            _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(UserRoles.User)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(UserRoles.Customer)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new User
            {
                UserName = "admin",
                Email = "admin@insurance.com"
            }, "Admin@123").GetAwaiter().GetResult();
            var user = _context.Users.FirstOrDefault(x=>x.Email=="admin@insurance.com");
            if (user != null)
            {
                _userManager.AddToRoleAsync(user, UserRoles.Admin).GetAwaiter().GetResult();
            }
        }
    }
}