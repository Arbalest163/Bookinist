using Bookinist.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.Persistense.Entityes.Base
{
    /// <summary>
    /// Базовый класс для сущностей, имеющих Id
    /// </summary>
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
