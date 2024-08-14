using MediatR;
using Npgsql;
using System.Data;
using WebApplicationApi.Domain.Exceptions;

namespace WebApplicationApi.Infrastructure.Data.Queries.cs
{
    public class UpdateBook
    {
        public class ExecuteBook : IRequest
        {
            public int BookId { get; set; }
            public string? BookName { get; set; }
            public string? BookDescription { get; set; }
            public string? BookImage { get; set; }
            public string? BookPdf { get; set; }
            public string? CategoryId { get; set; }
        }
        public class Managment : IRequestHandler<ExecuteBook, Unit>
        {
            private readonly NpgsqlConnection _connection;
            private readonly ILogger<Managment> _logger;
            public Managment(NpgsqlConnection connection, ILogger<Managment> logger)
            {
                _connection = connection;
                _logger = logger;
            }
            public async Task<Unit> Handle(ExecuteBook request, CancellationToken cancellationToken)
            {
                if (_connection.State != ConnectionState.Open)
                {
                    await _connection.OpenAsync(cancellationToken);
                }
                try
                {
                    using (var command = new NpgsqlCommand("SELECT public.updatebook(@p_book_id, @p_book_name, @p_book_description, @p_book_image, @p_book_pdf, @p_category_id)", _connection))
                    {
                        //command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("p_book_id", request.BookId);
                        command.Parameters.AddWithValue("p_book_name", (object?)request.BookName ?? DBNull.Value);
                        command.Parameters.AddWithValue("p_book_description", (object?)request.BookDescription ?? DBNull.Value);
                        command.Parameters.AddWithValue("p_book_image", (object?)request.BookImage ?? DBNull.Value);
                        command.Parameters.AddWithValue("p_book_pdf", (object?)request.BookPdf ?? DBNull.Value);
                        command.Parameters.AddWithValue("p_category_id", (object?)int.Parse(request.CategoryId) ?? DBNull.Value);

                        await command.ExecuteNonQueryAsync(cancellationToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al actualizar libro: {Message}", ex.Message);
                    throw new CustomException(400, "Error al actualizar libro.");
                }
                finally
                {
                    if (_connection.State == ConnectionState.Open)
                    {
                        await _connection.CloseAsync();
                    }
                }

                return Unit.Value;
            }
        }
    }
}
