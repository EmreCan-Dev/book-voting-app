using Application.Data;
using Application.Data.Entities;
using Application.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;

namespace Application.Mvc.Controllers
{
    public class UserController : Controller
    {

        public ApplicationnDbContext _dbcontext;
        public UserController(ApplicationnDbContext context)
        {
            _dbcontext = context;
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RateBooks(int bookId,int rating)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.Sid)??throw new InvalidOperationException());

            var vote = await _dbcontext.Votes.FirstOrDefaultAsync(x=>x.BookId==bookId&&x.UserId==userId);

            if (vote is null)
            {
                vote = new VoteEntity
                {
                    BookId = bookId,
                    UserId=userId,
                    Rating=rating
                };
                _dbcontext.Votes.Add(vote);
            }
            else
            {
                vote.Rating = rating;
                
            }

            await _dbcontext.SaveChangesAsync();

            return RedirectToAction("List","Book");
         

        }
    }
}
