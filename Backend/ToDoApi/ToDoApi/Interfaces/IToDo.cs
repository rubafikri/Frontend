using ToDoApi.Models;

namespace ToDoApi.Interfaces
{
    public interface IToDo
    {
        Task<List<ToDo>> GetAllToDos();
        Task<ToDo> GetById(int id);
        Task<ToDo> Add(ToDo todo);
        Task<ToDo> Update(int id, ToDo todoChanegs);
        Task<bool> Delete(int id);

    }
}
