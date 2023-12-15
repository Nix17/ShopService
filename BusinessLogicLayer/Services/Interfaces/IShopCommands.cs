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
    Task<ServiceActionResult<string>> UpdateProduct(int id, ProductForm form);
    Task<ServiceActionResult<string>> DeleteProduct(int id);
    Task<ServiceActionResult<ProductDTO>> GetProduct(int id);
    Task<ServiceActionResult<List<ProductDTO>>> GetAllProducts();
    Task<ServiceActionResult<List<ProductDTO>>> SearchProduct(string search);
    #endregion

    #region STORES
    Task<ServiceActionResult<string>> AddStore(StoreForm form);
    Task<ServiceActionResult<string>> UpdateStore(int id, StoreForm form);
    Task<ServiceActionResult<string>> DeleteStore(int id);
    Task<ServiceActionResult<StoreDTO>> GetStore(int id);
    Task<ServiceActionResult<List<StoreDTO>>> GetAllStores();
    Task<ServiceActionResult<List<StoreDTO>>> SearchStore(string search);
    #endregion

    #region PRODUCT_BATCH
    Task<ServiceActionResult<string>> AddProductBatch(ProductBatchForm form);
    Task<ServiceActionResult<string>> UpdateProductBatch(int id, ProductBatchForm form);
    Task<ServiceActionResult<string>> DeleteProductBatch(int id);
    Task<ServiceActionResult<ProductBatchDTO>> GetProductBatch(int id);
    Task<ServiceActionResult<List<ProductBatchDTO>>> GetAllProductBatches();
    #endregion
}
