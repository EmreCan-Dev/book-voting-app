using Application.Data;
using Application.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Mvc.Controllers
{
    public class BookController : Controller
    {
      
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        
    }
}
