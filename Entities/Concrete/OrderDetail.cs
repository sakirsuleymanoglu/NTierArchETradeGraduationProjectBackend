using Core.Entities;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class OrderDetail : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal SalePrice { get; set; }
    }
}
