using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BujairiTic.Models;
using System.Threading.Tasks;

public class AccountController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string Email, string Password, string? returnUrl = null)
    {
        var user = await _userManager.FindByEmailAsync(Email);

        // 👑 لو كان موجود في Identity → يعني Admin
        if (user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
        }

        // 👤 لو مش Admin → نعتبره مستخدم وهمي
        HttpContext.Session.SetString("FAKE_USER", Email);

        return RedirectToAction("Index", "Home");
    }


    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }

    public IActionResult AccessDenied()
    {
        return Content("Access Denied");
    }
}
