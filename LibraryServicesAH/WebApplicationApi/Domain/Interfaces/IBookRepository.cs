
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
        Task<List<Book>> GetBookById(int categoryId);
        Task UpdateBook(UpdateBookDto book);
        Task DeleteBook(int bookId);
    }
}
