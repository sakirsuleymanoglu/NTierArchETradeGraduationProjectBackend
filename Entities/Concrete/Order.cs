using Core.Entities;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Order : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int OrderStatusId { get; set; }
        public int Count { get; set; }
    }
}
