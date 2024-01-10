using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using admin_cms.Models;
using System.Net;
using Microsoft.AspNetCore.CookiePolicy;

namespace admin_cms.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Message = this.HttpContext.Session.GetString("alunos");

        return View();
    }

    public IActionResult Privacy()
    {
        this.HttpContext.Response.Cookies.Append("alunos", "alunos do tornese", new CookieOptions
        {
            //Expires - DateTimeOffset.UtcNow.AddDays(1).AddMinutes(-5)
            Expires = DateTimeOffset.UtcNow.AddMinutes(3),
            HttpOnly = true
        });
        // this.HttpContext.Session.SetString("alunos", "do torne-se um programador");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
