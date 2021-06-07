using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class BasketDetailsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductBrandName { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImagePath { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
