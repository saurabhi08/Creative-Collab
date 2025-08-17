using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MindAndMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Seeds an admin user and role if they do not exist.
        /// </summary>
        [HttpPost("seed-admin")]
        public async Task<IActionResult> SeedAdmin()
        {
            const string adminEmail = "admin@example.com";
            const string adminPassword = "Admin123$";
            const string adminRole = "Admin";

            if (!await _roleManager.RoleExistsAsync(adminRole))
            {
                await _roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            var user = await _userManager.FindByEmailAsync(adminEmail);
            if (user == null)
            {
                user = new IdentityUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
                var createResult = await _userManager.CreateAsync(user, adminPassword);
                if (!createResult.Succeeded)
                {
                    return BadRequest(createResult.Errors);
                }
            }

            if (!await _userManager.IsInRoleAsync(user, adminRole))
            {
                await _userManager.AddToRoleAsync(user, adminRole);
            }

            return Ok(new { message = "Admin user and role ensured.", email = adminEmail, password = adminPassword });
        }

        /// <summary>
        /// Login with username/password and create a cookie session.
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return Unauthorized();
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, isPersistent: false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            return Ok(new { message = "Logged in" });
        }

        /// <summary>
        /// Logout current user.
        /// </summary>
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { message = "Logged out" });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

