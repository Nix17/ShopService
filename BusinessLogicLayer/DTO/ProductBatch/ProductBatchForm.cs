using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO.ProductBatch;

public class ProductBatchForm
{
    public ProductBatchForm()
    {
    }

    public ProductBatchForm(int productId, int storeId, int quantity, decimal price)
    {
        ProductId = productId;
        StoreId = storeId;
        Quantity = quantity;
        Price = price;
    }

    public int ProductId { get; set; }
    public int StoreId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
