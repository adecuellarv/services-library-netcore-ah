namespace WebApplicationApi.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public string BookImage { get; set; }
        public string BookPdf { get; set; }
        public int CategoryId { get; set; }

        public Book(string name, string description, string image, string pdf, int categoryId)
        {
            BookName = name;
            BookDescription = description;
            BookImage = image;
            BookPdf = pdf;
            CategoryId = categoryId;
        }
    }
}
