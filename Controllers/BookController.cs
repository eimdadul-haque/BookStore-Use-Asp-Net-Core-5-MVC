using BookStore_Use_Asp_Net_Core_5_MVC.Data;
using BookStore_Use_Asp_Net_Core_5_MVC.IRepository;
using BookStore_Use_Asp_Net_Core_5_MVC.Models;
using BookStore_Use_Asp_Net_Core_5_MVC.SessionExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repo;
        private readonly AppDbContext _db;

        public BookController(IBookRepository repo, AppDbContext db)
        {
            _repo = repo;
            _db = db;
        }

        //Get all Books
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        //Get spcicific book details
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            return View(await _repo.GetOne(id));
        }


        //Http Get for AddBookAndEdit Book
        [HttpGet]
        public async Task<IActionResult> Add_Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                return View(await _repo.GetOne(id));
            }
        }

        //Http Post for AddBookAndEdit Books
        [HttpPost]
        public async Task<IActionResult> Add_Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.Id > 0)
                {
                    var item = await _repo.GetOne(book.Id);
                    book.ImgeUrl = item.ImgeUrl;
                    int id = await _repo.Edit(book);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    int id = await _repo.Add(book);
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(book);
        }


        //Http Get for Delete Book
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            bool IsDelete = await _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
