using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using cinema_be.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using cinema_be.Models.Account;

namespace cinema_be.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<Role> roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager
          )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                // Якщо ModelState не валідний, повертаємо помилки валідації
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { success = false, errors });
            }

            var user = new User
            {
                UserName = request.Username,
                Email = request.Email,
            };

            // Створення користувача
            var result = await userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                // Якщо реєстрація успішна, виконуємо автентифікацію
                await signInManager.SignInAsync(user, isPersistent: false);

                return Ok(new
                {
                    success = true,
                    message = "Registration successful.",
                    user = new
                    {
                        id = user.Id,
                        username = user.UserName,
                        email = user.Email
                    }
                });
            }

            // Якщо виникли помилки, збираємо їх у список і повертаємо
            var errorsList = result.Errors.Select(e => e.Description).ToList();
            return BadRequest(new { success = false, errors = errorsList });
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<JsonResult> Login(string username, string password, bool rememberMe)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await signInManager.PasswordSignInAsync(username, password, rememberMe, false);

                var success = identityResult.Succeeded;
                return Json(new { success });
            }
            return Json(false);
        }
    }

}

