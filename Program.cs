using Microsoft.EntityFrameworkCore;
using web_api;
using web_api.Repo;
using web_api.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserRegistrationService>();


// Registers the ApplicationDBContext with the dependency injection container,
// configuring it to use PostgreSQL as the database provider. The connection string 
// is retrieved from the appsettings.json configuration file under "DefaultConnection".
builder.Services.AddDbContext<ApplicationDBContext>(opt=>opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

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
