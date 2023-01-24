using RecipeWebApi.Models;

namespace RecipeWebApi.DTOs
{
    public class RecipeDto
    {
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PhotoName { get; set; }
        public string PreperationTime { get; set; }
        public int NoOfPeople { get; set; }
        public string Instructions { get; set; }
        public string CategoryId { get; set; } 
        public IFormFile photoFile { get; set; }
    }
}
