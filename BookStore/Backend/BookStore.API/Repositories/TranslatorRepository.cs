using BookStore.API.Data;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class TranslatorRepository : ITranslatorRepository
    {
        private readonly BookStoreDbContext _context;

        public TranslatorRepository(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<Translators>> GetAll()
        {
            var translators = await _context.Translators.ToListAsync();
            return translators;
        }
        public async Task<Translators> Create(Translators translators)
        {
            await _context.Translators.AddAsync(translators);
            await _context.SaveChangesAsync();
            return translators;
        }

        public async Task<Translators> Update(Translators translators)
        {
            var translatorFound = await _context.Translators.SingleOrDefaultAsync(x => x.Id == translators.Id);
            if (translatorFound == null)
                return translatorFound;
            else
            {
                translatorFound.Name = translators.Name;
                _context.Translators.Update(translatorFound);
                await _context.SaveChangesAsync();
                return translatorFound;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var translator = await _context.Translators.FindAsync(id);
            if (translator == null)
                return false;
            else
            {
                
                _context.Translators.Remove(translator);
                await _context.SaveChangesAsync();
                return true;
            }
            
        }

    }
}
