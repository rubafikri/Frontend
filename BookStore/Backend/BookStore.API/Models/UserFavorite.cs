namespace BookStore.API.Models
{
    public class UserFavorite
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int BookId { get; set; }
        public Books Book { get; set; }

    }
}
