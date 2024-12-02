using System.Security.Claims;
using fish_mvc.Infrastructure.DatabaseManagement;
using fish_mvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace fish_mvc.Controllers;

[Route("[controller]/[action]")]
public class AuthController : Controller
{
    public AuthController (DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    private readonly DatabaseConnection _dbConnection;

    public async Task<IActionResult> Login (User? user)
    {
        if ( user == null )
        {
            return View(new User());
        }
        else
        {
            var userModel = _dbConnection.Users.FirstOrDefault(
                x => x.Username == user.Username && x.Password == user.Password);
            if ( userModel == null )
            {
                ModelState.AddModelError("", "Пользователя с такой комбинацией логина и пароля не существует.");
                return View(user);
            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new(ClaimTypes.Role, userModel.Role),
                    new(ClaimTypes.NameIdentifier, userModel.Id.ToString()),
                    new(ClaimTypes.Name, userModel.Username)
                }, CookieAuthenticationDefaults.AuthenticationScheme)));

            return Redirect("/Home/Index");
        }
    }

    public async Task<IActionResult> Logout ()
    {
        await HttpContext.SignOutAsync();

        return Redirect("/Auth/Login");
    }
    public IActionResult AccessDenied ()
    {
        return View();
    }
}