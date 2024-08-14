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

    public async Task<List<Book>> GetBookById(int categoryId)
    {
        return await _mediator.Send(new GetBooksByCategory.Books { CategoryId = categoryId });
    }

    public async Task UpdateBook(UpdateBookDto book)
    {
        var command = new UpdateBook.ExecuteBook
        {
            BookId = book.BookId,
            BookName = book.BookName,
            BookDescription = book.BookDescription,
            BookImage = book.BookImage,
            BookPdf = book.BookPdf,
            CategoryId = book.CategoryId
        };
        await _mediator.Send(command);
    }

    public async Task DeleteBook(int id)
    {
        await _mediator.Send(new DeleteBook.ExecuteBook { BookId = id });
    }

}
