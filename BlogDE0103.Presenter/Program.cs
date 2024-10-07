using BlogDE0103.Business.UsesCases;
using BlogDE0103.Data.DBContext;
using BlogDE0103.Data.Repositories;
using BlogDE0103.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


ConfigurationManager configuration = builder.Configuration;

//Servicio de base de datos
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("CadenaConexion"),
   b => b.MigrationsAssembly("BlogDE0103.Data")));



//DI
builder.Services.AddScoped<RolBusiness>();
builder.Services.AddScoped<RolRepository>();

builder.Services.AddScoped<UsuarioBusiness>();
builder.Services.AddScoped<UsuarioRepository>();




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
