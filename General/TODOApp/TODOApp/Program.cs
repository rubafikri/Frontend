using System;
using System.Collections.Generic;
using System.Linq;

namespace TODOApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToDo todo1 = new ToDo("Completetd Task", Status.Completed);
            ToDo todo2 = new ToDo("Deleted Task", Status.Deleted);
            ToDo todo3 = new ToDo("InProgress Task", Status.InProgress);
            ToDo todo4 = new ToDo("Completed Task", Status.Completed);
            List<ToDo> todo = new List<ToDo> { todo1, todo2, todo3, todo4 };

            List<ToDo> completed = ToDo.getAllCompleted(todo);
            foreach (var item in completed)
            {
                Console.WriteLine(item.Description);
            }

            List<ToDo> deleted = ToDo.getAllDeleted(todo);
            foreach (var item in deleted)
            {
                Console.WriteLine(item.Description);
            }

            List<ToDo> InProgress = ToDo.getAllInProgress(todo);
            foreach (var item in InProgress)
            {
                Console.WriteLine(item.Description);
            }


        }
    }
    class ToDo
    {
        public String Description { get; set; }
        public Status Status { get; set; }

        public ToDo(string description, Status status)
        {
            Description = description;
            Status = status;
        }
        public static List<ToDo> getAllCompleted(List<ToDo> tods)
        {
            var completed = tods.Where(x => x.Status == Status.Completed).ToList();
            return completed;
        }
        public static List<ToDo> getAllDeleted(List<ToDo> tods)
        {
            var Deleted = tods.Where(x => x.Status == Status.Deleted).ToList();
            return Deleted;
        }
        public static List<ToDo> getAllInProgress(List<ToDo> tods)
        {
            var InProgress = tods.Where(x => x.Status == Status.InProgress).ToList();
            return InProgress;
        }
    }
    public enum Status
    {
        NotStarted,
        InProgress,
        Completed,
        Deleted
    }


}
