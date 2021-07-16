using BookStore_Use_Asp_Net_Core_5_MVC.Models;
using BookStore_Use_Asp_Net_Core_5_MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.IRepository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUp signUp);
        Task<SignInResult> LogInAsync(LogIn logIn);
        Task SignOutAsync();
    }
}