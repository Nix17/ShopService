using BusinessLogicLayer.DTO.ProductBatch;
using BusinessLogicLayer.DTO.Store;
using BusinessLogicLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services;

public class CsvWriterEmptyService : ICsvWriterService
{
    public CsvWriterEmptyService()
    {
    }

    public async Task WriteCsv(List<StoreDTO> dataStore, List<ProductBatchDTO> dataProducts)
    {
    }
}
