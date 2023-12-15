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

    public string StoreCode { get; set; }
    public string StoreName { get; set; } = string.Empty;
}
