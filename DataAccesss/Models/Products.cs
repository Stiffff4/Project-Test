using System;

namespace DataAccesss.Models
{
    public class Products
    {
        public Int32 productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public Int32 productCost { get; set; }
        public Int32 categoryId { get; set; }
        public string categoryName { get; set; }
    }
}
