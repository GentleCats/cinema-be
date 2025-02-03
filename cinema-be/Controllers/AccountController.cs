using cinema_be.Entities;
using cinema_be.Interfaces;
using cinema_be.Models.Account;
using cinema_be.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace cinema_be.Controllers
{

    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenService tokenService;
        private readonly RoleManager<Role> roleManager;
        private readonly IConfiguration config;
       

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IConfiguration config, ITokenService tokenService
          )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.config = config;
            this.tokenService = tokenService;

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
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userManager.FindByNameAsync(loginDto.Username);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            var result = await signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.RememberMe, false);
            if (!result.Succeeded)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            var token = await tokenService.GenerateToken(user);

            return Ok(new { token });
        }

        public class LoginDto
        {
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public bool RememberMe { get; set; }
        }


    }

}

