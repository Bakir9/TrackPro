using API.Extensions;
using Core.Entities.Identity;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

//var AllowOrigin = "_AllowOrigin";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(opt => 
{
    opt.AddPolicy("CorsPolicy", policy => 
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
    });
});
// Add services to the container.
//applicationservice are repository and implemenatations

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddDatabaseServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/myapp-.txt",rollingInterval: RollingInterval.Day)
            .CreateLogger();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();

var context = services.GetRequiredService<StoreContext>();
var identityContext = services.GetRequiredService<AppIdentityDbContext>();
var userManager = services.GetRequiredService<UserManager<AppUser>>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
   await context.Database.MigrateAsync();
   await identityContext.Database.MigrateAsync();
   Log.Information("Spremanjae SeedData u bazu podataka");
   await StoreContextSeed.SeedAsync(context, loggerFactory);
   await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
   
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
