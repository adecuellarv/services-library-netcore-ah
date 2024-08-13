using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.Domain.Entities;
using WebApplicationApi.Domain.Exceptions;
using WebApplicationApi.Infrastructure.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationApi.Infrastructure.Web
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class BookController : ControllerBase
    {
        private readonly BookRepository _bookService;
        private readonly IMediator _mediator;
        public BookController(BookRepository bookService)
        {
            _bookService = bookService;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            try
            {
                return Ok(await _bookService.GetAllBooks());
            
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
