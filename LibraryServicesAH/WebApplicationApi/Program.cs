using MediatR;
using Npgsql;
using System.Reflection;
using WebApplicationApi.Application.Services;
using WebApplicationApi.Domain.Interfaces;
using WebApplicationApi.Infrastructure.Data;
using WebApplicationApi.Infrastructure.Data.Queries.cs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configura el contexto de la base de datos
builder.Services.AddSingleton<NpgsqlConnection>(sp => new NpgsqlConnection(builder.Configuration.GetConnectionString("ConexionDB")));

// Registrar la interfaz y su implementación
builder.Services.AddScoped<BookRepository, BookRepository>();
builder.Services.AddScoped<CategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<CategoryRepository, CategoryRepository>();

// Añadir MediatR
builder.Services.AddMediatR(typeof(GetAllBooks.Managment).Assembly);
builder.Services.AddMediatR(typeof(AddBook.Managment).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.Run();



