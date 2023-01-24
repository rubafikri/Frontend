namespace RecipeWebApi.Models
{
    public class Recipe
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PhotoName { get; set; }
        public List<Comments> Comments { get; set; }
        public string PreperationTime { get; set; }
        public int NoOfPeople { get; set; }
        public string Instructions { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
