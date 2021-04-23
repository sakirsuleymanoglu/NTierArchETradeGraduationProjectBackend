using Core.Entities;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand : EntityBase, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
