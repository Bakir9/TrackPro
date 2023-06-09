using API.Extensions;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StoreContext>( opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
 

// builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();

var context = services.GetRequiredService<StoreContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
   await context.Database.MigrateAsync();
   await StoreContextSeed.SeedAsync(context, loggerFactory);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
