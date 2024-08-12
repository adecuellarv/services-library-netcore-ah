using MediatR;
using System;
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
    public async Task AddBookSync(Book book) => throw new Exception("No hay valores");
    public async Task<Book> GetBookById(int id) => throw new Exception("No hay valores");
    public async Task UpdateBookSync(Book book) => throw new Exception("No hay valores");
    public async Task DeleteAsync(int id) => throw new Exception("No hay valores");

    /*public async Task<Book> GetBookById(int id) => await _context.Books.FindAsync(id);
    public async Task AddBookSync(Book book) => await _context.Books.AddAsync(book);
    public async Task UpdateBookSync(Book book) => _context.Books.Update(book);
    public async Task DeleteAsync(int id)
    {
        var book = await GetBookById(id);
        if (book != null) _context.Books.Remove(book);
    }*/
}
