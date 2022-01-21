using Bookinist.Persistense.Context;
using Bookinist.Persistense.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.Persistense
{
    public class BookRepository : DbRepository<Book>
    {
        public override IQueryable<Book> Items => base.Items
            .Include(item => item.Author)
            .Include(item => item.Genre);
        public BookRepository(BookinistDb db) : base(db) { }
    }
}
