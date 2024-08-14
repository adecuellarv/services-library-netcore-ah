using MediatR;
using WebApplicationApi.Domain.Entities;
using WebApplicationApi.Domain.Interfaces;

namespace WebApplicationApi.Application.Services
{
  
    public interface IUpdateBookService
    {
        Task<Unit> UpdateBookAsync(UpdateBookDto data, string scheme, string host, int id);
    }

    public class UpdateBookService : IUpdateBookService
    {
        private readonly IBookRepository _bookRepository; // Interfaz para el repositorio

        public UpdateBookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> UpdateBookAsync(UpdateBookDto data, string scheme, string host, int id)
        {
            // Validación
            if (data.BookImageFile != null || data.BookPdfFile != null)
            {
                // Generar rutas
                data.BookImage = $"{scheme}://{host}/uploads/{data.BookImageFile.FileName}";
                data.BookPdf = $"{scheme}://{host}/uploads/{data.BookPdfFile.FileName}";
            }
            else
            {
                data.BookImage = null;
                data.BookPdf = null;
            }
            var book = new UpdateBookDto(data.BookName, data.BookDescription, data.BookImage, data.BookPdf, data.CategoryId, id);

            await _bookRepository.UpdateBook(book);

            return Unit.Value;

        }
    }
}
