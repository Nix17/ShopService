using AutoMapper;
using BusinessLogicLayer.Data;
using BusinessLogicLayer.DTO.Product;
using BusinessLogicLayer.DTO.ProductBatch;
using BusinessLogicLayer.DTO.Store;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services;

public class ShopCommands : IShopCommands
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;

    public ShopCommands(IMapper mapper, IUnitOfWork uow)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
    }

    #region PRODUCTS
    public async Task<ServiceActionResult<string>> AddProduct(ProductForm form)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceActionResult<string>> UpdateProduct(Guid id, ProductForm form)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceActionResult<string>> DeleteProduct(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceActionResult<ProductDTO>> GetProduct(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceActionResult<List<ProductDTO>>> GetAllProducts()
    {
        try
        {
            var list = await _uow.ProductRepo.GetAllAsync();
            var res = _mapper.Map<List<ProductDTO>>(list);
            return new ServiceActionResult<List<ProductDTO>>(true, "OK", res);
        } catch (Exception ex)
        {
            return new ServiceActionResult<List<ProductDTO>>(ex);
        }
    }

    public async Task<ServiceActionResult<List<ProductDTO>>> SearchProduct(string search)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region STORES
    public async Task<ServiceActionResult<string>> AddStore(StoreForm form)
    {
        throw new NotImplementedException();
    }
    
    public async Task<ServiceActionResult<string>> UpdateStore(Guid id, StoreForm form)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceActionResult<string>> DeleteStore(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceActionResult<StoreDTO>> GetStore(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceActionResult<List<StoreDTO>>> GetAllStores()
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceActionResult<List<StoreDTO>>> SearchStore(string search)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region PRODUCT_BATCH
    public async Task<ServiceActionResult<string>> AddProductBatch(ProductBatchForm form)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceActionResult<string>> UpdateProductBatch(Guid id, ProductBatchForm form)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceActionResult<string>> DeleteProductBatch(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceActionResult<ProductBatchDTO>> GetProductBatch(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceActionResult<List<ProductBatchDTO>>> GetAllProductBatches()
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceActionResult<List<ProductBatchDTO>>> SearchProductBatches(string search)
    {
        throw new NotImplementedException();
    }
    #endregion
}
