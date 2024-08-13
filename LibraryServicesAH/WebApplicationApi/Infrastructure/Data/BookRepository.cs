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
}
