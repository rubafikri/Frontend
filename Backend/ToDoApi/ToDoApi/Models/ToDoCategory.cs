namespace ToDoApi.Models
{
    public class ToDoCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        List<ToDo> toDos { get; set; } 


    }
}
