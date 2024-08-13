using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplicationApi.Application;
using WebApplicationApi.Application.Services;
using WebApplicationApi.Domain.Entities;
using WebApplicationApi.Domain.Exceptions;
using WebApplicationApi.Domain.Interfaces;
using WebApplicationApi.Infrastructure.Data.Queries.cs;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class BookRepository : IBookRepository
{
    private readonly IMediator _mediator;
    private readonly BookService _bookService;

    public BookRepository(IMediator mediator, BookService bookService)
    {
        _mediator = mediator;
        _bookService = bookService;
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await _mediator.Send(new GetAllBooks.Books());
    }
    public async Task<ActionResult<Unit>> AddBook(AddBookDto book) 
    {
        return await _mediator.Send(new AddBook.ExecuteBook());
    }

    public async Task<Book> GetBookById(int id) => throw new Exception("No hay valores");
    public async Task UpdateBookSync(Book book) => throw new Exception("No hay valores");
    public async Task DeleteAsync(int id) => throw new Exception("No hay valores");

    Task IBookRepository.AddBook(AddBookDto book)
    {
        throw new NotImplementedException();
    }
}
