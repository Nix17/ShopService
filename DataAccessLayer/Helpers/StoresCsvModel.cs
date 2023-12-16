using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers;

public class StoresCsvModel
{
    public StoresCsvModel()
    {
    }

    public StoresCsvModel(string storeCode, string storeName)
    {
        StoreCode = storeCode;
        StoreName = storeName;
    }

    public string StoreCode { get; set; }
    public string StoreName { get; set; } = string.Empty;
}
