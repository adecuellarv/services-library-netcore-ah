
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationApi.Domain.Entities;

namespace WebApplicationApi.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task AddBookSync(Book book);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int bookId);
        Task UpdateBookSync(Book book);
    }
}
