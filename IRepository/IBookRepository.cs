using BookStore_Use_Asp_Net_Core_5_MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.IRepository
{
    public interface IBookRepository
    {
        Task<int> AddBookAndEdit(Book book);
        Task<bool> DeleteBook(int? id);
        Task<List<Book>> GetAllBook();
        Task<Book> GetOneBook(int? id);
    }
}