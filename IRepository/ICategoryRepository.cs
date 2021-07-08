using BookStore_Use_Asp_Net_Core_5_MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.IRepository
{
    public interface ICategoryRepository
    {
        Task<int> Edit(Category category);
        Task<int> Add(Category category);
        Task<bool> Delete(int? id);
        Task<List<Category>> GetAll();
        Task<Category> GetOne(int? id);
    }
}