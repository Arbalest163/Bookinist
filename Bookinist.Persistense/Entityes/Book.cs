using Bookinist.Persistense.Entityes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.Persistense.Entityes
{
    public class Book : NamedEntity
    {
        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
