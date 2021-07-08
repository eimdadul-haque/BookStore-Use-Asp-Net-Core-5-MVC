using BookStore_Use_Asp_Net_Core_5_MVC.Data;
using BookStore_Use_Asp_Net_Core_5_MVC.IRepository;
using BookStore_Use_Asp_Net_Core_5_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;
        public BookRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Book>> GetAllBook()
        {
            return (await _db.books.ToListAsync());
        }

        public async Task<int> AddBookAndEdit(Book book)
        {
            if (book.Id > 0)
            {
                _db.books.Update(book);
            }
            else
            {
                await _db.books.AddAsync(book);
            }
            await _db.SaveChangesAsync();
            return book.Id;
        }

        public async Task<Book> GetOneBook(int? id)
        {
            var book = await _db.books.FindAsync(id);
            if (book != null)
            {
                return book;
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> DeleteBook(int? id)
        {
            var book = await _db.books.FindAsync(id);
            if (book != null)
            {
                _db.books.Remove(book);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
