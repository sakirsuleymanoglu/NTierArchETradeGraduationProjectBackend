using Core.Entities;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Address : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public string AddressDetail { get; set; }
        public string PostalCode { get; set; }
    }
}
