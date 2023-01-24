namespace BookStore.API.Models
{
    public class BookReview
    {
        public int Id { get; set; }
        public string AppUserId { get; set; } = "99509ac3-669e-45ab-9f45-eec7e02a6841";
        public AppUser AppUser { get; set; }
        public int BookId { get; set; }
        public Books Book { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; } = 1;
    }
}
