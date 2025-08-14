using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public  class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public ICollection<Vote>? AuthorVotes { get; set; }
        public ICollection<Book> AuthorBooks { get; set; }=null!;
        public ICollection<Comment>? AuthorComments { get; set; }
    }
}
