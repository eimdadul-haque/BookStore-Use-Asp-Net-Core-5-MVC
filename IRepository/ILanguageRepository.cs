using BookStore_Use_Asp_Net_Core_5_MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.IRepository
{
    public interface ILanguageRepository
    {
        Task<int> Add(Language language);
        Task<bool> Delete(int? id);
        Task<int> Edit(Language language);
        Task<List<Language>> GetAll();
        Task<Language> GetOne(int? id);
    }
}