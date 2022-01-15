using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.Persistense.Entityes.Base
{
    /// <summary>
    /// Базовый класс для сущностей, имеющих имя, фамилию и отчество
    /// </summary>
    public abstract class Person : NamedEntity
    {
        public string Surname { get; set; }
        public string Patronymic { get; set; }
    }
}
