using BookStore_Use_Asp_Net_Core_5_MVC.IRepository;
using BookStore_Use_Asp_Net_Core_5_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _repo;
        public AccountController(IAccountRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("/login")]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost("/login")]
        public async Task<IActionResult> LogIn(LogIn logIn)
        {
            if (ModelState.IsValid)
            {
                var result = await _repo.LogInAsync(logIn);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            return View(logIn);
        }

        [HttpGet("/signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost("/signup")]
        public async Task<IActionResult> SignUp(SignUp signUp)
        {

            if (ModelState.IsValid)
            {
                var result = await _repo.CreateUserAsync(signUp);

                if (!result.Succeeded)
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError(" ", err.Description);
                    }

                    return View(signUp);
                }

                ModelState.Clear();
                return View();
            }

            return View(signUp);
        }

        [HttpGet("/logout")]
        public async Task<IActionResult> LogOut()
        {
            await _repo.SignOutAsync();
            return RedirectToAction(nameof(LogIn));
        }

    }
}
