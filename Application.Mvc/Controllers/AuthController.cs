using Application.Data;
using Application.Mvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Application.Mvc.Controllers
{
    public class AuthController : Controller
    {

        public ApplicationnDbContext _dbcontext;

        public AuthController(ApplicationnDbContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginViewModel loginviewmodel)
        {
         var user = await _dbcontext.Users.Include(x => x.Role).SingleOrDefaultAsync(u=>u.Email==loginviewmodel.Email&&u.Password==loginviewmodel.Password);

            if (user is null)
            {
                ViewBag.Error = "User is not found";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Role,user.Role.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim("login-time",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))

            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.Now.AddMinutes(30)
            };

          await  HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
