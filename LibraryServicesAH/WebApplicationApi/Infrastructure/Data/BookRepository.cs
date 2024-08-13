using MediatR;
using WebApplicationApi.Application;
using WebApplicationApi.Domain.Entities;
using WebApplicationApi.Domain.Interfaces;
using WebApplicationApi.Infrastructure.Data.Queries.cs;

public class BookRepository : IBookRepository
{
    private readonly IMediator _mediator;

    public BookRepository(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await _mediator.Send(new GetAllBooks.Books());
    }

    public async Task AddBook(AddBookDto book)
    {
        var command = new AddBook.ExecuteBook
        {
            BookName = book.BookName,
            BookDescription = book.BookDescription,
            BookImage = book.BookImage,
            BookPdf = book.BookPdf,
            Category = book.CategoryId
        };
        await _mediator.Send(command);
    }

    public async Task<Book> GetBookById(int id) => throw new NotImplementedException();

    public async Task UpdateBookSync(Book book) => throw new NotImplementedException();

    public async Task DeleteAsync(int id) => throw new NotImplementedException();
}
