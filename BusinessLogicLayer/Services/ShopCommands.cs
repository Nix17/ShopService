﻿using AutoMapper;
using BusinessLogicLayer.Data;
using BusinessLogicLayer.DTO.Product;
using BusinessLogicLayer.DTO.ProductBatch;
using BusinessLogicLayer.DTO.Store;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
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
    private readonly ICsvWriterService _csv;

    public ShopCommands(IMapper mapper, IUnitOfWork uow, ICsvWriterService csv)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
        _csv = csv;
    }

    #region PRODUCTS
    public async Task<ServiceActionResult<string>> AddProduct(ProductForm form)
    {
        try
        {
            var isExist = await _uow.ProductRepo.FindAsync(o => o.Name == form.Name);
            if (isExist != null) throw new Exception("A product with this name already exists!");

            var obj = _mapper.Map<ProductEntity>(form);
            _uow.ProductRepo.Detach(obj);
            var res = await _uow.ProductRepo.AddAsync(obj);
            
            // WRITE CSV
            var csvDataStores = await getStores();
            var csvDataBatches = await getAllBatches();
            await _csv.WriteCsv(csvDataStores, csvDataBatches);

            return new ServiceActionResult<string>(true,res.Id.ToString());
        } catch (Exception ex)
        {
            return new ServiceActionResult<string>(ex);
        }
    }

    public async Task<ServiceActionResult<string>> UpdateProduct(int id, ProductForm form)
    {
        try
        {
            var isExist = await _uow.ProductRepo.FindAsync(o => o.Name == form.Name);
            if (isExist != null) throw new Exception("A product with this name already exists!");

            var item = await _uow.ProductRepo.FindAsync(o => o.Id == id);
            if (item == null) throw new Exception("Not found");

            _mapper.Map(form, item);
            await _uow.ProductRepo.UpdateAsync(item);

            // WRITE CSV
            var csvDataStores = await getStores();
            var csvDataBatches = await getAllBatches();
            await _csv.WriteCsv(csvDataStores, csvDataBatches);

            return new ServiceActionResult<string>(true, "OK");
        } catch (Exception ex)
        {
            return new ServiceActionResult<string>(ex);
        }
    }

    public async Task<ServiceActionResult<string>> DeleteProduct(int id)
    {
        try
        {
            var item = await _uow.ProductRepo.FindAsync(o => o.Id == id);
            if (item == null) throw new Exception("Not found");

            await _uow.ProductRepo.DeleteAsync(item);

            // WRITE CSV
            var csvDataStores = await getStores();
            var csvDataBatches = await getAllBatches();
            await _csv.WriteCsv(csvDataStores, csvDataBatches);

            return new ServiceActionResult<string>(true, "OK");
        } catch (Exception ex)
        {
            return new ServiceActionResult<string>(ex);
        }
    }

    public async Task<ServiceActionResult<ProductDTO>> GetProduct(int id)
    {
        try
        {
            var item = await _uow.ProductRepo.GetByIntIdAsync(id);
            if (item == null) throw new Exception("Not found");

            var res = _mapper.Map<ProductDTO>(item);

            return new ServiceActionResult<ProductDTO>(true, res);
        } catch (Exception ex)
        {
            return new ServiceActionResult<ProductDTO>(ex);
        }
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
        try
        {
            var list = await _uow.ProductRepo.FindAllAsync(o => o.Name.ToUpper().Contains(search.ToUpper()));
            var res = _mapper.Map<List<ProductDTO>>(list);
            return new ServiceActionResult<List<ProductDTO>>(true, res);
        } catch (Exception ex)
        {
            return new ServiceActionResult<List<ProductDTO>>(ex);
        }
    }
    #endregion

    #region STORES
    public async Task<ServiceActionResult<string>> AddStore(StoreForm form)
    {
        try
        {
            //var obj = _mapper.Map<StoreEntity>(form);


            var obj = new StoreEntity(form.Name, form.Address);
            _uow.StoreRepo.Detach(obj);


            var res = await _uow.StoreRepo.AddAsync(obj);

            // WRITE CSV
            var csvDataStores = await getStores();
            var csvDataBatches = await getAllBatches();
            await _csv.WriteCsv(csvDataStores, csvDataBatches);

            return new ServiceActionResult<string>(true, res.Id.ToString());
        }
        catch (Exception ex)
        {
            return new ServiceActionResult<string>(ex);
        }
    }
    
    public async Task<ServiceActionResult<string>> UpdateStore(int id, StoreForm form)
    {
        try
        {
            var item = await _uow.StoreRepo.FindAsync(o => o.Id == id);
            if (item == null) throw new Exception("Not found");

            _mapper.Map(form, item);
            await _uow.StoreRepo.UpdateAsync(item);

            // WRITE CSV
            var csvDataStores = await getStores();
            var csvDataBatches = await getAllBatches();
            await _csv.WriteCsv(csvDataStores, csvDataBatches);

            return new ServiceActionResult<string>(true, "OK");
        }
        catch (Exception ex)
        {
            return new ServiceActionResult<string>(ex);
        }
    }

    public async Task<ServiceActionResult<string>> DeleteStore(int id)
    {
        try
        {
            var item = await _uow.StoreRepo.FindAsync(o => o.Id == id);
            if (item == null) throw new Exception("Not found");

            await _uow.StoreRepo.DeleteAsync(item);


            // WRITE CSV
            var csvDataStores = await getStores();
            var csvDataBatches = await getAllBatches();
            await _csv.WriteCsv(csvDataStores, csvDataBatches);

            return new ServiceActionResult<string>(true, "OK");
        }
        catch (Exception ex)
        {
            return new ServiceActionResult<string>(ex);
        }
    }

    public async Task<ServiceActionResult<StoreDTO>> GetStore(int id)
    {
        try
        {
            var item = await _uow.StoreRepo.GetByIntIdAsync(id);
            if (item == null) throw new Exception("Not found");

            var res = _mapper.Map<StoreDTO>(item);

            return new ServiceActionResult<StoreDTO>(true, res);
        }
        catch (Exception ex)
        {
            return new ServiceActionResult<StoreDTO>(ex);
        }
    }

    public async Task<ServiceActionResult<List<StoreDTO>>> GetAllStores()
    {
        try
        {
            var res = await getStores();
            return new ServiceActionResult<List<StoreDTO>>(true, "OK", res);
        }
        catch (Exception ex)
        {
            return new ServiceActionResult<List<StoreDTO>>(ex);
        }
    }

    private async Task<List<StoreDTO>> getStores()
    {
        var list = await _uow.StoreRepo.GetAllAsync();
        var res = _mapper.Map<List<StoreDTO>>(list);
        return res;
    }

    public async Task<ServiceActionResult<List<StoreDTO>>> SearchStore(string search)
    {
        try
        {
            var list = await _uow.StoreRepo.FindAllAsync(o => o.Name.ToUpper().Contains(search.ToUpper()) && o.Address.ToUpper().Contains(search.ToUpper()));
            var res = _mapper.Map<List<StoreDTO>>(list);
            return new ServiceActionResult<List<StoreDTO>>(true, res);
        }
        catch (Exception ex)
        {
            return new ServiceActionResult<List<StoreDTO>>(ex);
        }
    }
    #endregion

    #region PRODUCT_BATCH
    public async Task<ServiceActionResult<string>> AddProductBatch(ProductBatchForm form)
    {
        try
        {
            var isExisted = await _uow.ProductBatchRepo.FindAsync(o => o.ProductId == form.ProductId && o.StoreId == form.StoreId);
            if(isExisted != null)
            {
                if (isExisted.Quantity > 0) return new ServiceActionResult<string>(true, "OK");
            }

            var obj = _mapper.Map<ProductBatchEntity>(form);
            _uow.ProductBatchRepo.Detach(obj);
            var res = await _uow.ProductBatchRepo.AddAsync(obj);
            _uow.ProductBatchRepo.Detach(obj);

            // WRITE CSV
            //var csvDataStores = await getStores();
            //var csvDataBatches = await getAllBatches();
            //await _csv.WriteCsv(csvDataStores, csvDataBatches);

            return new ServiceActionResult<string>(true, res.Id.ToString());
        }
        catch (Exception ex)
        {
            return new ServiceActionResult<string>(ex);
        }
    }

    public async Task<ServiceActionResult<string>> AddListProductBatch(List<ProductBatchForm> data)
    {
        try
        {
            if (data.Count == 0) return new ServiceActionResult<string>(true, "OK");

            foreach (var item in data)
            {
                var isExisted = await _uow.ProductBatchRepo.FindAsync(o => o.ProductId == item.ProductId && o.StoreId == item.StoreId);
                if (isExisted != null)
                {
                    if (isExisted.Quantity == 0)
                    {
                        var obj = _mapper.Map<ProductBatchEntity>(item);
                        _uow.ProductBatchRepo.Detach(obj);
                        await _uow.ProductBatchRepo.AddAsync(obj);
                    }
                }
                else
                {
                    var obj = _mapper.Map<ProductBatchEntity>(item);
                    _uow.ProductBatchRepo.Detach(obj);
                    await _uow.ProductBatchRepo.AddAsync(obj);
                }
            }

            await _uow.SaveChangesAsync();

            // WRITE CSV
            var csvDataStores = await getStores();
            var csvDataBatches = await getAllBatches();
            await _csv.WriteCsv(csvDataStores, csvDataBatches);

            return new ServiceActionResult<string>(true, "OK");
        } catch (Exception ex)
        {
            return new ServiceActionResult<string>(ex);
        }
    }

    public async Task<ServiceActionResult<string>> UpdateProductBatch(int id, ProductBatchForm form)
    {
        try
        {
            var item = await _uow.ProductBatchRepo.FindAsync(o => o.Id == id);
            if (item == null) throw new Exception("Not found");

            _mapper.Map(form, item);
            await _uow.ProductBatchRepo.UpdateAsync(item);


            // WRITE CSV
            var csvDataStores = await getStores();
            var csvDataBatches = await getAllBatches();
            await _csv.WriteCsv(csvDataStores, csvDataBatches);

            return new ServiceActionResult<string>(true, "OK");
        }
        catch (Exception ex)
        {
            return new ServiceActionResult<string>(ex);
        }
    }

    /// <summary>
    /// Key => id, Value => Quantity
    /// </summary>
    /// <param name="dict"></param>
    /// <returns></returns>
    public async Task<ServiceActionResult<string>> ReduceQuantityProductBatch(Dictionary<int, int> dict)
    {
        try
        {
            var list = await _uow.ProductBatchRepo.FindAllAsync(o => dict.Keys.Contains(o.Id));
            if (list.Count == 0) return new ServiceActionResult<string>(true, "OK");
            if (list.Count != dict.Count) throw new Exception("Not found");

            while(dict.Count > 0)
            {
                var dictItem = dict.First();
                foreach(var item in list)
                {
                    var obj = await _uow.ProductBatchRepo.GetByIntIdAsync(item.Id);
                    obj.Quantity = obj.Quantity - dictItem.Value;
                    await _uow.SaveChangesAsync();
                    _uow.ProductBatchRepo.Detach(obj);
                }

                dict.Remove(dictItem.Key);
            }


            // WRITE CSV
            var csvDataStores = await getStores();
            var csvDataBatches = await getAllBatches();
            await _csv.WriteCsv(csvDataStores, csvDataBatches);

            return new ServiceActionResult<string>(true, "OK");

        } catch (Exception ex)
        {
            return new ServiceActionResult<string>(ex);
        }
    }

    public async Task<ServiceActionResult<string>> DeleteProductBatch(int id)
    {
        try
        {
            var item = await _uow.ProductBatchRepo.FindAsync(o => o.Id == id);
            if (item == null) throw new Exception("Not found");

            await _uow.ProductBatchRepo.DeleteAsync(item);

            // WRITE CSV
            var csvDataStores = await getStores();
            var csvDataBatches = await getAllBatches();
            await _csv.WriteCsv(csvDataStores, csvDataBatches);

            return new ServiceActionResult<string>(true, "OK");
        }
        catch (Exception ex)
        {
            return new ServiceActionResult<string>(ex);
        }
    }

    public async Task<ServiceActionResult<ProductBatchDTO>> GetProductBatch(int id)
    {
        try
        {
            var item = await _uow.ProductBatchRepo.GetByIntIdAsync(id);
            if (item == null) throw new Exception("Not found");

            var res = _mapper.Map<ProductBatchDTO>(item);

            return new ServiceActionResult<ProductBatchDTO>(true, res);
        }
        catch (Exception ex)
        {
            return new ServiceActionResult<ProductBatchDTO>(ex);
        }
    }

    public async Task<ServiceActionResult<List<ProductBatchDTO>>> GetAllProductBatches()
    {
        try
        {
            var res = await getAllBatches();
            return new ServiceActionResult<List<ProductBatchDTO>>(true, "OK", res);
        }
        catch (Exception ex)
        {
            return new ServiceActionResult<List<ProductBatchDTO>>(ex);
        }
    }

    private async Task<List<ProductBatchDTO>> getAllBatches()
    {
        var list = await _uow.ProductBatchRepo.FindAllAsync(o => o.Quantity > 0);

        foreach (var item in list)
        {
            var ps = await _uow.ProductRepo.GetAllAsync();
            var ss = await _uow.StoreRepo.GetAllAsync();
            var product = ps.FirstOrDefault(o => o.Id == item.ProductId);
            var store = ss.FirstOrDefault(o => o.Id == item.StoreId);
            item.Product = product;
            item.Store = store;
        }

        var res = _mapper.Map<List<ProductBatchDTO>>(list);

        return res;
    }
    #endregion
}
