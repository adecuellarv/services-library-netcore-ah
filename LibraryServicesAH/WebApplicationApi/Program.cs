using MediatR;
using Npgsql;
using System.Reflection;
using WebApplicationApi.Domain.Interfaces;
using WebApplicationApi.Infrastructure.Data;
using WebApplicationApi.Infrastructure.Data.Queries.cs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configura el contexto de la base de datos
builder.Services.AddSingleton<NpgsqlConnection>(sp => new NpgsqlConnection(builder.Configuration.GetConnectionString("ConexionDB")));

builder.Services.AddScoped<BookRepository, BookRepository>();

//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddMediatR(typeof(GetAllBooks.Managment).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
