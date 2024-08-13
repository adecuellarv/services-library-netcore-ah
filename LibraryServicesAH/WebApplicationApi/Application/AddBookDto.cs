namespace WebApplicationApi.Application
{
    public class AddBookDto
    {
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public IFormFile BookImageFile { get; set; }
        public IFormFile BookPdfFile { get; set; }
        public string BookImage { get; set; }
        public string BookPdf { get; set; }
        public int CategoryId { get; set; }

        // Constructor sin parámetros
        public AddBookDto() { }

        // Constructor con parámetros
        public AddBookDto(string name, string description, string image, string pdf, int categoryId)
        {
            BookName = name;
            BookDescription = description;
            BookImage = image;
            BookPdf = pdf;
            CategoryId = categoryId;
        }
    }
}
