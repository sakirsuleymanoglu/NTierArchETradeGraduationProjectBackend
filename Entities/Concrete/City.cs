using Core.Entities;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class City : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
