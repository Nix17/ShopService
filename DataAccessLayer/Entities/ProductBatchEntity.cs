using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities;

public class ProductBatchEntity : BaseEntity
{
    // Связь с магазином
    public Guid StoreId { get; set; }
    public StoreEntity Store {  get; set; }

    // Связь с товаром
    public Guid ProductId { get; set; } // Связь с товаром
    public ProductEntity Product { get; set; }
    
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
