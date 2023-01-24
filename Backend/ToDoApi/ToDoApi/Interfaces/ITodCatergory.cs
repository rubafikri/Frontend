using ToDoApi.Models;

namespace ToDoApi.Interfaces
{
    public interface ITodCatergory
    {
        Task<List<ToDoCategory>> GetAllToDosCategory();
        Task<ToDoCategory> GetById(int id);
        Task<ToDoCategory> Add(ToDoCategory todo);
        Task<ToDoCategory> Update(int id, ToDoCategory todoChanegs);
        Task<bool> Delete(int id);
    }
}
