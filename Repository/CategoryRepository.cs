using BookStore_Use_Asp_Net_Core_5_MVC.Data;
using BookStore_Use_Asp_Net_Core_5_MVC.IRepository;
using BookStore_Use_Asp_Net_Core_5_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _db;
        public CategoryRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Category>> GetAll()
        {
            return (await _db.categories.ToListAsync());
        }

        public async Task<int> Add(Category category)
        {
            await _db.categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return category.Id;
        }

        public async Task<int> Edit(Category category)
        {

            _db.categories.Update(category);
            await _db.SaveChangesAsync();
            return category.Id;
        }

        public async Task<Category> GetOne(int? id)
        {
            var category = await _db.categories.FindAsync(id);
            if (category != null)
            {
                return category;
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> Delete(int? id)
        {
            var category = await _db.categories.FindAsync(id);
            if (category != null)
            {
                _db.categories.Remove(category);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
