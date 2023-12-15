using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities;

public class ProductBatchEntity : BaseEntity
{
    public ProductBatchEntity()
    {
    }

    public ProductBatchEntity(int storeId, int productId, int quantity, decimal price)
    {
        StoreId = storeId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    // Связь с магазином
    public int StoreId { get; set; }
    public StoreEntity Store {  get; set; }

    // Связь с товаром
    public int ProductId { get; set; } // Связь с товаром
    public ProductEntity Product { get; set; }
    
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
