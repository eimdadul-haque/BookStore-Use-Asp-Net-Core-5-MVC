using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet("/login")]
        public IActionResult LogIn()
        {
            return View();
        }
        
    }
}
