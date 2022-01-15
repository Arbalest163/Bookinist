using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.Persistense.Entityes.Base
{
    /// <summary>
    /// Базовый класс для сущностей, имеющих имя
    /// </summary>
    public abstract class NamedEntity : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
