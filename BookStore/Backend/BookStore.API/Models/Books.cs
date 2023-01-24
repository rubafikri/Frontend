namespace BookStore.API.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public int PublishYear { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public Authors Author { get; set; }
        public int PublisherId { get; set; }
        public Publishers Publisher { get; set; }
        public int? TranslatorId { get; set; }
        public Translators Translator { get; set; }
        public int CategoryId { get; set; }
        public Categories Category { get; set; }

    }
}
