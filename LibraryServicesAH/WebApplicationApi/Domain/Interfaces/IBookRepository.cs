
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationApi.Domain.Entities;

namespace WebApplicationApi.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task AddBookSync(Book book);
        Task<Book> GetBookById(int bookId);
        Task UpdateBookSync(Book book);
        Task DeleteAsync(int bookId);
    }
}
