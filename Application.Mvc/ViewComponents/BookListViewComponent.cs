using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Application.Data;
using Application.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Mvc.ViewComponents
{
    public class BookListViewComponent:ViewComponent
    {

        public ApplicationnDbContext _dbcontext;
        public IHttpContextAccessor _http;
        public BookListViewComponent(ApplicationnDbContext context,IHttpContextAccessor http)
        {
            _dbcontext = context;
            _http = http;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var principal = _http.HttpContext?.User;

            var userId = int.Parse(principal.FindFirstValue(ClaimTypes.Sid)??throw new InvalidOperationException());

            var bookList = await _dbcontext.Books.Select(x => new BookViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                Category = x.Category.Name,
                UserRating = x.BookVotes.Where(v => v.UserId == userId).Select(v => v.Rating).FirstOrDefault()

            }).ToListAsync();

            return View(bookList);
        }
    }
}
