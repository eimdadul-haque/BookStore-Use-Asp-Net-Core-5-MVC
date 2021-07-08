using BookStore_Use_Asp_Net_Core_5_MVC.IRepository;
using BookStore_Use_Asp_Net_Core_5_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repo;
        public CategoryController (ICategoryRepository repo)
        {
           _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

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

        [HttpPost]
        public async Task<IActionResult> Add_Edit(Category category_)
        {
             
            if (ModelState.IsValid)
            {
                if (category_.Id > 0)
                {
                    int id = await _repo.Edit(category_);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    int id = await _repo.Edit(category_);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(category_);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
               await _repo.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
