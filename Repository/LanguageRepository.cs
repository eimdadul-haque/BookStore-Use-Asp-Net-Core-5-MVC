using BookStore_Use_Asp_Net_Core_5_MVC.Data;
using BookStore_Use_Asp_Net_Core_5_MVC.IRepository;
using BookStore_Use_Asp_Net_Core_5_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly AppDbContext _db;
        public LanguageRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Language>> GetAll()
        {
            return (await _db.languages.ToListAsync());
        }

        public async Task<int> Add(Language language)
        {
            await _db.AddAsync(language);
            await _db.SaveChangesAsync();
            return language.Id;
        }

        public async Task<int> Edit(Language language)
        {

            _db.languages.Update(language);
            await _db.SaveChangesAsync();
            return language.Id;
        }

        public async Task<Language> GetOne(int? id)
        {
            var language = await _db.languages.FindAsync(id);
            if (language != null)
            {
                return language;
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> Delete(int? id)
        {
            var language = await _db.languages.FindAsync(id);
            if (language != null)
            {
                _db.languages.Remove(language);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
