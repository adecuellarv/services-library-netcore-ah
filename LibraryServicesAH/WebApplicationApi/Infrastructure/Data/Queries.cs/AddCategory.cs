using MediatR;
using Npgsql;
using System.Data;
using WebApplicationApi.Domain.Exceptions;

namespace WebApplicationApi.Infrastructure.Data.Queries.cs
{
    public class AddCategory
    {
        public class ExecuteCategory : IRequest
        {
            public string CategoryName { get; set; }
         }

        public class Managment : IRequestHandler<ExecuteCategory, Unit>
        {
            private readonly NpgsqlConnection _connection;
            private readonly ILogger<Managment> _logger;

            public Managment(NpgsqlConnection connection, ILogger<Managment> logger)
            {
                _connection = connection;
                _logger = logger;
            }
            public async Task<Unit> Handle(ExecuteCategory request, CancellationToken cancellationToken)
            {
                if (_connection.State != ConnectionState.Open)
                {
                    await _connection.OpenAsync(cancellationToken);
                }

                try
                {
                    using (var command = new NpgsqlCommand("SELECT public.addcategory(@p_categoryname)", _connection))
                    {
                        //command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("p_categoryname", request.CategoryName);
                        await command.ExecuteNonQueryAsync(cancellationToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al agregar la categoría: {Message}", ex.Message);
                    throw new CustomException(400, "Error al agregar la categoría");
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
