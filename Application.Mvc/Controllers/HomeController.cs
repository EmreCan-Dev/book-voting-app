using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
//using Application.Mvc.Models;

namespace Application.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult List()
    {
        return View();
    }
   

   
}
