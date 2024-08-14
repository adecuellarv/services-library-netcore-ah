namespace WebApplicationApi.Application
{
    public class UpdateBookDto
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? BookDescription { get; set; }
        public IFormFile? BookImageFile { get; set; }
        public IFormFile? BookPdfFile { get; set; }
        public string? BookImage { get; set; }
        public string? BookPdf { get; set; }
        public string? CategoryId { get; set; }

        // Constructor sin parámetros
        public UpdateBookDto() { }

        // Constructor con parámetros opcionales
        public UpdateBookDto(string? name = null, string? description = null, string? image = null, string? pdf = null, string? categoryId = null, int bookId = 0)
        {
            BookName = name;
            BookDescription = description;
            BookImage = image;
            BookPdf = pdf;
            CategoryId = categoryId;
            BookId = bookId;
        }
    }
}
