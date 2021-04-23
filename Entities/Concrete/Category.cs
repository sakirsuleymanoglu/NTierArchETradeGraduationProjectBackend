using Core.Entities;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Category : EntityBase, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
