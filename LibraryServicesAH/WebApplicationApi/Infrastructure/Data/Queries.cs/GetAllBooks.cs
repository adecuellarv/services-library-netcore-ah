using MediatR;
using Npgsql;
using System.Data;
using WebApplicationApi.Domain.Exceptions;
using WebApplicationApi.Domain.Entities;

namespace WebApplicationApi.Infrastructure.Data.Queries.cs
{
    public class GetAllBooks
    {
       
        public class Books : IRequest<List<Book>> { }

        public class Managment : IRequestHandler<Books, List<Book>>
        {
            private readonly NpgsqlConnection _connection;
            private readonly ILogger<Managment> _logger;

            public Managment(NpgsqlConnection connection, ILogger<Managment> logger)
            {
                _connection = connection;
                _logger = logger;
            }

            public async Task<List<Book>> Handle(Books request, CancellationToken cancellationToken)
            {
                if (_connection.State != ConnectionState.Open)
                {
                    await _connection.OpenAsync(cancellationToken);
                }
                var bookList = new List<Book>();
                try
                {
                    using (var command = new NpgsqlCommand("SELECT * FROM public.booksv;", _connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            while (await reader.ReadAsync(cancellationToken))
                            {

                                var book = new Book(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                                bookList.Add(book);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al traer la lista de libros: {Message}", ex.Message);
                    throw new CustomException(500, "Error al traer la lista de libros.", ex);
                    //throw new Exception("Error al traer la lista de libros", ex);
                }
                finally
                {
                    if (_connection.State == ConnectionState.Open)
                    {
                        await _connection.CloseAsync();
                    }
                }
                return bookList;
            }
        }

    }
}
