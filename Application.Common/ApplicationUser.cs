using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class ApplicationUser:IdentityUser
    {
        public ICollection<Vote>? UserVotes { get; set; }
        public ICollection<Comment>? UserComments { get; set; }
    }
}
