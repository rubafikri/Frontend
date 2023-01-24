using BookStore.API.Models;

namespace BookStore.API.DTOs
{
    public class createUserFavDto
    {
        public string AppUserId { get; set; }
        public int BookId { get; set; }
    }
}
