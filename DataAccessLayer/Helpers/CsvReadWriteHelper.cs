using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers;

public static class CsvReadWriteHelper
{
    public static List<T> ReadCsvFile<T>(string filePath = "")
    {
        if (!File.Exists(filePath))
        {
            return new List<T>();
        }

        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<T>().ToList<T>();
        }
    }
}
