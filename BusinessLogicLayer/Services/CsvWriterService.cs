using BusinessLogicLayer.DTO.ProductBatch;
using BusinessLogicLayer.DTO.Store;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services;

public class CsvWriterService : ICsvWriterService
{
    public CsvWriterService()
    {
    }

    public async Task WriteCsv(List<StoreDTO> dataStore, List<ProductBatchDTO> dataProducts)
    {
        // Получаем текущую директорию
        string currentDirectory = Directory.GetCurrentDirectory();
        string storesCsvPath = Path.Combine(currentDirectory, "Data\\stores.csv");
        string productsCsvPath = Path.Combine(currentDirectory, "Data\\products.csv");

        var listStoresCsv = new List<StoresCsvModel>();
        foreach (var item in dataStore)
        {
            listStoresCsv.Add(new StoresCsvModel(item.Id.ToString(), item.Name.ToString()));
        }

        await CsvReadWriteHelper.WriteToCsv(storesCsvPath, listStoresCsv);


        var listProducts = new List<ProductsCsvModel>();
        foreach (var item in dataProducts)
        {
            listProducts.Add(new ProductsCsvModel(item.Product.Name, item.Store.Id.ToString(), item.Quantity, item.Price));
        }

        await CsvReadWriteHelper.WriteToCsv(productsCsvPath, listProducts);
    }
}
