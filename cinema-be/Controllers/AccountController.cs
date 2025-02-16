﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using cinema_be.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using cinema_be.Models.Account;
using cinema_be.Services;
using cinema_be.Interfaces;
using System.Security.Claims;

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

        [Authorize]
        [HttpGet("get-me")]
        public async Task<ActionResult> GetMe()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { success = false, message = "User ID not found in token" });
            }

            // Шукаємо користувача за userId
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound(new { success = false, message = "User not found" });
            }

            // Повертаємо дані користувача
            return Ok(new
            {
                success = true,
                user = new
                {
                    id = user.Id,
                    username = user.UserName,
                    email = user.Email
                }
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
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
                // Додаємо користувача до ролі "Member"
                var roleResult = await userManager.AddToRoleAsync(user, "Member");
                if (!roleResult.Succeeded)
                {
                    return BadRequest(new
                    {
                        success = false,
                        errors = roleResult.Errors.Select(e => e.Description).ToList()
                    });
                }

                // Автентифікація після реєстрації
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

