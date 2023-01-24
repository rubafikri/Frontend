using Microsoft.Extensions.Hosting;

namespace RecipeWebApi.Models
{
    public class Category
    {
        public string CategoryId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string PhotoName { get; set; }
        public List<Recipe> Recipes { get; set; }

    }
}
