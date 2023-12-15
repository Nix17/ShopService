using BusinessLogicLayer.DTO.Product;
using BusinessLogicLayer.DTO.Store;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO.ProductBatch;

public class ProductBatchDTO : BaseDTO
{
    public StoreDTO Store { get; set; }
    public ProductDTO Product { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
