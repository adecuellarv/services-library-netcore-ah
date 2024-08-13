using MediatR;
using Npgsql;
using System.Data;
using WebApplicationApi.Domain.Entities;
using WebApplicationApi.Domain.Exceptions;

namespace WebApplicationApi.Infrastructure.Data.Queries.cs
{
    public class GetAllCategories
    {
        public class Categories : IRequest<List<Category>> { }

        public class Managment : IRequestHandler<Categories, List<Category>>
        {
            private readonly NpgsqlConnection _connection;
            private readonly ILogger<Managment> _logger;
            public Managment(NpgsqlConnection connection, ILogger<Managment> logger)
            {
                _connection = connection;
                _logger = logger;
            }

            public async Task<List<Category>> Handle(Categories request, CancellationToken cancellationToken)
            {
                if (_connection.State != ConnectionState.Open)
                {
                    await _connection.OpenAsync(cancellationToken);
                }
                var categoriesList = new List<Category>();

                try
                {
                    using (var command = new NpgsqlCommand("SELECT categoryid, categoryguid, categoryname FROM public.categories;", _connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            while (await reader.ReadAsync(cancellationToken))
                            {
                                var category = new Category(reader.GetInt32(0), reader.GetString(2));
                                categoriesList.Add(category);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al traer categorias: {Message}", ex.Message);
                    throw new CustomException(500, "Error al traer la lista de categorias.", ex);
                }
                finally
                {
                    if (_connection.State == ConnectionState.Open)
                    {
                        await _connection.CloseAsync();
                    }
                }
                return categoriesList;
            }
        }
    }
}
