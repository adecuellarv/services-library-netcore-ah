using Npgsql;
using System.Data;
using WebApplicationApi.Domain.Entities;
using WebApplicationApi.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace WebApplicationApi.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly NpgsqlConnection _connection;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(NpgsqlConnection connection, ILogger<BookRepository> logger)
        {
            _connection = connection;
            _logger = logger;
        }

        public async Task AddBookSync(Book book)
        {
            if (_connection.State != ConnectionState.Open)
            {
                await _connection.OpenAsync();
            }
            try
            {
                using (var command = new NpgsqlCommand("SELECT public.addbook(@p_book_name, @p_book_description, @p_book_image, @p_book_pdf, @p_category_id)", _connection))
                {
                    command.Parameters.AddWithValue("p_book_name", book.BookName);
                    command.Parameters.AddWithValue("p_book_description", book.BookDescription);
                    command.Parameters.AddWithValue("p_book_image", book.BookImage);
                    command.Parameters.AddWithValue("p_book_pdf", book.BookPdf);
                    command.Parameters.AddWithValue("p_category_id", book.CategoryId);
                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar libro: {Message}", ex.Message);
                throw;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    await _connection.CloseAsync();
                }
            }
        }

        public async Task<List<Book>> GetAllBooks()
        {
            if (_connection.State != ConnectionState.Open)
            {
                await _connection.OpenAsync();
            }
            var bookList = new List<Book>();
            try
            {
                using (var command = new NpgsqlCommand("SELECT * FROM public.books;", _connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            var book = new Book(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                            /*{
                                BookId = reader.GetInt32(0),
                                BookName = reader.GetString(1),
                                BookDescription = reader.GetString(2),
                                BookImage = reader.GetString(3),
                                BookPdf = reader.GetString(4),
                                CategoryId = reader.GetInt32(5)
                            };*/
                            bookList.Add(book);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al traer la lista de libros: {Message}", ex.Message);
                throw new Exception("Error al traer la lista de libros", ex);
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

        public async Task UpdateBookSync(Book book) // Implementa este método también
        {
            // Lógica para actualizar un libro
            // Debes implementar esta lógica según tu base de datos
            throw new NotImplementedException();
        }

        Task<Book> IBookRepository.GetBookById(int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
