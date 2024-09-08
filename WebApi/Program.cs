using Domain.User;
using Infrastructure.Database;
using Infrastructure.Initializers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.UnitOfWork;
using Service.Agreement;
using Service.Policy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//add db context with sql server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


//every time requested one instance for one user!
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
//transient every time requested
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<IAgreementService, AgreementService>();
var app = builder.Build();

app.UseWebSockets();

var webSocketHandler = new WebSocketHandler();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/ws")
    {
        await webSocketHandler.HandleWebSocketAsync(context);
    }
    else
    {
        await next();
    }
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();