using BookStore_Use_Asp_Net_Core_5_MVC.Data;
using BookStore_Use_Asp_Net_Core_5_MVC.IRepository;
using BookStore_Use_Asp_Net_Core_5_MVC.Models;
using BookStore_Use_Asp_Net_Core_5_MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountRepository(AppDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUp signUp)
        {
            var user = new ApplicationUser()
            {
                UserName = signUp.Email,
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                Gender = signUp.Gender,
                PhoneNumber = signUp.Phone,
                BirthDay = signUp.BirthDay

            };

            var result =await _userManager.CreateAsync(user, signUp.Password);

            return result;
        }

        public async Task<SignInResult> LogInAsync(LogIn logIn)
        {
            var result = await _signInManager.PasswordSignInAsync(logIn.Email, logIn.Password, false, false);
            return result; 
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
