using BusinessLogicLayer.Data;
using BusinessLogicLayer.DTO.Product;
using BusinessLogicLayer.DTO.ProductBatch;
using BusinessLogicLayer.DTO.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces;

public interface IShopCommands
{
    #region PRODUCTS
    Task<ServiceActionResult<string>> AddProduct(ProductForm form);
    Task<ServiceActionResult<string>> UpdateProduct(Guid id, ProductForm form);
    Task<ServiceActionResult<string>> DeleteProduct(Guid id);
    Task<ServiceActionResult<ProductDTO>> GetProduct(Guid id);
    Task<ServiceActionResult<List<ProductDTO>>> GetAllProducts();
    Task<ServiceActionResult<List<ProductDTO>>> SearchProduct(string search);
    #endregion

    #region STORES
    Task<ServiceActionResult<string>> AddStore(StoreForm form);
    Task<ServiceActionResult<string>> UpdateStore(Guid id, StoreForm form);
    Task<ServiceActionResult<string>> DeleteStore(Guid id);
    Task<ServiceActionResult<StoreDTO>> GetStore(Guid id);
    Task<ServiceActionResult<List<StoreDTO>>> GetAllStores();
    Task<ServiceActionResult<List<StoreDTO>>> SearchStore(string search);
    #endregion

    #region PRODUCT_BATCH
    Task<ServiceActionResult<string>> AddProductBatch(ProductBatchForm form);
    Task<ServiceActionResult<string>> UpdateProductBatch(Guid id, ProductBatchForm form);
    Task<ServiceActionResult<string>> DeleteProductBatch(Guid id);
    Task<ServiceActionResult<ProductBatchDTO>> GetProductBatch(Guid id);
    Task<ServiceActionResult<List<ProductBatchDTO>>> GetAllProductBatches();
    #endregion
}
