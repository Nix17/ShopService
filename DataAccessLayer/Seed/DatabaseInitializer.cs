using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Seed;

public static class DatabaseInitializer
{
    // TODO: если inMem, то прочитать файлы csv
    public static async Task SeedAsync(ApplicationDbContext db)
    {
        #region Products
        if (await db.Products.CountAsync() == 0)
        {
            var list = new List<ProductEntity>();
            var obj1 = new ProductEntity("Milk");
            list.Add(obj1);
            
            var obj2 = new ProductEntity("Coca-Cola");
            list.Add(obj2);

            await db.Products.AddRangeAsync(list);
            await db.SaveChangesAsync();
        }
        #endregion
    }
}
