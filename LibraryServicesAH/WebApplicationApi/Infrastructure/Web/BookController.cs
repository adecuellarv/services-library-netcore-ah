using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WebApplicationApi.Application;
using WebApplicationApi.Application.Services;
using WebApplicationApi.Domain.Entities;
using WebApplicationApi.Domain.Exceptions;
using WebApplicationApi.Infrastructure.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationApi.Infrastructure.Web
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class BookController : ControllerBase
    {
        private readonly BookRepository _bookRepository;
        private readonly IBookService _bookService;
        private readonly IUpdateBookService _updateBookService;
        private readonly IMediator _mediator;
        public BookController(BookRepository bookRepository, IBookService bookService, IUpdateBookService updateBookService)
        {
            _bookRepository = bookRepository;
            _bookService = bookService;
            _updateBookService = updateBookService;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            try
            {
                return Ok(await _bookRepository.GetAllBooks());
            
            }
            catch (CustomException ex)
            {
                return StatusCode(ex.ErrorCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Book>>> GetBooksByCat(int id)
        {
            try
            {
                return Ok(await _bookRepository.GetBookById(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult<Unit>> Create([FromForm] AddBookDto data)
        {
            var scheme = Request.Scheme;
            var host = Request.Host.Value;

            try
            {
                return Ok(await _bookService.CreateBookAsync(data, scheme, host));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Update([FromForm] UpdateBookDto data, string id)
        {
            var scheme = Request.Scheme;
            var host = Request.Host.Value;

            try
            {
                return Ok(await _updateBookService.UpdateBookAsync(data, scheme, host, int.Parse(id)));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            try
            {
                 await _bookRepository.DeleteBook(id);
                return StatusCode(200);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
