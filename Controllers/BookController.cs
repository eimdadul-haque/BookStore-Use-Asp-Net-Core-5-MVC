using BookStore_Use_Asp_Net_Core_5_MVC.IRepository;
using BookStore_Use_Asp_Net_Core_5_MVC.Models;
using BookStore_Use_Asp_Net_Core_5_MVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repo;

        public BookController(IBookRepository repo)
        {
            _repo = repo;
        }

        //Get all Books
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAllBook());
        }

        //Get spcicific book details
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            return View(await _repo.GetOneBook(id));
        }


        //Http Get for AddBookAndEdit Book
        [HttpGet]
        public async Task<IActionResult> AddAndEdit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                return View(await _repo.GetOneBook(id));
            }
        }

        //Http Post for AddBookAndEdit Books
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                int id = await _repo.AddBookAndEdit(book);
                return View();
            }
            return View(book);
        }


        //Http Get for Delete Book
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            bool IsDelete = await _repo.DeleteBook(id);
            return View();
        }


    }
}
