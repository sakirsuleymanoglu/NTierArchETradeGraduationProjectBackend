using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Abstract
{
    public abstract class EntityBase
    {
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}
