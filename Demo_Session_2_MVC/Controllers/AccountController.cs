using Demo_Session_2_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Session_2_MVC.Controllers;
[Route("account")]
public class AccountController : Controller
{
    private AccountService accountService;
    public AccountController(AccountService _accountService) {
            accountService= _accountService;
    }

    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        return View("index");
    }
    [HttpPost]
    [Route("login")]
    public IActionResult Login(string username, string password)
    {
        if (accountService.login(username, password)){
            HttpContext.Session.SetString("username",username);
            return RedirectToAction("welcome");
        }
        else
        {
            TempData["msg"] = "Invalid fail";
            return RedirectToAction("index");
        } 
    }
    [Route("welcome")]
    public IActionResult Welcome()
    {
        ViewBag.username = HttpContext.Session.GetString("username");
        return View("welcome");
    }
    [Route("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("username");
        return RedirectToAction("index");
    }
    [Route("profile")]
    public IActionResult Profile()
    {
        var account = accountService.find(HttpContext.Session.GetString("username"));

        return View("profile", account);

    }
}
