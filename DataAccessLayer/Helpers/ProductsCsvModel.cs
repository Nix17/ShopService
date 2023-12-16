using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers;

public class ProductsCsvModel
{
    public ProductsCsvModel()
    {
    }

    public ProductsCsvModel(string productName, string storeCode, int quantity, decimal price)
    {
        ProductName = productName;
        StoreCode = storeCode;
        Quantity = quantity;
        Price = price;
    }

    public string ProductName { get; set; } = string.Empty;
    public string StoreCode { get; set; }
    public int Quantity { get; set; } = 0;
    public decimal Price { get; set; } = 0.0m;
}
