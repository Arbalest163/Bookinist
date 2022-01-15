﻿using Bookinist.Persistense.Entityes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.Persistense.Entityes
{
    public class Genre : NamedEntity
    {
        public virtual ICollection<Book> Books { get; set; }
    }
}
