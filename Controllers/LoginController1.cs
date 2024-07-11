using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoginController1 : Controller
    {
		Context c = new Context();
		[AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Admin p)
        {
           var datavalue= c.admins.FirstOrDefault(x=>x.UserName == p.UserName && x.Password==p.Password);
            if (datavalue!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.UserName),
                };
                var useridentity=new ClaimsIdentity(claims, "LoginController1");
                ClaimsPrincipal user = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(user);
                return RedirectToAction("Index", "CategoryController1");
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "LoginController1");
        }
    }
}
