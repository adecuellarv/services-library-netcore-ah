
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationApi.Application;
using WebApplicationApi.Domain.Entities;

namespace WebApplicationApi.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task AddBook(AddBookDto book);
        Task<Book> GetBookById(int bookId);
        Task UpdateBook(UpdateBookDto book);
        Task DeleteAsync(int bookId);
    }
}
