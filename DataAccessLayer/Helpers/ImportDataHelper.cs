using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers;

public static class ImportDataHelper
{
    public static async Task ImportToDbInMemory(ApplicationDbContext dbContext, List<StoresCsvModel> storesCsv, List<ProductsCsvModel> productsCsv)
    {
        if (storesCsv == null || productsCsv == null) return;
        if (storesCsv.Count == 0) return;

        foreach(var item in productsCsv)
        {
            var store = storesCsv.Find(o => o.StoreCode == item.StoreCode);
            item.StoreCode = store.StoreName;
        }

        var listStoresToDb = StoresMapper(storesCsv);
        await dbContext.Stores.AddRangeAsync(listStoresToDb);

        var listProductsToDb = ProductMapper(productsCsv);
        await dbContext.Products.AddRangeAsync(listProductsToDb);
        // Сохраняем
        await dbContext.SaveChangesAsync();

        var listStores = await dbContext.Stores.AsNoTracking().ToListAsync();
        var listProducts = await dbContext.Products.AsNoTracking().ToListAsync();

        var listBatchesToDb = ProductBatchMapper(listStores, listProducts, productsCsv);
        await dbContext.ProductBatches.AddRangeAsync(listBatchesToDb);
        await dbContext.SaveChangesAsync();
    }

    private static List<StoreEntity> StoresMapper(List<StoresCsvModel> dataCsv)
    {
        List<StoreEntity> result = new List<StoreEntity>();
        foreach (var store in dataCsv)
        {
            result.Add(new StoreEntity(store.StoreName));
        }
        return result;
    }

    private static List<ProductEntity> ProductMapper(List<ProductsCsvModel> dataCsv)
    {
        List<ProductEntity> result = new List<ProductEntity>();
        foreach(var product in dataCsv)
        {
            result.Add(new ProductEntity(product.ProductName));
        }

        result = result.GroupBy(product => product.Name)
        .Select(group => new ProductEntity(group.Key))
        .ToList();

        return result;
    }

    private static List<ProductBatchEntity> ProductBatchMapper(
        List<StoreEntity> stores,
        List<ProductEntity> products,
        List<ProductsCsvModel> dataCsv
        )
    {
        List<ProductBatchEntity> result = new List<ProductBatchEntity>();

        foreach (var data in dataCsv)
        {
            var p = products.Find(o => o.Name == data.ProductName);
            var s = stores.Find(o => o.Name == data.StoreCode);
            result.Add(new ProductBatchEntity(p.Id, s.Id, data.Quantity, data.Price));
        }

        return result;
    }
}
