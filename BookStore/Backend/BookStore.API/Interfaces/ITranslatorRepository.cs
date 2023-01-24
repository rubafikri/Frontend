using BookStore.API.Models;


namespace BookStore.API.Interfaces
{
    public interface ITranslatorRepository
    {
        Task<List<Translators>> GetAll();
        Task<Translators> Create(Translators translators);
        Task<Translators> Update(Translators translators);
        Task<bool> Delete(int id);
        
    }
}
