using BusinessLogicLayer.DTO.ProductBatch;
using BusinessLogicLayer.DTO.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces;

public interface ICsvWriterService
{
    Task WriteCsv(List<StoreDTO> dataStore, List<ProductBatchDTO> dataProducts);
}
