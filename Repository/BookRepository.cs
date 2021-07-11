using BookStore_Use_Asp_Net_Core_5_MVC.Data;
using BookStore_Use_Asp_Net_Core_5_MVC.IRepository;
using BookStore_Use_Asp_Net_Core_5_MVC.Models;
using BookStore_Use_Asp_Net_Core_5_MVC.SessionExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public BookRepository(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<List<Book>> GetAll()
        {
            return (await _db.books.Include(c => c.language).Include(c => c.category).Include(c => c.ImgeUrl).ToListAsync());
        }

        public async Task<int> Add(Book book)
        {
            book.PdfName = await FileHandle(book.BookPDF.FileName, "pdf", book.BookPDF);
            await _db.books.AddAsync(book);
            await _db.SaveChangesAsync();
            _db.Entry(book).GetDatabaseValues();
            await ImageActionAsync(book, false, "image");
            return book.Id;
        }

        public async Task<int> Edit(Book book)
        {
            if (book.ImgeUrl != null)
            {
                foreach (var item in book.ImgeUrl)
                {
                    bool resOne = await deleteFile("image", item.ImageName);
                }
                _db.imageGallaries.RemoveRange(book.ImgeUrl);
                await _db.SaveChangesAsync();
                _db.ChangeTracker.Clear();
            }

            if (book != null)
            {
                _db.books.Update(book);
                await _db.SaveChangesAsync();
                await ImageActionAsync(book, true, "image");
            }
            return book.Id;
        }

        public async Task<Book> GetOne(int? id)
        {
            var book = await _db.books.Include(c => c.language).Include(c => c.category).Include(c => c.ImgeUrl).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (book != null)
            {
                return book;
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> Delete(int? id)
        {
            var book = await _db.books.Include(c => c.category).Include(c => c.language).Include(c => c.ImgeUrl).FirstOrDefaultAsync(c => c.Id == id);

            if (book.ImgeUrl != null)
            {
                foreach (var item in book.ImgeUrl)
                {
                    bool resOne = await deleteFile("image", item.ImageName);
                }
                _db.imageGallaries.RemoveRange(book.ImgeUrl);
                await _db.SaveChangesAsync();
            }

            if (book != null)
            {
                _db.books.Remove(book);
                await _db.SaveChangesAsync();
                bool resTwo = await deleteFile("pdf", book.PdfName);
                return resTwo;
            }




            return false;
        }

        public async Task ImageActionAsync(Book book_, bool IsUpdate, string dir)
        {
            if (book_.ImageFile != null)
            {
                foreach (var file in book_.ImageFile)
                {
                    string fileName = await FileHandle(book_.BookPDF.FileName, "image", book_.BookPDF);

                    if (IsUpdate == true)
                    {
                        _db.imageGallaries.Update(new ImageGallary
                        {
                            ImageName = fileName,
                            BookId = book_.Id
                        });
                    }
                    else if (IsUpdate == false)
                    {
                        await _db.imageGallaries.AddAsync(new ImageGallary
                        {
                            ImageName = fileName,
                            BookId = book_.Id
                        });

                    }

                    await _db.SaveChangesAsync();


                }
            }
            else
            {
                if (IsUpdate == false)
                {
                    await _db.imageGallaries.AddAsync(new ImageGallary
                    {
                        ImageName = "/default/default.jpg",
                        BookId = book_.Id
                    });
                }
                else if (IsUpdate == true)
                {
                    _db.imageGallaries.Update(new ImageGallary
                    {
                        ImageName = "/default/default.jpg",
                        BookId = book_.Id
                    });
                }
                await _db.SaveChangesAsync();
            }

        }

        public async Task<bool> deleteFile(string dir, string fileName)
        {
            string path = Path.Combine(_env.WebRootPath, dir, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }

            return false;
        }

        public async Task<string> FileHandle(string FileName, string dir, IFormFile file)
        {
            string fileName = Path.GetFileNameWithoutExtension(FileName);
            string fileExtention = Path.GetExtension(FileName);
            fileName = fileName + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + fileExtention;
            string path = Path.Combine(_env.WebRootPath, dir, fileName);
            using (var fileStrem = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStrem);
            }
            return fileName;
        }

        public Task<int> Edit(List<ImageGallary> imageGallaries)
        {
            throw new NotImplementedException();
        }
    }
}

//PDF ACTION
//string fileName = Path.GetFileNameWithoutExtension(book.BookPDF.FileName);
//string fileExtention = Path.GetExtension(book.BookPDF.FileName);
//fileName = fileName + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + fileExtention;
//string path = Path.Combine(_env.WebRootPath, "pdf", fileName);

//using (var fileStrem = new FileStream(path, FileMode.Create))
//{
//    await book.BookPDF.CopyToAsync(fileStrem);
//}



//IMAGE ACTION

//string fileName = Path.GetFileNameWithoutExtension(file.FileName);
//string fileExctention = Path.GetExtension(file.FileName);
//fileName = fileName + DateTime.Now.ToString("dd-MM-yy_HH-mm-ss") + fileExctention;
//string path = Path.Combine(_env.WebRootPath, dir, fileName);

//using (var fileStrem = new FileStream(path, FileMode.Create))
//{
//    await file.CopyToAsync(fileStrem);
//}