using MediatR;
using WebApplicationApi.Domain.Entities;
using WebApplicationApi.Domain.Interfaces;

namespace WebApplicationApi.Application.Services
{
    public interface IBookService
    {
        Task<Unit> CreateBookAsync(AddBookDto data, string scheme, string host);
    }

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository; // Interfaz para el repositorio

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> CreateBookAsync(AddBookDto data, string scheme, string host)
        {
            // Validación
            if (data.BookImageFile == null || data.BookPdfFile == null)
                throw new ArgumentException("Los archivos no pueden ser nulos.");

            // Generar rutas
            data.BookImage = $"{scheme}://{host}/uploads/{data.BookImageFile.FileName}";
            data.BookPdf = $"{scheme}://{host}/uploads/{data.BookPdfFile.FileName}";

            // Aquí se debe preparar y llamar al repositorio para guardar los datos
            var book = new AddBookDto(data.BookName, data.BookDescription, data.BookImage, data.BookPdf, data.CategoryId);

            await _bookRepository.AddBook(book); // Llamar al repositorio

            return Unit.Value; // O el resultado que corresponda
        }
    }



}
