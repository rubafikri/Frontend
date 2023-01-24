namespace RecipeWebApi.Models
{
    public class Comments
    {
        public string RecipesId { get; set; }
        public Recipe Recipe { get; set; }
        public string UsersId { get; set; }
        public User User { get; set; }

    }
}
