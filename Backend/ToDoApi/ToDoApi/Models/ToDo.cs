using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApi.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Task { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime DueDate { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string  Description { get; set; }

        public ToDoCategory toDoCategory { get; set; }

        [ForeignKey("CatID")]
        public int ToDoCategoryId { get; set; }

    }
}
