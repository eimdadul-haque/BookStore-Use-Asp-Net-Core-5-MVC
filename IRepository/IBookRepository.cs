using BookStore_Use_Asp_Net_Core_5_MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.IRepository
{
    public interface IBookRepository
    {
        Task<int> Add(Book book);
        Task<bool> Delete(int? id);
        Task<int> Edit(Book book);
        Task<List<Book>> GetAll();
        Task<Book> GetOne(int? id);
    }
}